using UnityEngine;
using System.Collections;



public class DestroyBullet : MonoBehaviour
{
	[SerializeField] private int speed;
	float startPos;
	private float startTime;
	void Update ()
	{
		transform.Translate (Vector2.right * speed * Time.deltaTime);
		Destroy (gameObject, 3);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		Destroy (gameObject);
	}
}