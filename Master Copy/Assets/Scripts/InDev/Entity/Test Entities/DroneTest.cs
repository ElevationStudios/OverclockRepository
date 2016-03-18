using UnityEngine;
using System.Collections;

public class DroneTest : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform gunPivot;
	public Transform bulletSpawn;
	public float droneSpeed;
	public float timeBetweenShots;
	public float bulletSpeed;

	private GameObject player;
	private Animator animator;
	private float xOffset;
	private float yOffset;
	//
	private Vector3 dir;
	private bool rightSide = false;
	private bool flipped = false;
	private bool leftSide = false;
	//

	void Start() {
		this.animator = GetComponent<Animator>();
		this.xOffset = 1 + Random.value * 6;
		this.yOffset = 2 + Random.value * 2;
		this.player = GameObject.FindGameObjectWithTag("Player");
		StartCoroutine("Shoot");
	}

	void Update() {
		leftSide = player.transform.position.x > transform.position.x;
		this.transform.localScale = new Vector3((player.transform.position.x > transform.position.x ? -1 : 1), 1, 1);
		transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + xOffset, 
			player.transform.position.y + yOffset, player.transform.position.z), Time.deltaTime * droneSpeed);
	}

	IEnumerator Shoot() {
		yield return new WaitForSeconds(timeBetweenShots);
		GameObject bulllet = GameObject.Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
		
	}
	/*
	public override void Death() {
		animator.SetTrigger("Death");
	}
	*/
}

	/*
	IEnumerator shooter ()
	{	
		dir = player.transform.position - transform.position;
		GameObject bullInst = GameObject.Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
		if (rightSide == true) {
			float bulletSize = bullInst.transform.localScale.x;
			bullInst.transform.localScale = new Vector3 (bulletSize, bulletSize, 1);

		} else if (leftSide == true) {
			float bulletSize = bullInst.transform.localScale.x;
			float rotZ = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			bullInst.transform.localScale = new Vector3 (-bulletSize, bulletSize, 1);
			bullInst.transform.localEulerAngles = new Vector3 (gunPivot.transform.rotation.eulerAngles.x,
				,
				gunPivot.transform.rotation.eulerAngles.z - 40f);

			bullInst.transform.rotation = Quaternion.Euler (gunPivot.transform.rotation.eulerAngles.x, gunPivot.transform.rotation.eulerAngles.y, rotZ);
		}
		bullInst.GetComponent<Rigidbody2D> ().velocity = dir.normalized * bullSpeed;
		//canShoot = false;
		GameObject.Destroy (bullInst, 10);

		yield return new WaitForSeconds (timeBetweenShots);

		//canShoot = true;

	}

	void Update2() {
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


		transform.position = Vector3.Lerp(transform.position, new Vector3(player.transform.position.x + xOffset, 
			player.transform.position.y + yOffset, player.transform.position.z), Time.deltaTime * speed);

		dir = player.transform.position - transform.position;
;
	}

	void DroneDeath()
	{
		Instantiate (droneDestroy, this.transform.position, this.transform.rotation);
		Destroy (gameObject);
	}
	*/