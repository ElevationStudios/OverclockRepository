using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthBar : MonoBehaviour 
{
	GameObject player;
	public Image HPFill;
    public Image EnergyFill;

	void Start () {
		player = GameObject.Find ("Carlos");	
	}

	void Update () 
	{
		HPFill.fillAmount = player.GetComponent<Player> ().currentHealth / player.GetComponent<Player>().maxHealth;
        EnergyFill.fillAmount = player.GetComponent<PlayerController>().energyCur / player.GetComponent<PlayerController>().energyMax;
	}
}
