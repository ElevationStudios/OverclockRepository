using UnityEngine;
using System.Collections;

public class enemyBullScript : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D c)
	{
		if (c.gameObject.tag != "EnemyBullet" || c.gameObject.tag != "Player")
		{
			GameObject.Destroy (this.gameObject);
			if (c.gameObject.tag == "Player")
				Debug.Log ("hit player");
		}
	}
}
