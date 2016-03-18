using UnityEngine;
using System.Collections;

public abstract class Gun : Weapon {

	// Change this to a new design.

	private int ammo;
	private int clipSize;
	private float fireRate;
	private bool projectile;
	private float reloadTime;
	private float lastShot;

	public Gun(string name, float damage, float critical, int clipSize, bool projectile, float fireRate, float reloadTime) : base(name, damage, critical) {
		this.ammo = clipSize;
		this.clipSize = clipSize;
		this.fireRate = fireRate;
		this.projectile = projectile;
		this.reloadTime = reloadTime;
		this.lastShot = 0f;
	}
		
	/*
	void Shoot(){
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePosition = new Vector2 (t.position.x, t.position.y);
		RaycastHit2D hit = Physics2D.Raycast(firePosition, (mousePosition - firePosition), 10, whatNotToHit);
		if (Time.time >= timeToShoot) {
			Instantiate (bulletPrefab, t.position, Quaternion.LookRotation(Vector3.forward));
			timeToShoot = Time.time;
		}

		if (hit.collider != null) {
			Debug.Log ("Hit " + hit.collider.name + " " + hit.collider.gameObject.tag);
			if (hit.collider.gameObject.tag == "Player") {
				Player p = hit.collider.GetComponent<Player> ();
				if (p != null) {
					Debug.Log ("Now it actually hit");
					p.DamagePlayer (10);
				}
			}
			Debug.DrawLine (firePosition, hit.point, Color.red);
		}
	}
	*/

	public void SetAmmo(int ammo) {
		this.ammo = ammo;
	}

	public int GetAmmo() {
		return ammo;
	}

	public int GetClipSize() {
		return clipSize;
	}

	public float GetFireRate() {
		return fireRate;
	}

	public bool isProjectile() {
		return projectile;
	}

	public override void UseWeapon() {
		if(GetAmmo () != 0) { // -1 means unlimited ammo. This is for the AI.
			if(Time.time > lastShot) {
				// If its a projectile weapon, just fire a raycast like a normal gun, else let the class handle the rest with the projectile.
				if(isProjectile()) {
					Shoot(); // Let the seperate class handle the projectile
				} else {
					// Raycast here
					// We will do the raycast effect here
				}
				ammo--;
				lastShot = Time.time + fireRate;
			}
		} else {
			// Reload
			// Make sure to check if the user switches weapons while reloading.
		}
	}

	IEnumerator Reload() {
		yield return new WaitForSeconds(reloadTime);
		SetAmmo(clipSize);
	}

	public override string ToString () {
		return "Name: " + GetName() + ", Damage: " + GetDamage() + ", Critical Chance: " + GetCriticalChance() + ", Ammo: " + GetAmmo() + ", Clip Size: " + GetClipSize() + ", Fire Rate: " + GetFireRate();
	}

	public abstract void Shoot();
}