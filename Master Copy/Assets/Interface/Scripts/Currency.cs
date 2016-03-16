using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Currency : MonoBehaviour {
	private Text coins;
	public GameObject player;


	void Start () {
		coins = this.GetComponent<Text>();
		player = GameObject.Find ("Carlos");
		player.GetComponent<Player>();
	}
	void Update() {
		coins.text = player.GetComponent<Player> ().gold.ToString ();
	}

}
