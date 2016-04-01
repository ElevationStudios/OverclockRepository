using UnityEngine;
using System.Collections;

public abstract class Gun : Weapon {

	private int ammo;
	private int clipSize;
	private float fireRate;

	public Gun(string name, float damage, float critical, int ammo, int clipSize, float fireRate) : base(name, 3.0f, 3.0f) {
		this.ammo = ammo;
		this.clipSize = clipSize;
		this.fireRate = fireRate;
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

	public void SetAmmo(int ammo){
		this.ammo = ammo;
	}

	public int GetAmmo(){
		return ammo;
	}

	public int GetClipSize(){
		return clipSize;
	}

	public float GetFireRate(){
		return fireRate;
	}

	public override string ToString () {
		return "Name: " + GetName() + ", Damage: " + GetDamage() + ", Critical Chance: " + GetCriticalChance() + ", Ammo: " + GetAmmo() + ", Clip Size: " + GetClipSize() + ", Fire Rate: " + GetFireRate();
	}
}