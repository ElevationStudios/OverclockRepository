using UnityEngine;
using System.Collections;

public class enemyMelee : MonoBehaviour {
	public float dmg;
	AudioManager audioManager;
	void Start(){
		audioManager = AudioManager.instance;
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		if (c.gameObject.tag != "EnemyBullet" && c.gameObject.tag != "Enemy" && c.gameObject.tag != "Terrain") {
			if (c.gameObject.tag == "Player" && c.gameObject.GetComponent<Player> () != null)
				audioManager.PlayChainsaw();
				c.gameObject.GetComponent<Player> ().DamagePlayer (dmg);

		}
	}
}
