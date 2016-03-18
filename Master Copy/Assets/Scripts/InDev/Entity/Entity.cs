using UnityEngine;
using System.Collections;

public abstract class Entity : MonoBehaviour {

	private Weapon weapon;
	private float armor;
	private float health;
	private float maxHealth;
	private bool dropWeaponCrate;

	// TODO: Test constructors 
	/*
	public Entity(float maxHealth, bool dropWeaponCrate) {
		this.maxHealth = maxHealth;
		this.dropWeaponCrate = dropWeaponCrate;
	}

	public Entity(float armor) : this(maxHealth, dropWeaponCrate) {
		this.armor = armor;
	}

	public Entity(Weapon weapon) : this(maxHealth, dropWeaponCrate, armor) {
		this.weapon = weapon;
	}
	*/

	public void SetWeapon(Weapon weapon) {
		this.weapon = weapon;
	}

	public Weapon GetWeapon() {
		return weapon;
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

	public bool CanDropWeaponCrate() {
		return dropWeaponCrate;
	}
		
	// TODO: Handle health bars accordingly
	void Update() {
		// TODO: Format (Add game objects and such)
		/*
		float moveBar = (1 - currentHealth / maxHealth) * (2.3f / 2);
		enemyHPFill.transform.localScale = new Vector2 (currentHealth / maxHealth, 1);
		enemyHPFill.transform.position = new Vector2 (transform.position.x - moveBar, transform.position.y + 1);
		fillColor = Color.Lerp (Color.red, Color.green, currentHealth / maxHealth);
		enemyHPFill.GetComponent<SpriteRenderer> ().color = fillColor; 
		*/
	}

	public void Damage(float damage) {
		SetHealth(GetHealth() - (damage * (1.00f - (0.01f * GetArmor()))));
		if(GetHealth() <= 0) {
			Die();
		}
	}

	/*
	 * Called whenever an entity dies.
	 * When this methid is called, it will first call the Death method to let the enetity class handle it's own death.
	 * Then if the killed entity is not a player, check if a wepaon crate should fall by chance, then lastly, destroy the game object.
	 */
	void Die() {
		Death();
		if(!gameObject.CompareTag("Player")) {
			if(CanDropWeaponCrate() && Random.value * 100 >= 80) {
				GameObject weaponCrate = Resources.Load("Weapon Crate") as GameObject; 
				Instantiate(weaponCrate, weaponCrate.transform.position, weaponCrate.transform.rotation); 
			}
			Destroy(gameObject);
		}
	}

	public abstract void Death();
}