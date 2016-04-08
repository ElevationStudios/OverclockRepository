using UnityEngine;
using System.Collections;

public class GrenadeScript : MonoBehaviour
{

	public float fireRate = 0;
	public float baseDamage;
	public GameObject grenadePrefab;
	public Transform grenadeSpawn;
	public float reloadTime = 3;
	public int currentClip;
	public int clipSize = 1;
	public float critPerc = 10f;
	public float critDmg = 7.5f;
	bool reloading = false;
	float timer = 0;

	AudioManager audioManager;

	void Start ()
	{

		audioManager = AudioManager.instance;
		currentClip = clipSize;
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
	}


	IEnumerator Reload ()
	{
		audioManager.PlayReloadGLaunch();
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
		audioManager.PlayGangsterLauncher ();
		GameObject grenade = Instantiate (grenadePrefab, grenadeSpawn.position, grenadeSpawn.rotation) as GameObject;
		grenade.GetComponent<GrenadeProjectile> ().damage = baseDamage;
	}

}