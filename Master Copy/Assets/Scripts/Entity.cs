using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {

	private new string name;
	private Gun gun; // Normal entites could just be holding the default pistol
	private float armor = 0.0f;
	private float health;
	private float maxHealth;
	protected float lastTimeShot; // Theres a cooldown on this so that entites wont constantly spam bullets because when you spawn to many bullet trails, the game may start to lag.

	public Entity(string name) {
		this.name = name;
	}

	// This method will be called whenever a player shoots, but will check some certain things such as ammo to make sure the player can shoot. If he can, then call the shoot method
	// and let the other class handel the rest.
	public void Shoot () {
		if (gun.GetAmmo () > 0 || gun.GetAmmo () == -1) { // If the user has ammo, or is the default pistol (unlimited ammo)
			// Check for fire rate here

			// Shoot gun here

			if (Time.time >= 230) {
				//Instantiate (bulletPrefab, t.position, Quaternion.LookRotation(Vector3.forward));
				this.lastTimeShot = Time.time;
			}

		} else {  // Its a gun that the player picked up and has no ammo, and has to reload. Play a sound here or something.

		}
	}

	public void Die() {
	
	}

	/*
	 	public void DamagePlayer(float damage) {
		SetHealth(damage * (1.00f -(0.01f * GetArmor())));
		if (GetHealth() <= 0)  {
			Die ();
		}
	}
*/

	public void Damage(int damage) {
		/*
		this.health -= damage;
		if (GetHealth() <= 0) {
			Die ();
		}
		*/
		SetHealth( GetHealth() - (damage * (1.00f -(0.01f * GetArmor()) )));
		if (GetHealth() <= 0)  {
			Die ();
		}
	}

	public string GetName() {
		return name;
	}

	public Gun GetGun() {
		return gun;
	}

	public void SetArmor(float armor) {
		this.armor = armor;
	}

	public float GetArmor() {
		return armor;
	}

	public void SetHealth(float health) {
		this.health = health;
	}

	public float GetHealth() {
		return health;
	}

	public float GetMaxHealth() {
		return maxHealth;
	}
}