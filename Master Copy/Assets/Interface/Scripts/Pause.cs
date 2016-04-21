using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	public bool paused = false;
	public GameObject pauseMenu;
	private Camera gameCam;
	[SerializeField] private GameObject menuPrefab = null;

	void Start () {
		gameCam = Camera.main;
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (!paused)
				pause ();
			else
				unPause ();
		}
	}

	void pause()
	{
		paused = true;
		Time.timeScale = 0;
		pauseMenu = Instantiate (menuPrefab, gameCam.transform.position, gameCam.transform.rotation) as GameObject;
	}

	public void unPause()
	{
		paused = false;
		Destroy (pauseMenu);
		Time.timeScale = 1;
	}

}
