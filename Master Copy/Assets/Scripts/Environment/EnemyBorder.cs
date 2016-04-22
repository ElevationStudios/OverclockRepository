using UnityEngine;
using System.Collections;

public class EnemyBorder : MonoBehaviour {

	// Use this for initialization
    void OnTriggerEnter2D(Collider2D col){
		Destroy (col.gameObject);
	}
}
