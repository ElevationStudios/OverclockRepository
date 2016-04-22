using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject pistol = null;
    [SerializeField] private GameObject blaster = null;
    [SerializeField] private GameObject launcher = null;

    public float currentHealth = 0;
    public float maxHealth = 1;
    public float armor = 0.0f;
    public int gold;
    public int lives = 3;
    //overclock goodies
    public float overclockMax = 100;
    public float overclockCur;
    bool overclock = false;
    public float time = 0;
    public Pause pause;
    bool canTakeDamage;
    bool respawned;
    Rigidbody2D bod;
    Animator animator;
    SpriteRenderer sr;
    SpriteRenderer srP;
    SpriteRenderer srB;
    SpriteRenderer srG;
    SpriteRenderer srPA;
    SpriteRenderer srBA;

    public static Player instance = null;

    void Awake()
    {
        gold = 2000;
        if (instance == null)
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
            GameObject.Destroy(gameObject);
    }

    void Start()
    {
        animator = GameObject.Find("Carlos/Sprite").GetComponent<Animator>();
        canTakeDamage = true;
        sr = GameObject.Find("Carlos/Sprite").GetComponent<SpriteRenderer>();
        srPA = GameObject.Find("Carlos/ArmPivot/ArmPistol").GetComponent<SpriteRenderer>();
        srBA = GameObject.Find("Carlos/ArmPivot/ArmBlaster").GetComponent<SpriteRenderer>();
        srG = GameObject.Find("Carlos/ArmPivot/ArmGLauncher").GetComponent<SpriteRenderer>();
        srP = GameObject.Find("Carlos/ArmPivot/ArmPistol/PistolSprite").GetComponent<SpriteRenderer>();
        srB = GameObject.Find("Carlos/ArmPivot/ArmBlaster/BlasterSprite").GetComponent<SpriteRenderer>();
        bod = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        overclockCur = overclockMax;
    }

    void OnLevelWasLoaded(int l)
    {
        if (respawned)
        {
            lives--;
            Respawn();
        }
        pause = GameObject.Find("PauseHandler").GetComponent<Pause>();
			
        if (l == 0)
            Destroy(gameObject);
    }
    void Respawn()
    {
        animator.SetBool("Respawn", false);
        currentHealth = maxHealth;
        overclockCur = maxHealth;
        canTakeDamage = true;
        pistol.SetActive(true);
        blaster.SetActive(false);
        launcher.SetActive(false);
        this.enabled = true;
        GetComponent<PlayerController>().enabled = true;
        GameObject.Find("Carlos/ArmPivot").GetComponent<MouseTrack>().enabled = true;
        animator.ResetTrigger("Death");
    }
    public void DamagePlayer(float damage)
    {
        if (canTakeDamage == true)
        { 
            currentHealth -= damage;
            canTakeDamage = false;
            if (currentHealth <= 0)
            {
                Death();
            }
            else
            {
                StartCoroutine(HitPlayer());
            }
        }
           
        if (currentHealth <= 0)
        {
            //gameMaster.killPlayer(this);
        }
    }

    IEnumerator HitPlayer()
    {
        sr.color =  new Color(1, 1, 1, .5f);
        srPA.color =  new Color(1, 1, 1, .5f);
        srBA.color =  new Color(1, 1, 1, .5f);
        srG.color =  new Color(1, 1, 1, .5f);
        srP.color =  new Color(1, 1, 1, .5f);
        srB.color =  new Color(1, 1, 1, .5f);
        bod.AddForce(transform.up * 6, ForceMode2D.Impulse);
        yield return new WaitForSeconds(2f);
        canTakeDamage = true;
        sr.color = new Color(1, 1, 1, 1);
        srP.color = new Color(1, 1, 1, 1);
        srB.color = new Color(1, 1, 1, 1);
        srG.color = new Color(1, 1, 1, 1);
        srPA.color =  new Color(1, 1, 1, .5f);
        srBA.color =  new Color(1, 1, 1, .5f);
    }
    public void ObtainGold(int amount)
    {
        gold += amount;
    }

    public void SpendGold(int amount)
    {
        gold -= amount;
    }

    void CheckInput()
    {
        Overclock();
        WeaponSwitch();
    }

    void WeaponSwitch()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pistol.SetActive(true);
            blaster.SetActive(false);
            launcher.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            blaster.SetActive(true);
            pistol.SetActive(false);
            launcher.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            blaster.SetActive(false);
            pistol.SetActive(false);
            launcher.SetActive(true);
        }
			
    }

    void Overclock()
    {
        if (Input.GetKeyDown(KeyCode.E) && overclockCur > 0)
        {
            overclock = true;
        }
        if (time > 5)
        {

            overclock = false;
            time = 0;
        }

        if (overclock == false && overclockCur < overclockMax)
        {
            overclockCur += 5 * Time.deltaTime;
            Time.timeScale = 1.0f;
        }
        if (overclock)
        {
            Time.timeScale = 0.7f;
            time += 1 * Time.deltaTime;
            overclockCur -= 10 * Time.deltaTime;
        }
    }
    void Death()
    {
        animator.SetTrigger("Death");
        canTakeDamage = false;
        pistol.SetActive(false);
        blaster.SetActive(false);
        launcher.SetActive(false);
        this.enabled = false;
        GetComponent<PlayerController>().enabled = false;
        GameObject.Find("Carlos/ArmPivot").GetComponent<MouseTrack>().enabled = false;
        StartCoroutine(LevelRestart());
    }
    IEnumerator LevelRestart()
    {
        respawned = true;
        yield return new WaitForSeconds(7f);
        if (lives == 0)
        {
            Destroy(GameObject.Find("Main Menu"));
            SceneManager.LoadScene(0);

        }
        else
        {
            animator.SetBool("Respawn", true);
            int l = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(l);

        }
    }

    void Update()
    {
        CheckInput();
    }
}