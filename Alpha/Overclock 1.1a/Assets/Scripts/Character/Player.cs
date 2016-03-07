﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField] private GameObject pistol;
	[SerializeField] private GameObject blaster;
	[SerializeField] private GameObject launcher;


	[System.Serializable]
	public class playerStats
	{
		public float currentHealth = 0;
		public float maxHealth = 100;
		public float armor = 0.0f;
		public int gold = 0;
		public int lives = 3;
		public float overclockMax = 100f;
		public float overclockCur = 100f;


		//	public float movementSpeed = 1.0f;
		//public float jumpHeight = 1.0f;
	}	
	public bool overclock = false;
	public float time = 0;
	public playerStats PlayerStats = new playerStats();

	public void DamagePlayer(float damage) 
	{
		PlayerStats.currentHealth -=  damage * (1.00f -(0.01f * PlayerStats.armor));
		if (PlayerStats.currentHealth <= 0) 
		{
			//gameMaster.killPlayer(this);
		}
	}
	public void ObtainGold(int amount)
	{
		PlayerStats.gold += amount;
	}
	void CheckInput(){
		Overclock ();
		WeaponSwitch ();
	}

	void WeaponSwitch(){

		if (Input.GetKeyDown(KeyCode.Alpha1)){
			pistol.SetActive(true);
			blaster.SetActive(false);
			launcher.SetActive (false);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2)){
			blaster.SetActive(true);
			pistol.SetActive(false);
			launcher.SetActive (false);
			}
		if (Input.GetKeyDown(KeyCode.Alpha3)){
			blaster.SetActive(false);
			pistol.SetActive(false);
			launcher.SetActive (true);
		}
			
	}
	void Overclock(){
		if (Input.GetKeyDown (KeyCode.E) && PlayerStats.overclockCur > 0) {
			overclock = true;
		}
		if 	(time > 5){

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
	}

	 void Update()
	{
		CheckInput ();
	}

	void Start()
{
		PlayerStats.currentHealth = PlayerStats.maxHealth;
}

}