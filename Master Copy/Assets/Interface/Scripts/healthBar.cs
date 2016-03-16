using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthBar : MonoBehaviour 
{
	GameObject player;
	public Image HPFill;

	void Start () {
		player = GameObject.Find ("Carlos");	
	}

	void Update () 
	{
		HPFill.fillAmount = player.GetComponent<Player> ().currentHealth / player.GetComponent<Player>().maxHealth;
	}
}
