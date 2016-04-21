using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;		

public class LoadLevel : MonoBehaviour 
{
	public TimeScript time;
	void Awake()
	{
		this.enabled = false;
	}
	void OnLevelWasLoaded()
	{
		time = GameObject.Find ("Main Camera/Canvas/TimeDisplay").GetComponent<TimeScript> ();
	}

	public void OnEnable() 
	{
		if (GameObject.Find ("Carlos") != null) 
			time.ResetTime ();
		
				
		SceneManager.LoadScene("Level1");
	}
}