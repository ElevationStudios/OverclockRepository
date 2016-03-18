using UnityEngine;
using System.Collections;

public class WeaponShop : MonoBehaviour {
	bool nearShop = false;
	public GameObject textDisplay;
	public GameObject shopWindow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (nearShop == true && Input.GetKeyDown(KeyCode.T)){
			shopWindow.SetActive(true);
			
	}
}
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player"){
			nearShop = true;
			textDisplay.SetActive (true);
		}
		
}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player"){
			nearShop = false;
			textDisplay.SetActive (false);
		}

	}
}
