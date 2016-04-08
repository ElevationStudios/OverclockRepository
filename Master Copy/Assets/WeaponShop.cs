using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponShop : MonoBehaviour
{


    GameObject player;
    Player playerGold;
    PistolScript pistolUpgrade;
	BlasterScript blasterUpgrade;
	GrenadeScript grenadeUpgrade;

    //Pistol Damage
    public Text pistolDamageLevelDisplay;
    public Text pistolDamageCurrentDisplay;
    public Text pistolDamageButtonDisplay;
    public Text pistolDamageCostDisplay;
    int pistolDamageCost = 100;
    int pistolDamageLevel = 1;

    //Pistol Reload
    public Text pistolReloadLevelDisplay;
    public Text pistolReloadCurrentDisplay;
    public Text pistolReloadButtonDisplay;
    public Text pistolReloadCostDisplay;
    int pistolReloadCost = 75;
    int pistolReloadLevel = 1;

    //Pistol Ammo
    public Text pistolClipLevelDisplay;
    public Text pistolClipCurrentDisplay;
    public Text pistolClipButtonDisplay;
    public Text pistolClipCostDisplay;
    int pistolClipCost = 75;
    int pistolClipLevel = 1;

    //Pistol Crit
    public Text pistolCritLevelDisplay;
    public Text pistolCritCurrentDisplay;
    public Text pistolCritButtonDisplay;
    public Text pistolCritCostDisplay;
    int pistolCritCost = 100;
    int pistolCritLevel = 1;


    //blaster Damage -------------------------------
    public Text blasterDamageLevelDisplay;
    public Text blasterDamageCurrentDisplay;
    public Text blasterDamageButtonDisplay;
    public Text blasterDamageCostDisplay;
    int blasterDamageCost = 100;
    int blasterDamageLevel = 1;

    //Blaster Reload
    public Text blasterReloadLevelDisplay;
    public Text blasterReloadCurrentDisplay;
    public Text blasterReloadButtonDisplay;
    public Text blasterReloadCostDisplay;
    int blasterReloadCost = 125;
    int blasterReloadLevel = 1;
    //Blaster Ammo
    public Text blasterClipLevelDisplay;
    public Text blasterClipCurrentDisplay;
    public Text blasterClipButtonDisplay;
    public Text blasterClipCostDisplay;
    int blasterClipCost = 75;
    int blasterClipLevel = 1;
    //Blaster Crit
    public Text blasterCritLevelDisplay;
    public Text blasterCritCurrentDisplay;
    public Text blasterCritButtonDisplay;
    public Text blasterCritCostDisplay;
    int blasterCritCost = 75;
    int blasterCritLevel = 1;


	//grenade Damage -------------------------------
	public Text grenadeDamageLevelDisplay;
	public Text grenadeDamageCurrentDisplay;
	public Text grenadeDamageButtonDisplay;
	public Text grenadeDamageCostDisplay;
	int grenadeDamageCost = 100;
	int grenadeDamageLevel = 1;

	//grenade Reload
	public Text grenadeReloadLevelDisplay;
	public Text grenadeReloadCurrentDisplay;
	public Text grenadeReloadButtonDisplay;
	public Text grenadeReloadCostDisplay;
	int grenadeReloadCost = 125;
	int grenadeReloadLevel = 1;
	//grenade Ammo
	public Text grenadeClipLevelDisplay;
	public Text grenadeClipCurrentDisplay;
	public Text grenadeClipButtonDisplay;
	public Text grenadeClipCostDisplay;
	int grenadeClipCost = 75;
	int grenadeClipLevel = 1;
	//grenade Crit
	public Text grenadeCritLevelDisplay;
	public Text grenadeCritCurrentDisplay;
	public Text grenadeCritButtonDisplay;
	public Text grenadeCritCostDisplay;
	int grenadeCritCost = 75;
	int grenadeCritLevel = 1;




    void Start()
    {
 

        player = GameObject.Find("Carlos");
        playerGold = player.GetComponent<Player>();
        pistolUpgrade = player.GetComponentInChildren<PistolScript>(true);
		blasterUpgrade = player.GetComponentInChildren<BlasterScript>(true);
		grenadeUpgrade = player.GetComponentInChildren<GrenadeScript>(true);
        PistolDamageUpdate();
        PistolReloadUpdate();
        PistolClipUpdate();
        PistolCritUpdate();
        BlasterDamageUpdate();
        BlasterReloadUpdate();
		BlasterClipUpdate();
		BlasterCritUpdate();
		grenadeDamageUpdate();
		grenadeReloadUpdate();
		grenadeClipUpdate();
		grenadeCritUpdate();



    }
	
    // Update is called once per frame
    void Update()
    {
        pistolDamageCurrentDisplay.text = "Current Damage: " + pistolUpgrade.baseDamage;
        pistolReloadCurrentDisplay.text = "Current Reload Time: " + pistolUpgrade.reloadTime  + "s";
        pistolClipCurrentDisplay.text = "Current Clip: " + pistolUpgrade.clipSize;
        pistolCritCurrentDisplay.text = "Current Crit: " + pistolUpgrade.critPerc + "%";

        blasterDamageCurrentDisplay.text = "Current Damage: " + blasterUpgrade.baseDamage;
        blasterReloadCurrentDisplay.text = "Current Reload Time: " + blasterUpgrade.reloadTime  + "s";
        blasterClipCurrentDisplay.text = "Current Clip: " + blasterUpgrade.clipSize;
        blasterCritCurrentDisplay.text = "Current Crit: " + blasterUpgrade.critPerc + "%";


		grenadeDamageCurrentDisplay.text = "Current Damage: " + grenadeUpgrade.baseDamage;
		grenadeReloadCurrentDisplay.text = "Current Reload Time: " + grenadeUpgrade.reloadTime  + "s";
		grenadeClipCurrentDisplay.text = "Current Clip: " + grenadeUpgrade.clipSize;
		grenadeCritCurrentDisplay.text = "Current Crit: " + grenadeUpgrade.critPerc + "%";
    }

    void PistolDamageUpdate()
    {
        if (pistolDamageLevel < 4)
        {
            pistolDamageLevelDisplay.text = "Pistol Damage Lv. " + pistolDamageLevel.ToString();
            pistolDamageCostDisplay.text = pistolDamageCost.ToString();
        }
        else
        {
            pistolDamageLevelDisplay.text = "Pistol Damage Level Maxed";
            pistolDamageButtonDisplay.text = "MAXED";
            pistolDamageCostDisplay.text = null;
        }
    }
    void PistolReloadUpdate()
    {
        if (pistolReloadLevel < 4)
        {
            pistolReloadLevelDisplay.text = "Pistol Reload Lv. " + pistolReloadLevel.ToString();
            pistolReloadCostDisplay.text = pistolReloadCost.ToString();
        }
        else
        {
            pistolReloadLevelDisplay.text = "Pistol Reload Level Maxed";
            pistolReloadButtonDisplay.text = "MAXED";
            pistolReloadCostDisplay.text = null;
        }
    }
    void PistolClipUpdate()
    {
        if (pistolClipLevel < 4)
        {
            pistolClipLevelDisplay.text = "Pistol Clip Lv. " + pistolClipLevel.ToString();
            pistolClipCostDisplay.text = pistolClipCost.ToString();
        }
        else
        {
            pistolClipLevelDisplay.text = "Pistol Clip Level Maxed";
            pistolClipButtonDisplay.text = "MAXED";
            pistolClipCostDisplay.text = null;
        }

    }
    void PistolCritUpdate()
    {
        if (pistolCritLevel < 4)
        {
            pistolCritLevelDisplay.text = "Pistol Crit Lv. " + pistolCritLevel.ToString();
            pistolCritCostDisplay.text = pistolCritCost.ToString();
        }
        else
        {
            pistolCritLevelDisplay.text = "Pistol Crit Level Maxed";
            pistolCritButtonDisplay.text = "MAXED";
            pistolCritCostDisplay.text = null;
        }

    }

    public void  PistolDamage()
    {
        if (playerGold.gold > pistolDamageCost && pistolDamageLevel < 4)
        {
            pistolUpgrade.baseDamage += 4;
            playerGold.SpendGold(pistolDamageCost);
            pistolDamageLevel++;
            pistolDamageCost *= 2;
             PistolDamageUpdate();
        }
    }

    public void  PistolReload()
    {
        if (playerGold.gold > pistolReloadCost && pistolReloadLevel < 4)
        {
            pistolUpgrade.reloadTime -= 0.3f;
            playerGold.SpendGold(pistolReloadCost);
            pistolReloadLevel++;
            pistolReloadCost *= 2;
             PistolReloadUpdate();
        }
    }
    public void  PistolClip()
    {
        if (playerGold.gold > pistolClipCost && pistolClipLevel < 4)
        {
            pistolUpgrade.clipSize += 2;
            playerGold.SpendGold(pistolClipCost);
            pistolClipLevel++;
            pistolClipCost *= 2;
             PistolClipUpdate();
        }
    }
    public void  PistolCrit()
    {
        if (playerGold.gold > pistolCritCost && pistolCritLevel < 4)
        {
            pistolUpgrade.critPerc += 5;
            playerGold.SpendGold(pistolCritCost);
            pistolCritLevel++;
            pistolCritCost *= 2;
            PistolCritUpdate();
        }
    }

    //Blaster =====================================================================================



    void  BlasterDamageUpdate()
    {
        if (blasterDamageLevel < 4)
        {
            blasterDamageLevelDisplay.text = " Blaster Damage Lv. " + blasterDamageLevel.ToString();
            blasterDamageCostDisplay.text = blasterDamageCost.ToString();
        }
        else
        {
            blasterDamageLevelDisplay.text = " Blaster Damage Level Maxed";
            blasterDamageButtonDisplay.text = "MAXED";
            blasterDamageCostDisplay.text = null;
        }
    }
    void  BlasterReloadUpdate()
    {
        if (blasterReloadLevel < 4)
        {
            blasterReloadLevelDisplay.text = " Blaster Reload Lv. " + blasterReloadLevel.ToString();
            blasterReloadCostDisplay.text = blasterReloadCost.ToString();
        }
        else
        {
            blasterReloadLevelDisplay.text = " Blaster Reload Level Maxed";
            blasterReloadButtonDisplay.text = "MAXED";
            blasterReloadCostDisplay.text = null;
        }
    }
    void  BlasterClipUpdate()
    {
        if (blasterClipLevel < 4)
        {
            blasterClipLevelDisplay.text = " Blaster Clip Lv. " + blasterClipLevel.ToString();
            blasterClipCostDisplay.text = blasterClipCost.ToString();
        }
        else
        {
            blasterClipLevelDisplay.text = " Blaster Clip Level Maxed";
            blasterClipButtonDisplay.text = "MAXED";
            blasterClipCostDisplay.text = null;
        }
    }
    void BlasterCritUpdate()
    {
        if (blasterCritLevel < 4)
        {
            blasterCritLevelDisplay.text = " Blaster Crit Lv. " + blasterCritLevel.ToString();
            blasterCritCostDisplay.text = blasterCritCost.ToString();
        }
        else
        {
            blasterCritLevelDisplay.text = " Blaster Crit Level Maxed";
            blasterCritButtonDisplay.text = "MAXED";
            blasterCritCostDisplay.text = null;
        }
    }

    public void  BlasterDamage()
    {
        if (playerGold.gold > blasterDamageCost && blasterDamageLevel < 4)
        {
            blasterUpgrade.baseDamage += 4;
            playerGold.SpendGold(blasterDamageCost);
            blasterDamageLevel++;
            blasterDamageCost *= 2;
             BlasterDamageUpdate();
        }
    }

    public void  BlasterReload()
    {
        if (playerGold.gold > blasterReloadCost && blasterReloadLevel < 4)
        {
            blasterUpgrade.reloadTime -= 0.3f;
            playerGold.SpendGold(blasterReloadCost);
            blasterReloadLevel++;
            blasterReloadCost *= 2;
             BlasterReloadUpdate();
        }
    }
    public void  BlasterClip()
    {
        if (playerGold.gold > blasterClipCost && blasterClipLevel < 4)
        {
            blasterUpgrade.clipSize += 6;
            playerGold.SpendGold(blasterClipCost);
            blasterClipLevel++;
            blasterClipCost *= 2;
            BlasterClipUpdate();
        }
    }
    public void  BlasterCrit()
    {
        if (playerGold.gold > blasterCritCost && blasterCritLevel < 4)
        {
            blasterUpgrade.critPerc += 8;
            playerGold.SpendGold(blasterClipCost);
            blasterCritLevel++;
            blasterCritCost *= 2;
            BlasterCritUpdate();
        }
    }

	//grenade =====================================================================================



	void  grenadeDamageUpdate()
	{
		if (grenadeDamageLevel < 4)
		{
			grenadeDamageLevelDisplay.text = " grenade Damage Lv. " + grenadeDamageLevel.ToString();
			grenadeDamageCostDisplay.text = grenadeDamageCost.ToString();
		}
		else
		{
			grenadeDamageLevelDisplay.text = " grenade Damage Level Maxed";
			grenadeDamageButtonDisplay.text = "MAXED";
			grenadeDamageCostDisplay.text = null;
		}
	}
	void  grenadeReloadUpdate()
	{
		if (grenadeReloadLevel < 4)
		{
			grenadeReloadLevelDisplay.text = " grenade Reload Lv. " + grenadeReloadLevel.ToString();
			grenadeReloadCostDisplay.text = grenadeReloadCost.ToString();
		}
		else
		{
			grenadeReloadLevelDisplay.text = " grenade Reload Level Maxed";
			grenadeReloadButtonDisplay.text = "MAXED";
			grenadeReloadCostDisplay.text = null;
		}
	}
	void  grenadeClipUpdate()
	{
		if (grenadeClipLevel < 4)
		{
			grenadeClipLevelDisplay.text = " grenade Clip Lv. " + grenadeClipLevel.ToString();
			grenadeClipCostDisplay.text = grenadeClipCost.ToString();
		}
		else
		{
			grenadeClipLevelDisplay.text = " grenade Clip Level Maxed";
			grenadeClipButtonDisplay.text = "MAXED";
			grenadeClipCostDisplay.text = null;
		}
	}
	void grenadeCritUpdate()
	{
		if (grenadeCritLevel < 4)
		{
			grenadeCritLevelDisplay.text = " grenade Crit Lv. " + grenadeCritLevel.ToString();
			grenadeCritCostDisplay.text = grenadeCritCost.ToString();
		}
		else
		{
			grenadeCritLevelDisplay.text = " grenade Crit Level Maxed";
			grenadeCritButtonDisplay.text = "MAXED";
			grenadeCritCostDisplay.text = null;
		}
	}

	public void  grenadeDamage()
	{
		Debug.Log ("hit gDamage button");
		if (playerGold.gold > grenadeDamageCost && grenadeDamageLevel < 4)
		{
			Debug.Log ("upgrade went through");
			grenadeUpgrade.baseDamage += 50;
			playerGold.SpendGold(grenadeDamageCost);
			grenadeDamageLevel++;
			grenadeDamageCost *= 2;
			grenadeDamageUpdate();
		}
	}

	public void  grenadeReload()
	{
		if (playerGold.gold > grenadeReloadCost && grenadeReloadLevel < 4)
		{
			grenadeUpgrade.reloadTime -= 0.5f;
			playerGold.SpendGold(grenadeReloadCost);
			grenadeReloadLevel++;
			grenadeReloadCost *= 2;
			grenadeReloadUpdate();
		}
	}
	public void  grenadeClip()
	{
		if (playerGold.gold > grenadeClipCost && grenadeClipLevel < 4)
		{
			grenadeUpgrade.clipSize += 1;
			playerGold.SpendGold(grenadeClipCost);
			grenadeClipLevel++;
			grenadeClipCost *= 2;
			grenadeClipUpdate();
		}
	}
	public void  grenadeCrit()
	{
		if (playerGold.gold > grenadeCritCost && grenadeCritLevel < 4)
		{
			grenadeUpgrade.critPerc += 2.5f;
			playerGold.SpendGold(grenadeClipCost);
			grenadeCritLevel++;
			grenadeCritCost *= 2;
			grenadeCritUpdate();
		}
	}
}
