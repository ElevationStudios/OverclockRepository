using UnityEngine;
using System.Collections;

public class EnemyBorder : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter2D(Collision2D col){
		Destroy (col.gameObject);
	}
}
