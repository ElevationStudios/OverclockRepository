using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponShop : MonoBehaviour
{


    GameObject player;
    Player playerGold;

    //Pistol Damage
    public Text pistolDamageLevelDisplay;
    public Text pistolDamageCurrentDisplay;
    public Text pistolDamageButtonDisplay;
    public Text pistolDamageCostDisplay;
    float pistolDamage;
    int pistolDamageCost = 100;
    int pistolDamageLevel = 1;

    //Pistol Reload

    //Pistol Ammo
    void Start()
    {
        player = GameObject.Find("Carlos");
        playerGold = player.GetComponent<Player>();
        pistolDamage = player.GetComponentInChildren<PistolScript>(true).baseDamage;
    }
	
    // Update is called once per frame
    void Update()
    {
    }

    void PistolUpdate()
    {
        if (pistolDamageLevel < 4)
        {
            pistolDamageLevelDisplay.text = "Pistol Damage Lv. " + pistolDamageLevel.ToString();
            pistolDamageCostDisplay.text = pistolDamageCost.ToString();
        }
        else
        {
            pistolDamageLevelDisplay.text = "Pistol Damage Maxed";
            pistolDamageButtonDisplay.text = "MAXED";
            pistolDamageCostDisplay.text = null;
        }

        pistolDamageCurrentDisplay.text = "Current Damage: " + pistolDamage;
    }

    public void PistolDamage()
    {
        if (playerGold.gold > pistolDamageCost && pistolDamageLevel < 4)
        {
            pistolDamage += 4;
            playerGold.SpendGold(pistolDamageCost);
            pistolDamageLevel++;
            pistolDamageCost *= 2;
            PistolUpdate();
        }
    }
}
