using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemies : MonoBehaviour
{

	public float maxHealth = 100;
	public float currentHealth;
	public float armor;
	public float damage;
	public float drop;
	public GameObject enemyHPFill;
	public GameObject deathPrefab;
	public GameObject projectilePrefab;

	Color fillColor;

	void Start ()
	{
		this.currentHealth = maxHealth;
		if (projectilePrefab != null)
			projectilePrefab.GetComponent<enemyProjectile> ().damage = damage;
	}
	public void TakeDamage (float damage)
	{
		currentHealth -= damage * (1.00f - (0.01f * armor));
	}

	void Death ()
	{
		Destroy (gameObject);
		Instantiate (deathPrefab, transform.position, transform.rotation);
	}


	void Update ()
	{
		if (currentHealth <= 0)
			Death ();
		float moveBar = (1 - currentHealth / maxHealth) * (2.3f / 2);
		enemyHPFill.transform.localScale = new Vector2 (currentHealth / maxHealth, 1);
		enemyHPFill.transform.position = new Vector2 (transform.position.x - moveBar, transform.position.y + 1);
		fillColor = Color.Lerp (Color.red, Color.green, currentHealth / maxHealth);
		enemyHPFill.GetComponent<SpriteRenderer> ().color = fillColor; 
	}
}