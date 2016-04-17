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
        if (SceneManager.GetActiveScene().name == "Level1")
            textField.text = Localisation.GetString("Level1");
		if(SceneManager.GetActiveScene().name=="Level2") 
            textField.text = Localisation.GetString("Level2");
		if(SceneManager.GetActiveScene().name=="Rest Area") 
            textField.text = Localisation.GetString("RestArea");
	}
}