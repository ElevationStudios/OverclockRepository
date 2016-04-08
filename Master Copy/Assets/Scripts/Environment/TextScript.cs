using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TextScript : MonoBehaviour {
	public string layer;
	public TextMesh textField;
	// Use this for initialization
	void Start () {
		textField = this.GetComponent <TextMesh> ();
		GetComponent<Renderer>().sortingLayerName = layer;
		if(SceneManager.GetActiveScene().name=="Level1") 
			textField.text = "Press 'T' to teleport to Rest Area\n Press 'Y' to teleport to Level 2";
		if(SceneManager.GetActiveScene().name=="Level2") 
			textField.text = "Press 'T' to teleport to Rest Area\n Press 'Y' to teleport to Level 1";
		if(SceneManager.GetActiveScene().name=="Rest Area") 
			textField.text = "Press 'T' to teleport to Level 1 \n Press 'Y' to teleport to Level 2";
	}


	// Update is called once per frame
	void Update () {
		
	}
}
