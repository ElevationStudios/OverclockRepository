using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

	private string name;
	private float damage;
	private float criticalChance;

	// TODO: Find out what to do with the critical chance attack. (Use math)

	public Weapon(string name, float damage, float critical){
		this.name = name;
		this.damage = damage;
		this.criticalChance = critical;
	}

	public void SetName(string name){
		this.name = name;
	}

	public string GetName(){
		return name;
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