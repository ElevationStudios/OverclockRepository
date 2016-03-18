using UnityEngine;
using System.Collections;

public class TestPistol : MonoBehaviour {

	public float baseDamage = 10;
	public int clipSize = 6;
	public int currentClip;
	public float reloadTime = 2;
	public float critPerc = 20f;
	public float critDmg = 1.5f;

	public LayerMask whatToHit;
	public Transform bulletPrefab;
	public Transform bulletSpawn;
	private LineRenderer lineRenderer;
	private bool reloading = false;
	
	void OnEnable() {
		lineRenderer = GetComponent<LineRenderer>();
		currentClip = clipSize;
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.R)) {
			Shoot ();
			/*
			if(currentClip > 0) {
				Shoot();
			}else{
				StartCoroutine(Reload());
			}
			*/
		} else if(Input.GetKeyDown(KeyCode.R) && currentClip != clipSize && !reloading) {
			StartCoroutine(Reload());
		}
	}

	/*
		
	void Update ()
	{
		if (Input.GetMouseButtonDown (0) && reloading == false) {
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

*/

	IEnumerator Reload() {
		reloading = true;
		yield return new WaitForSeconds (reloadTime);
		currentClip = clipSize;
		reloading = false;
	}

	void Shoot() {
		float critRNG = Random.value * 100;
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePosition = new Vector2 (bulletSpawn.position.x, bulletSpawn.position.y);

		lineRenderer.enabled = true;
		lineRenderer.SetPosition(0, firePosition);

		RaycastHit2D hit = Physics2D.Raycast (firePosition, (mousePosition - firePosition), Mathf.Infinity, whatToHit);
		float damage = critRNG < critPerc ? baseDamage * critDmg : baseDamage;
		currentClip--;
		if(currentClip == 0) {
			StartCoroutine(Reload());
			return;
		}
		// Draw line here
		/*
		if(hit.collider != null && hit.collider.CompareTag("Enemy")) {
			Debug.Log ("Hit something! Tag: " + hit.collider.tag + " Name: " + hit.collider.name);
			hit.collider.GetComponent<Enemies> ().TakeDamage (5f);
			lineRenderer.SetPosition(1, hit.point);	
		}
		*/
		if(hit.collider != null && hit.collider.CompareTag("Enemy")) {
			Debug.Log ("Hit something Tag: " + hit.collider.tag + " Name: " + hit.collider.name);
			hit.collider.GetComponent<Entity>().Damage(5f); // gun.GetDamage();
		}
	}
}