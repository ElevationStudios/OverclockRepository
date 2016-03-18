using UnityEngine;
using System.Collections;

public class WeaponCrate : MonoBehaviour {

	void Start () {
		// Pick random weapon to drop or wahtever.
	}

	void OnCollisionTrigger2D(Collider2D col) {
		if(col.gameObject.CompareTag("Player")) {
			// Give player weapon
			Destroy(gameObject);
		}
	}
}