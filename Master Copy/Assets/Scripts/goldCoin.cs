using UnityEngine;
using System.Collections;

public class goldCoin : MonoBehaviour 
{
	public AudioSource coinClip;
	GameObject player;
    public int goldAmount;


    void Awake(){
        player = GameObject.Find ("Carlos");
    }
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
            player.GetComponent<Player> ().ObtainGold (goldAmount);
			//coinClip.Play ();
			Destroy (gameObject);
		}
	}
}