using UnityEngine;
using System.Collections;

public class BlasterScript : MonoBehaviour
{

	public float baseDamage = 10;
	public int clipSize = 12;
	public int currentClip;
	public float reloadTime = 2.5f;
	public float critPerc = 20f;
	public float critDmg = 7.5f;
	private float damageOut;
	public float shootInterval = 0.2f;

	public LayerMask whatToHit;
	public GameObject bulletPrefab;
	public GameObject critPrefab;
	public Transform bulletSpawn;
	public GameObject shell;
	public Transform shellSpawner;
	GameObject bullet;
	public AudioSource blasterClip;
	private bool reloading;
	private float shootTimer;
	private float critRNG;
	//raycast goodies
	Vector2 firePosition;
	Vector2 mousePosition;


	void Awake ()
	{
		currentClip = clipSize;
	}

	void OnEnable ()
	{
		reloading = false;
	}

	void Update ()
	{
		shootTimer += Time.deltaTime;
		if (Input.GetMouseButton (0) && reloading == false) {
			if (currentClip > 0)
				Shoot ();
			else {
				StartCoroutine (Reload ());
				reloading = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.R) && currentClip != clipSize && reloading == false) {
			reloading = true;
			StartCoroutine (Reload ());
		}
	}

	IEnumerator Reload ()
	{
		yield return new WaitForSeconds (reloadTime);
		currentClip = clipSize;
		Debug.Log ("Reloaded");
		reloading = false;
		StopCoroutine (Reload ());
	}

	void Shoot ()
	{
		if (shootTimer > shootInterval) {
			blasterClip.Play ();
			critRNG = Random.value * 100;
			shootTimer = 0;
			mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);		
			firePosition = new Vector2 (bulletSpawn.position.x, bulletSpawn.position.y);
			RaycastHit2D hit = Physics2D.Raycast (firePosition, (mousePosition - firePosition), Mathf.Infinity, whatToHit);
			Instantiate (shell, shellSpawner.position, shellSpawner.rotation);

			if (critRNG < critPerc) {
				Instantiate (critPrefab, bulletSpawn.position, bulletSpawn.rotation);
				damageOut = baseDamage * critDmg;
			} else {
				damageOut = baseDamage;
				Instantiate (bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
			
			}
			currentClip--;
			if (currentClip == 0) {
				reloading = true;
				StartCoroutine (Reload ());
			}
			if (hit.collider != null && hit.collider.gameObject.tag == "Enemy") {
				hit.collider.GetComponent<Enemies> ().TakeDamage (damageOut);

			}
		}
		//Debug.DrawLine (firePosition, hit.point, Color.red);
	}
}