﻿using UnityEngine;
using System.Collections;

public class TurretHeadHelper : MonoBehaviour {

	private Transform target;
	public GameObject turretPivot;

    private GameObject projectile;

	public Transform projectileSpawn;
    public AudioSource shootSound;


	void Start() {
		target = GameObject.FindGameObjectWithTag ("Player").gameObject.transform;
		projectile = transform.parent.parent.gameObject.GetComponent<Enemies> ().projectilePrefab;
        shootSound = GetComponent<AudioSource>();
    }

    public void Shoot() {
        //shootSound.Play();
		Debug.Log ("shoot");



		Vector3 dir = target.position - transform.position;
		GameObject bullInst = GameObject.Instantiate (projectile, projectileSpawn.position, projectileSpawn.rotation) as GameObject;
		if (target.position.x < transform.position.x) {
			Debug.Log ("on left side");
			float bulletSize = bullInst.transform.localScale.x;
			bullInst.transform.localScale = new Vector3 (bulletSize, bulletSize, 1);
			//bullInst.GetComponent<Rigidbody2D> ().velocity = Vector2.left * bullSpeed;
		} else if (target.position.x > transform.position.x) {
			Debug.Log ("on right side");
			float bulletSize = bullInst.transform.localScale.x;
			float rotZ = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			bullInst.transform.localScale = new Vector3 (bulletSize, bulletSize, 1);
			/*bullInst.transform.localEulerAngles = new Vector3 (gunPivot.transform.rotation.eulerAngles.x,
				,
				gunPivot.transform.rotation.eulerAngles.z - 40f);*/
			bullInst.transform.rotation = Quaternion.Euler (
				turretPivot.transform.rotation.eulerAngles.x, 
				turretPivot.transform.rotation.eulerAngles.y, 
				turretPivot.transform.rotation.eulerAngles.z);
		}
		GameObject.Destroy (bullInst, 5);
    }
}