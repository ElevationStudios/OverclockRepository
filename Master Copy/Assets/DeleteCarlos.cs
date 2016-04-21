using UnityEngine;
using System.Collections;

public class DeleteCarlos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("Carlos") != null) {
			Destroy (GameObject.Find ("Carlos"));
			Destroy (GameObject.Find ("Main Camera"));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
