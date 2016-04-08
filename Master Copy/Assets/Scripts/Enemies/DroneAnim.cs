using UnityEngine;
using System.Collections;

public class DroneAnim : MonoBehaviour {	
	// Use this for initialization
	void Start () {
		StartCoroutine (killSelf ());
	
	}

	IEnumerator killSelf(){
		yield return new WaitForSeconds (1.1f);
		Destroy (this.gameObject);
	}
}
