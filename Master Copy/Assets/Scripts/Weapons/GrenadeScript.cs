using UnityEngine;
using System.Collections;

public class GrenadeScript : MonoBehaviour {
	private float timer = 0;
	private Rigidbody2D rb;
	public GameObject explosionPrefab;
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rb.AddForce(transform.right * 100);
		transform.Rotate (Vector3.forward * 5000);
	}
	
	void Update () {
		timer += Time.deltaTime;
		if (timer < 0.5f)
			transform.Rotate (Vector3.forward * -20);
		if (timer > 3){
			DestoryGrenade ();
		}
	}
	void DestoryGrenade(){
		Destroy (gameObject);
		Instantiate (explosionPrefab, transform.position, transform.rotation);
	}
	void OnTriggerEnter2D(Collider2D col){
		Debug.Log ("hit " + col.gameObject.tag);
		if (col.gameObject.tag == "Enemy")
			DestoryGrenade ();
	}
}