using UnityEngine;
using System.Collections;

public class enemyMelee : MonoBehaviour {
	public float dmg;
	void Start(){
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.tag != "EnemyBullet" && c.gameObject.tag != "Enemy" && c.gameObject.tag != "Terrain") {
			if (c.gameObject.tag == "Player")
				c.gameObject.GetComponent<Player> ().DamagePlayer (dmg);

		}
	}
}
