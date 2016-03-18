using UnityEngine;
using System.Collections;

public class GoldCoin : MonoBehaviour {
	
	public AudioSource coinClip;
    public int goldAmount;

	void OnCollisionEnter2D(Collision2D col) {
		if (col.collider.CompareTag("Player")) {
			col.collider.GetComponent<Player>().ObtainGold(goldAmount);
			coinClip.Play();
			Destroy(gameObject);
		}
	}
}