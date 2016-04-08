﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

	[SerializeField] private GameObject pistol = null;
    [SerializeField] private GameObject blaster = null;
    [SerializeField] private GameObject launcher = null;

	public float currentHealth = 0;
	public float maxHealth = 100;
	public float armor = 0.0f;
    public int gold;
	public int lives = 3;
    //overclock goodies
	public float overclockMax = 100;
    public float overclockCur;
    bool overclock = false;
    public float time = 0;

    static Player instance = null;

    void Awake(){
         gold = 2000;
        if (instance == null)
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else 
            GameObject.Destroy(gameObject);
    }
    void Start(){
        currentHealth = maxHealth;
        overclockCur = overclockMax;
    }
	public void DamagePlayer (float damage)
	{
		currentHealth -= damage * (1.00f - (0.01f * armor));
		if (currentHealth <= 0) {
			Debug.Log ("am dead");
		}
	}

	public void ObtainGold (int amount)
	{
		gold += amount;
	}

    public void SpendGold (int amount)
    {
        gold -= amount;
    }
	void CheckInput ()
	{
		Overclock ();
		WeaponSwitch ();
	}

	void WeaponSwitch ()
	{

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			pistol.SetActive (true);
			blaster.SetActive (false);
			launcher.SetActive (false);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			blaster.SetActive (true);
			pistol.SetActive (false);
			launcher.SetActive (false);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			blaster.SetActive (false);
			pistol.SetActive (false);
			launcher.SetActive (true);
		}
			
	}

	void Overclock ()
	{
		if (Input.GetKeyDown (KeyCode.E) && overclockCur > 0) {
			overclock = true;
		}
		if (time > 5) {

			overclock = false;
			time = 0;
		}

		if (overclock == false && overclockCur < overclockMax) {
			overclockCur += 5 * Time.deltaTime;
			Time.timeScale = 1.0f;
		}
		if (overclock) {
			Time.timeScale = 0.7f;
			time += 1 * Time.deltaTime;
			overclockCur -= 10 * Time.deltaTime;
		}
	}

	void Update ()
	{
		CheckInput ();
	}
}