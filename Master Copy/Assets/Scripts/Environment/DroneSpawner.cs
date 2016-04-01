using UnityEngine;
using System.Collections;

public class DroneSpawner : MonoBehaviour {

	public GameObject drone;
	float timer = 0;
	public float spawnTime = 3;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > spawnTime) {
			Instantiate (drone, transform.position, transform.rotation);
			timer = 0;
		}

	}
}
