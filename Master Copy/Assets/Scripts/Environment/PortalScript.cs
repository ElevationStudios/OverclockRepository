using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour {
	[SerializeField] private GameObject textDisplay;
	GameObject player; 
	[SerializeField] private GameObject camera;
	[SerializeField] private GameObject sceneMaster;
	private float timer = 0;

	private bool goToRestArea = false;
	private bool goToLevel1 = false;
	private bool goToLevel2 = false;
	private bool startTimer = false;
	private bool onTeleporter = false;
	// Use this for initialization
	void Awake() {
		player = GameObject.Find ("Carlos");
		DontDestroyOnLoad(player);
		DontDestroyOnLoad(camera);


		}
	void Start () {
		if (SceneManager.GetActiveScene ().name == "Rest Area") {
			player.transform.position = new Vector2 (18, -2);
		}
	}

	// Update is called once per frame
	void Update () {
			
		if (startTimer == true)
			timer += Time.deltaTime;
		if (onTeleporter == true) {
			if (SceneManager.GetActiveScene ().name == "Level1") {
				
				if (Input.GetKeyDown (KeyCode.T)) {
					Debug.Log ("Pressed T");
					goToRestArea = true;
					startTimer = true;
				}
					
				if (Input.GetKeyDown (KeyCode.Y)) {
					Debug.Log ("Pressed Y");
					goToLevel2 = true;
					startTimer = true;
				}
					
			}
			if (SceneManager.GetActiveScene ().name == "Rest Area") {
				if (Input.GetKeyDown (KeyCode.T)) {
					Debug.Log ("Pressed T");
					goToLevel1 = true;
					startTimer = true;
				}
				if (Input.GetKeyDown (KeyCode.Y)) {
					Debug.Log ("Pressed Y");
					goToLevel2 = true;
					startTimer = true;
				}
			}
		}
			
		if (timer >= 2 && goToRestArea == true)
			SceneManager.LoadScene ("Rest Area");
		if (timer >= 2 && goToLevel2 == true)
			SceneManager.LoadScene ("Level2");
		if (timer >= 2 && goToLevel1 == true)
			SceneManager.LoadScene ("Level1");



	}
		
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			onTeleporter = true;
			textDisplay.SetActive (true);
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			onTeleporter = false;
			textDisplay.SetActive (false);
		}
	}
}