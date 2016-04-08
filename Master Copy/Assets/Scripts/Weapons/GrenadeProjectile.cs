using UnityEngine;
using System.Collections;

public class GrenadeProjectile : MonoBehaviour {
	private float timer = 0;
	private Rigidbody2D rb;
	public float damage;
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
			DestroyGrenade ();
		}
	}
	void DestroyGrenade(){
		Destroy (gameObject);
		GameObject explosion = Instantiate (explosionPrefab, transform.position, transform.rotation) as GameObject;
		explosion.GetComponent<Explosion> ().damage = damage;
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Boss")
			DestroyGrenade ();
	}
}