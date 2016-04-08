using UnityEngine;
using System.Collections;

public class BossWalk 	: MonoBehaviour {
	
	private GameObject player;
	private Vector2 playerLoc;
	private Vector2 bossLoc;
	private float differenceX;
	private float differenceY;

	private float roll;
	public Animator animator;

	[SerializeField] private Sprite idleImg;
	private bool inRange;
	private bool canAttack;
	private bool walking;
	private bool stomping;
	private bool shooting;
	public GameObject laserPrefab;
	public float speed;
	public float sightRange;
	public float attackRange;
	public bool faceLeft;

	public float stompChance;
	public float stompDamage;
	public float stompCooldown;
	public float laserDamage;
	public float laserCooldown;
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerLoc = new Vector2 (player.transform.position.x, player.transform.position.y);
		canAttack = true;
	}

	void Update () 
	{

		playerLoc.x = player.transform.position.x;
		bossLoc.x = transform.position.x;
		differenceX = bossLoc.x - playerLoc.x;
		differenceY = transform.position.y - player.transform.position.y;
		if (Mathf.Abs (differenceX) > attackRange)
			inRange = false;
		if (Mathf.Abs (differenceX) < attackRange) {
			inRange = true;
			animator.SetBool ("isWalking", false);
			walking = false;
		}

		//if differenceX is larger than atk, but lower than sight
		//this allows the guy to move
		changeDirection();

		if (!inRange && Mathf.Abs (differenceX) < sightRange && !shooting && !stomping && canAttack) {
			if (differenceX < 0) { //if you are to the right of the boss
				animator.SetBool ("isWalking", true);
				walking = true;
				transform.position = Vector3.Lerp (transform.position, new Vector3 (playerLoc.x, playerLoc.y, 1), speed * Time.deltaTime);
			}
			if (differenceX > 0) {//if you are to the left of the boss
				animator.SetBool ("isWalking", true);
				walking = true;
				transform.position = Vector3.Lerp (transform.position, new Vector3 (playerLoc.x, playerLoc.y, 1), speed * Time.deltaTime);
			}
		} else if (!inRange && Mathf.Abs (differenceX) > sightRange) {
			animator.SetBool ("isWalking", false);
			walking = false;
		}

		if (inRange) { //inrange, stop walking
			animator.SetBool ("isWalking", false);
			walking = false;
			if (canAttack) {//if you can attack, do it
				canAttack = false;
				roll = Random.value * 100; //roll for attack
				Debug.Log(roll);	
				if (roll < stompChance) { //GETSTOMPED
					stomping = true;
					animator.SetBool ("isStomping", true);
					StartCoroutine (BossStomp ());
				} else { //LAZOR
					shooting = true;
					animator.SetBool ("isShooting", true);
					StartCoroutine (BossLaser ());
				}
			} 
		}

		checkIdle ();
	}

	void checkIdle(){
		if (!stomping && !shooting && !walking)
			this.transform.GetChild(0).GetComponent<SpriteRenderer> ().sprite = idleImg;
	}

	void changeDirection(){
		if (!shooting && !stomping && canAttack) {
			if (differenceX < 0) {
				faceLeft = false;
				transform.localScale = new Vector3 (2, 2, 1);
			}
			if (differenceX > 0) {
				transform.localScale = new Vector3 (-2, 2, 1);
				faceLeft = true;
			}
		}
	}

	IEnumerator BossStomp()
	{
		yield return new WaitForSeconds (1.86f);
		if (faceLeft && differenceX < 5.45f && differenceX > 4.05f
			&& differenceY < 5.48f && differenceY > 3.68) {
			player.GetComponent<Player> ().DamagePlayer (stompDamage);
		}
		if (!faceLeft && differenceX > -5.45f && differenceX < -4.05f
			&& differenceY < 5.48f && differenceY > 3.68) {
			player.GetComponent<Player> ().DamagePlayer (stompDamage);
		}
		AudioManager.instance.PlayBossWalking ();
		yield return new WaitForSeconds (0.67f);
		animator.SetBool ("isStomping", false);
		stomping = false;
		StartCoroutine (resetAttack (stompCooldown));
	}

	IEnumerator BossLaser()
	{
		yield return new WaitForSeconds (2.43f);
		if (faceLeft == true) {
			GameObject laser = Instantiate (laserPrefab, new Vector2 ((this.transform.position.x - 6.1f), this.transform.position.y-5.63f), this.transform.rotation) as GameObject;
			laser.GetComponent<LaserScript> ().damage = laserDamage;
			laser.GetComponent<LaserScript> ().laserLeft = faceLeft;
		} else {
			GameObject laser = Instantiate (laserPrefab, new Vector2 ((this.transform.position.x + 6.1f), this.transform.position.y-5.63f), this.transform.rotation) as GameObject;
			laser.GetComponent<LaserScript> ().damage = laserDamage;
			laser.GetComponent<LaserScript> ().laserLeft = faceLeft;
		}
		AudioManager.instance.PlayBossLaser ();
		yield return new WaitForSeconds (3.67f);
		animator.SetBool ("isShooting", false);
		shooting = false;
		StartCoroutine (resetAttack (laserCooldown));
	}

	IEnumerator resetAttack(float cooldown){
		yield return new WaitForSeconds(cooldown);
		canAttack = true;
	}


		
}
