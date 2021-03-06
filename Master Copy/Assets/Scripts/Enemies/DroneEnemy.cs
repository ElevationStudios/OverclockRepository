﻿using UnityEngine;
using System.Collections;

public class DroneEnemy : MonoBehaviour
{
	
	float xOffset;
	float yOffset;
	float leftRight;
	Transform target;
	GameObject player;
	private bool leftSide = false;
	private bool rightSide = false;
	private bool flipped = false;
	
	public GameObject bulletPrefab;
	private GameObject bullInst;
	private bool canShoot = true;
	private Transform gunPivot;
	[SerializeField] private float bullSpeed;
	[SerializeField] private float waitTime;
    [SerializeField] private Transform bulletSpawn;
	private Vector3 dir;

	//audio
	AudioManager audioManager;

	void Awake(){
		leftRight = Random.value;
		xOffset = 1 + Random.value * 6;
		yOffset = 2 + Random.value * 2;
	}
	void Start()
	{

		audioManager = AudioManager.instance;
		player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform;
		gunPivot = this.transform.GetChild (1).transform;
		leftRight = Random.value / 2 + 0.5f;
	}
	void Update ()
	{

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


		transform.position = Vector3.Lerp (transform.position, new Vector3 (target.transform.position.x + xOffset, 
			target.transform.position.y + yOffset, 
			target.transform.position.z), Time.deltaTime * leftRight);

		dir = target.position - transform.position;
		//rotateTurret ();
		if (canShoot == true)
            StartCoroutine (shooter());
	}
	IEnumerator shooter ()
	{	
		audioManager.PlayDroneShot ();
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