using UnityEngine;
using System.Collections;

public class goldCoin : MonoBehaviour 
{
	public AudioSource coinClip;
	bool coinObtained = false;
	public GameObject player;

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			player.GetComponent<Player> ().ObtainGold (20);
			coinObtained = true;
			coinClip.Play ();
			Destroy (gameObject);
		}
	}
}