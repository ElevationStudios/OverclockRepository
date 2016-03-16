using UnityEngine;
using System.Collections;

public class DroneT2Enemy : MonoBehaviour {

	public GameObject drone;
	float timer = 0;
	public float spawnTime = 3;

	float xOffset;
	float yOffset;
	float leftRight;
	private Transform target;

	private GameObject player;


	public GameObject bulletPrefab;
	private GameObject bullInst;
	private bool canShoot = true;
	private Transform gunPivot;
	private Transform bulletSpawn;
	[SerializeField] private float bullSpeed;
	[SerializeField] private float waitTime;
	private Vector3 dir;

	public float detectRange = 15;
	private bool aggro;
	private Transform droneSpawn;
	private bool leftSide = false;
	private bool rightSide = false;
	private bool flipped = false;

	public Enemies stats;

	void Awake(){
		leftRight = Random.value;
		xOffset = 3.5f + Random.value * 6;
		yOffset = 3.2f + Random.value * 2;
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform;
		gunPivot = this.transform.GetChild (1).transform;
		bulletSpawn = this.transform.GetChild(1).GetChild(1).transform;

		leftRight = Random.value / 2 + 0.8f;
		droneSpawn = transform.GetChild (1).transform;
	}

	void Update () {

		if (player.transform.position.x > transform.position.x) {
			leftSide = true;
			rightSide = false;
		} else if (player.transform.position.x < transform.position.x) {
			leftSide = false;
			rightSide = true;
		}

		if (leftSide == true && flipped == false) {
			this.transform.localScale = new Vector3 (-1, 1, 1);
			flipped = true;
			xOffset *= -1;
		} else if (rightSide == true && flipped == true) {
			this.transform.localScale = new Vector3 (1, 1, 1);
			flipped = false;
			xOffset *= -1;
		}


		checkRange ();
		if (aggro == true) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (target.transform.position.x + xOffset, 
				target.transform.position.y + yOffset, 
				target.transform.position.z), Time.deltaTime * leftRight);
			timer += Time.deltaTime;
			if (timer > spawnTime) {
				Instantiate (drone, droneSpawn.position, transform.rotation);
				timer = 0;
			}

			if (canShoot == true)
				StartCoroutine ("shooter");
		}
	}

	void checkRange (){
		if (Vector3.Distance (transform.position, player.transform.position) < detectRange)
			aggro = true;
	}
		


	IEnumerator shooter ()
	{	
		dir = target.position - transform.position;
		bullInst = GameObject.Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
		if (rightSide == true) {
			float bulletSize = bullInst.transform.localScale.x;
			bullInst.transform.localScale = new Vector3 (bulletSize, bulletSize, 1);

		} else if (leftSide == true) {
			float bulletSize = bullInst.transform.localScale.x;
			float rotZ = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			bullInst.transform.localScale = new Vector3 (-bulletSize, bulletSize, 1);
			/*bullInst.transform.localEulerAngles = new Vector3 (gunPivot.transform.rotation.eulerAngles.x,
				,
				gunPivot.transform.rotation.eulerAngles.z - 40f);*/

			bullInst.transform.rotation = Quaternion.Euler (gunPivot.transform.rotation.eulerAngles.x, gunPivot.transform.rotation.eulerAngles.y, rotZ);
		}
		bullInst.GetComponent<Rigidbody2D> ().velocity = dir.normalized * bullSpeed;
		canShoot = false;
		GameObject.Destroy (bullInst, 10);

		yield return new WaitForSeconds (waitTime);

		canShoot = true;
	
	}

}
