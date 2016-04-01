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
    public GameObject deathPrefab;
    public GameObject projectilePrefab;
    public GameObject coin;
    Color endColor = Color.yellow;
    Color startColor = Color.green;
    float val;

    Color fillColor;

    void Start()
    {
        this.currentHealth = maxHealth;
        if (projectilePrefab != null)
            projectilePrefab.GetComponent<enemyProjectile>().damage = damage;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage * (1.00f - (0.01f * armor));
    }

    void Death()
    {
        Destroy(gameObject);
        dropCoin();
        Instantiate(deathPrefab, transform.position, transform.rotation);

    }

    void dropCoin()
    {
        GameObject droppedCoin = (GameObject) Instantiate(coin, transform.position, transform.rotation);
        droppedCoin.GetComponent<goldCoin>().goldAmount = gold;
    }

    void Update()
    {
        val = maxHealth / 2;
        if (currentHealth / maxHealth <= 0.5)
        {
            val = 0;
            endColor = Color.red;
            startColor = Color.yellow;

        }
        if (currentHealth <= 0)
            Death();
        float moveBar = (1 - currentHealth / maxHealth) * (2.3f / 2);
        enemyHPFill.transform.localScale = new Vector2(currentHealth / maxHealth, 1);
        enemyHPFill.transform.position = new Vector2(transform.position.x - moveBar, transform.position.y + 1);
        fillColor = Color.Lerp(endColor, startColor, (currentHealth - val) * 2 / maxHealth);
        enemyHPFill.GetComponent<SpriteRenderer>().color = fillColor; 
    }
}