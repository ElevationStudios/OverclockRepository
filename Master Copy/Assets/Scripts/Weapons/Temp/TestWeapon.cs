using UnityEngine;
using System.Collections;

public class TestWeapon : MonoBehaviour
{

	public float fireRate = 0;
	public float damage = 10;
	public GameObject grenadePrefab;
	public Transform grenadeSpawn;
	public AudioSource shootClip;
	public float reloadTime = 5;
	public int ammoCount = 3;
	public int currentClip = 1;
	bool reloading = false;
	float timer = 0;

	void Start ()
	{
		currentClip = 1;
	}

	void OnEnable ()
	{
		reloading = false;
	}

	void Update ()
	{


		if (Input.GetMouseButtonDown (0) && !reloading) {
			if (currentClip > 0)
			Shoot ();
		else {
				StartCoroutine (Reload ());
			}
		}
		if (ammoCount == 0){
			gameObject.SetActive (false);
			//GameObject.Find(
		}
	}


	IEnumerator Reload ()
	{
		
		reloading = true;
		yield return new WaitForSeconds (reloadTime);
		Debug.Log ("Reloaded");
		reloading = false;
		currentClip = 1;
		StopCoroutine (Reload ());
	}

	void Shoot ()
	{
		currentClip--;
		ammoCount--;
		shootClip.Play ();
		Instantiate (grenadePrefab, grenadeSpawn.position, grenadeSpawn.rotation);
	}

}