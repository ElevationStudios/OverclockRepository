using UnityEngine;
using System.Collections;

public class DroneSpawner : MonoBehaviour {

	public GameObject drone;
	public float spawnRate = 3;
	private float lastSpawn = 0;

	void Update () {
		if (Time.time > lastSpawn) {
			Instantiate (drone, transform.position, transform.rotation);
			lastSpawn = Time.time + spawnRate;
		}
	}
}