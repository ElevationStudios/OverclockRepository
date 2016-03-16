using UnityEngine;
using System.Collections;

public class TurretEnemy : MonoBehaviour {

	public GameObject pivot;
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public float timeUntilIdle = 15;
	public float fireRate = 2;
	private TurretAnim turretAnim;
	private Animator pivotAnimator;
	private Animator turretAnimator;
	private SpriteRenderer pivotSpriteRenderer;
	private GameObject target;
	private float nextFire = 0;

	void Start () {
		turretAnimator = GetComponent<Animator>();
		pivotAnimator = pivot.transform.GetChild(1).GetComponent<Animator>();
		pivotSpriteRenderer = pivot.transform.GetChild(1).GetComponent<SpriteRenderer>();
		pivot.SetActive(false);
		turretAnim = pivot.transform.GetChild(1).GetComponent<TurretAnim> ();
	}

	void FixedUpdate () {
		if (target != null) {
			Vector3 dir = target.transform.position - pivot.transform.position;
			float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
			pivot.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

			if (target.transform.position.x < transform.position.x) {
				pivot.transform.localScale = new Vector3 (1, -1, 1);
			} else if (target.transform.position.x > transform.position.x) {
				pivot.transform.localScale = new Vector3 (1, 1, 1);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag.Equals ("Player")) {
			target = other.gameObject;
			turretAnimator.SetBool ("Setup", true);
			StartCoroutine (DisableSetup ());
			//StopCoroutine (GoIdle());
		}
	}
		
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag.Equals ("Player")) {
			target = null;
			StartCoroutine (GoIdle());
		}
	}

	IEnumerator DisableSetup() {
		yield return new WaitForSeconds (4);
		turretAnimator.SetBool ("Setup", false);
	}

	IEnumerator GoIdle() {
		turretAnimator.SetBool ("Shutdown", true);
		yield return new WaitForSeconds (timeUntilIdle);
		//turretAnim.Stop ();
		turretAnimator.SetBool ("Shutdown", false);
		Debug.Log ("Called");
		pivot.SetActive (false);
	}

	public void ShowPivot() {
		//pivotSpriteRenderer.enabled = true;
		pivot.SetActive(true);
		turretAnim.Play ();
	}
}