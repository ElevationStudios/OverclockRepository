using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

	private float damage;
	private float criticalChance;

	public Weapon(float damage, float critical){
		this.damage = damage;
		this.criticalChance = critical;
	}

	public void SetDamage(float damage){
		this.damage = damage;
	}

	public float GetDamage(){
		return damage;
	}

	public void SetCriticalChance(float critical){
		this.criticalChance = critical;
	}

	public float GetCriticalChance(){
		return criticalChance;
	}

	abstract public void UseWeapon();
}