using UnityEngine;
using System.Collections;

public class enemyTurretProjectile : MonoBehaviour {

	public float dmg;
	public float bullSpeed;


	void Update(){

		transform.Translate(Vector3.right*bullSpeed*Time.deltaTime);
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag != "EnemyBullet" && col.gameObject.tag != "Enemy" && col.gameObject.tag != "Untagged")
		{
			if (col.gameObject.tag == "Player")
				col.gameObject.GetComponent<Player> ().DamagePlayer (dmg);

			GameObject.Destroy (this.gameObject);

		}
	}
}
