using UnityEngine;
using System.Collections;

public class TurretAnimSound : MonoBehaviour {

	// Use this for initialization
	void playturretsnd(){
		AudioManager.instance.PlayTurretTransform ();
	}
}
