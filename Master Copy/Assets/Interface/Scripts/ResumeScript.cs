using UnityEngine;
using System.Collections;

public class ResumeScript : MonoBehaviour {
	public Pause pauseScript;

	void Awake()
	{
		this.enabled = false;
		pauseScript = GameObject.Find ("PauseHandler").GetComponent<Pause> ();
	}
	void OnEnable() 
	{
		pauseScript.unPause ();
	}
}
