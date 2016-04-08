using UnityEngine;
using System.Collections;



/// <summary>
/// this script is used for spawning enemies within a certain distance of the player
/// also reads the timer I suppose, idk
/// </summary>
public class EnemySpawner : MonoBehaviour {

	private float gameTime;
	private float sec;
	[SerializeField] private float secNeeded;
	//hero prefab
	private GameObject Player;
	//enemy prefabs
	[SerializeField] private float xDisplacement;
	[SerializeField] private float yDisplacement;

	private int numEnemies = 4; //this is the total list of non-boss enemies that can be spawned
	[SerializeField] private GameObject DroneT1;
	[SerializeField] private GameObject DroneT2;
	[SerializeField] private GameObject Turret;
	[SerializeField] private GameObject MeleeT1;

	private bool bossSpawned;
	[SerializeField] private GameObject Boss;

	[SerializeField] private Transform BossSpawnLocation;
	[SerializeField] private float enemyTimer;
	[SerializeField] private float spawnCooldown;

	//DroneT1s will spawn in groups
	[SerializeField] private int DroneT1Swarm;


	void Start () {
		Player = GameObject.FindGameObjectWithTag ("Player").gameObject;
		spawnCooldown = enemyTimer;
		bossSpawned = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		updateTimer ();
		spawnCooldown -= Time.deltaTime;




		randomEnemy ();
		if (sec >= secNeeded && bossSpawned == false) {
			spawnBoss ();
			enemyTimer += 15f;
		}
	}
	void updateTimer(){ //internal timer to keep track of when it will spawn boss
		gameTime += Time.deltaTime;
		if (gameTime >= 1) {
			sec += 1;
			gameTime = 0;
		}
	}

	void randomEnemy(){
		if (spawnCooldown <= 0){
			int choice = Random.Range (1, 5);
			spawnCooldown = enemyTimer;
			switch (choice) {
			case(1):
				spawnDroneT1 (Random.Range(1, DroneT1Swarm+1)); //spawns from 1 to max amount of dronet1
				Debug.Log ("spawned drone");
				break;
			case(2):
				spawnDroneT2 ();
				Debug.Log ("spawned dronet2");
				break;
			case(3):
				spawnTurret ();
				Debug.Log ("spawned turret");
				break;
			case(4):
				spawnMeleeT1 ();
				Debug.Log ("spawned meleet1");
				break;
			default:
				break;

			}
		}
	}
		
	void spawnDroneT1(int num){
		bool spawnRight;
		int leftOrRight = Random.Range (1, 3);
		if (leftOrRight == 1) {
			spawnRight = true;
			xDisplacement = Mathf.Abs (xDisplacement);
		} else {
			spawnRight = false;
			xDisplacement *= -1;
		}
		for (int i = 0; i < num; i++) {
			Vector3 droneLoc = new Vector3 (
				                   Player.transform.position.x + xDisplacement,
				                   Player.transform.position.y + yDisplacement,
				                   Player.transform.position.z);
			GameObject drone = Instantiate (DroneT1, droneLoc, Quaternion.Euler(0, 0, 0)) as GameObject;
		}

	}

	void spawnDroneT2(){
		bool spawnRight;
		int leftOrRight = Random.Range (1, 3);
		if (leftOrRight == 1) {
			spawnRight = true; //spawning at right side
			xDisplacement = Mathf.Abs (xDisplacement);
		} else {
			spawnRight = false; //spawning at left side
			xDisplacement *= -1;
		}
		Vector3 droneLoc = new Vector3 (
			Player.transform.position.x + xDisplacement,
			Player.transform.position.y + yDisplacement,
			Player.transform.position.z);
		GameObject drone = Instantiate (DroneT2, droneLoc,  Quaternion.Euler(0, 0, 0)) as GameObject;
	}

	void spawnTurret(){
		bool spawnRight;
		int leftOrRight = Random.Range (1, 3);
		if (leftOrRight == 1) {
			spawnRight = true; //spawning at right side
			xDisplacement = Mathf.Abs (xDisplacement);
		} else {
			spawnRight = false; //spawning at left side
			xDisplacement *= -1;
		}
		Vector3 turretLoc = new Vector3 (
			Player.transform.position.x + xDisplacement,
			Player.transform.position.y + 2,
			Player.transform.position.z);
		GameObject drone = Instantiate (Turret, turretLoc,  Quaternion.Euler(0, 0, 0)) as GameObject;
	}

	void spawnMeleeT1(){
		bool spawnRight;
		int leftOrRight = Random.Range (1, 3);
		if (leftOrRight == 1) {
			spawnRight = true; //spawning at right side
			xDisplacement = Mathf.Abs (xDisplacement);
		} else {
			spawnRight = false; //spawning at left side
			xDisplacement *= -1;
		}
		Vector3 newLoc = new Vector3 (
			Player.transform.position.x + xDisplacement,
			Player.transform.position.y + 2,
			Player.transform.position.z);
		GameObject drone = Instantiate (MeleeT1, newLoc,  Quaternion.Euler(0, 0, 0)) as GameObject;
	
	}

	void spawnBoss(){
		Debug.Log ("boss spawned");
		bossSpawned = true;
		Instantiate (Boss, BossSpawnLocation.position, Quaternion.Euler (0, 0, 0));
	}
}
