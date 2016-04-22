using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;		
public class TitleLoad : MonoBehaviour {
	public GameObject player;
	//public Pause pause;

	void Awake()
	{
		this.enabled = false;
	}

	void Start()
	{
		player = GameObject.Find ("Carlos");
		//pause = GameObject.Find ("PauseHandler").GetComponent<Pause> ();
	}
	void OnEnable() 
	{
		Time.timeScale = 1;
		GameObject.Destroy (player);
		SceneManager.LoadScene("Title Screen");
	}
}