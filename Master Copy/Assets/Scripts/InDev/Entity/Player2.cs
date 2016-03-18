using UnityEngine;
using System.Collections;

public class Player2 : Entity {

	public GameObject pistol;
	public GameObject blaster;
	public GameObject launcher;
	public bool overclock = false;
	public float time = 0;
	public PlayerStats stats = new PlayerStats();

	[System.Serializable]
	public class PlayerStats {
		public float currentHealth = 0;
		public float maxHealth = 100;
		public int gold = 0;
		public int lives = 3;
		public float overclockCur = 100f;
		public float overclockMax = 100f;
	}	
		
	//public Player2 (string name) : base(name) { }

	void Update() {
		Overclock();
		ControlPlayer();
	}

	void Start() {
		stats.currentHealth = stats.maxHealth;
	}

	public void ObtainGold(int amount) {
		stats.gold += amount;
	}

	void ControlPlayer(){
		// Pistol
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			pistol.SetActive(true);
			blaster.SetActive(false);
			launcher.SetActive (false);
		// Blaster
		} else if(Input.GetKeyDown(KeyCode.Alpha2)){
			blaster.SetActive(true);
			pistol.SetActive(false);
			launcher.SetActive (false);
		// Launcher
		}else if(Input.GetKeyDown(KeyCode.Alpha3)){
			launcher.SetActive (true);
			blaster.SetActive(false);
			pistol.SetActive(false);
		// Use Sword
		}else if(Input.GetMouseButtonDown(1)){
			UseSword();
		// Overclock
		} else if(Input.GetKeyDown(KeyCode.E) && stats.overclockCur > 0) {
			overclock = true;
		}
	}

	void Overclock() {
		if(overclock) {
			stats.overclockCur -= 10 * Time.deltaTime;
			if(Time.time > time || stats.overclockCur <= 0) {
				ToggleOverclock ();
			}
		}

		/*
		if(time > 5) {
			overclock = false;
			time = 0;
		}

		if (overclock == false && PlayerStats.overclockCur < PlayerStats.overclockMax) {
			PlayerStats.overclockCur += 5 * Time.deltaTime;
			Time.timeScale = 1.0f;
		}
		if (overclock) {
			Time.timeScale = 0.7f;
			time += 1 * Time.deltaTime;
			PlayerStats.overclockCur -= 10 * Time.deltaTime;
		}
		*/
	}

	void ToggleOverclock(){
		overclock = !overclock;
		if (overclock)
			Time.timeScale = 0.7f;
		else
			Time.timeScale = 1f;
	}

	void UseSword() {

	}

	public override void Death () {
		// Do game over screen
	}
}