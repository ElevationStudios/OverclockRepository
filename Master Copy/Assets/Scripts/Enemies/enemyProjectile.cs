using UnityEngine;
using System.Collections;

public class enemyProjectile : MonoBehaviour {

	public float damage;
	void OnCollisionEnter2D (Collision2D c)
	{
		if (c.gameObject.tag != "EnemyBullet" && c.gameObject.tag != "Enemy")
		{
			if (c.gameObject.tag == "Player")
				c.gameObject.GetComponent<Player> ().DamagePlayer (damage);
            
			GameObject.Destroy (this.gameObject);

		}
	}
}
