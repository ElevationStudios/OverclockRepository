using UnityEngine;
using System.Collections;

public class TurretAnim : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;

	void Shoot() {
		Instantiate (bulletPrefab, bulletSpawn.position, transform.rotation);
	}



	public void Play() {
		GetComponent<Animator> ().SetBool ("Active", true);
	}

	public void Stop() {
		GetComponent<Animator> ().SetBool ("Shutdown", true);
	}
}