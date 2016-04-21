using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour {
	[SerializeField] private Text time;
	public int min;		
	public int sec;

	private float gameTime;
	void Start () {
		time = GetComponent<Text> ();
		sec = 0;
	}
	

	void Update () {
		if (SceneManager.GetActiveScene ().name != "Rest Area") {
			gameTime += Time.deltaTime;

			if (sec >= 60) {
				sec = 0;
				min += 1;
			}
			if (min < 9)
				time.text = "0" + min.ToString ();
			else
				time.text = min.ToString ();

			if (gameTime >= 1) {
				sec += 1;
				gameTime = 0;
			}
			if (sec < 10)
				time.text += ":" + "0" + sec.ToString ();
			else
				time.text += ":" + sec.ToString ();
		
		}
	}

	public void ResetTime()
	{
		sec = 0;
		min = 0;
	}
}
