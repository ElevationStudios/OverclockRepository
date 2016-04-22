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
    public int gold;
    public GameObject enemyHPFill;

	bool leftSide;
    public GameObject deathPrefab;
    public GameObject projectilePrefab;
    public GameObject coin;
    Color endColor = Color.yellow;
    Color startColor = Color.green;
    float val;
    float b;
    float c;
    Color fillColor;

	//AUDIO
	AudioManager audioManager;
	public AudioClip DeathSoundName;

    void Start()
	{
        b = enemyHPFill.GetComponent<SpriteRenderer>().bounds.size.x;
        c = b /2;
		audioManager = AudioManager.instance;
		this.currentHealth = maxHealth;
		//checking for ranged enemy scripts
		if (projectilePrefab.GetComponent<enemyProjectile>() != null) 
			projectilePrefab.GetComponent<enemyProjectile> ().dmg = damage;
		if (projectilePrefab.GetComponent<enemyTurretProjectile> () != null)
			projectilePrefab.GetComponent<enemyTurretProjectile> ().dmg = damage;
		//checking for melee enemy scripts
		if (projectilePrefab.GetComponent<enemyMelee> () != null)
			projectilePrefab.GetComponent<enemyMelee> ().dmg = damage;
		//the if statements are checking if the enemy is ranged or melee, and setting damage properties.
		
	}
    public void TakeDamage(float damage)
    {
        currentHealth -= damage * (1.00f - (0.01f * armor));
    }

    void Death()
    {
		audioManager.PlaySound (DeathSoundName);
		if (GameObject.FindGameObjectWithTag ("Player").transform.position.x > transform.position.x)
			leftSide = true;
        dropCoin();
		GameObject death = Instantiate(deathPrefab, transform.position, transform.rotation) as GameObject;
		if (leftSide == true)
			death.transform.localScale = new Vector3 (
				-1 * death.transform.localScale.x, 
					 death.transform.localScale.y, 
					 death.transform.localScale.z);
		Destroy (death.gameObject, 3.0f);
		Destroy(gameObject);

    }

    void dropCoin()
    {
        GameObject droppedCoin = (GameObject) Instantiate(coin, transform.position, transform.rotation);
        droppedCoin.GetComponent<goldCoin>().goldAmount = gold;
    }

    void Update()
    {
        Debug.Log(b);
        val = maxHealth / 2;
        if (currentHealth / maxHealth <= 0.5)
        {
            val = 0;
            endColor = Color.red;
            startColor = Color.yellow;

        }
        if (currentHealth <= 0)
            Death();
        float moveBar = (1 - currentHealth / maxHealth) * (c);
		enemyHPFill.transform.localScale = new Vector2(currentHealth / maxHealth, 1);
		enemyHPFill.transform.position = new Vector2(transform.position.x - moveBar, enemyHPFill.transform.parent.transform.position.y);
        fillColor = Color.Lerp(endColor, startColor, (currentHealth - val) * 2 / maxHealth);
        enemyHPFill.GetComponent<SpriteRenderer>().color = fillColor; 
    }
}