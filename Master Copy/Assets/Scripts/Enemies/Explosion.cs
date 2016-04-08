using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float damage;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 1.39f);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Enemy") {
			col.GetComponent<Enemies> ().TakeDamage (damage);
		} else
		if (col.gameObject.tag == "Boss") {
			col.GetComponent<EnemyBoss> ().TakeDamage (damage);
		} else
		if (col.gameObject.tag == "EnemyBullet") {
			Destroy (col.gameObject);
		}
	}
}
