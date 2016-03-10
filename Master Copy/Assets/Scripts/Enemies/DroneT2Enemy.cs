using UnityEngine;
using System.Collections;

public class DroneT2Enemy : MonoBehaviour {

	public GameObject drone;
	float timer = 0;
	public float spawnTime = 3;

	float xOffset;
	float yOffset;
	float leftRight;
	private Transform target;
	private GameObject player;

	public float detectRange = 15;
	private bool inRange;
	private Transform droneSpawn;
	private bool leftSide = false;
	private bool rightSide = false;
	private bool flipped = false;

	public Enemies stats;

	void Awake(){
		leftRight = Random.value;
		xOffset = 2.5f + Random.value * 6;
		yOffset = 2.2f + Random.value * 2;
	}

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform;
		leftRight = Random.value / 2 + 0.5f;
		droneSpawn = transform.GetChild (1).transform;
	}

	void Update () {
		if (stats.currentHealth < 0) {
			Destroy (this.gameObject);
		}

		if (player.transform.position.x > transform.position.x) {
			leftSide = true;
			rightSide = false;
		} else if (player.transform.position.x < transform.position.x) {
			leftSide = false;
			rightSide = true;
		}

		if (leftSide == true && flipped == false) {
			transform.Rotate (new Vector3 (0, 180, 0));
			flipped = true;
			xOffset *= -3;
		} else if (rightSide == true && flipped == true) {
			transform.Rotate (new Vector3 (0, 180, 0));
			flipped = false;
			xOffset *= -3;
		}

		checkRange ();
		if (inRange == true) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (target.transform.position.x + xOffset, 
				target.transform.position.y + yOffset, 
				target.transform.position.z), Time.deltaTime * leftRight);
			timer += Time.deltaTime;
			if (timer > spawnTime) {
				Instantiate (drone, droneSpawn.position, transform.rotation);
				timer = 0;
			}
		}
	}

	void checkRange (){
		if (Vector3.Distance (transform.position, player.transform.position) < detectRange) {
			inRange = true;
		} else {
			inRange = false;
		}
	}


}
