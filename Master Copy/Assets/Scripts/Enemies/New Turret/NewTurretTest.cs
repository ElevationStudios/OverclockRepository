using UnityEngine;
using System.Collections;

public class NewTurretTest : MonoBehaviour {

    // Time until the turret will go into the idle state once the player leaves the activation range. (In seconds)
    public float timeUntilIdle = 5;

    // The amount of time the turret has to wait to fire another shot. (In secconds)
    public float fireRate = 3;

	// The speed in which the turret will rotate.
	public float rotateSpeed = 3f;

	// The turret body and head game objects.
	public GameObject turretPivot;
    public GameObject turretHead;
    public GameObject turretBody;

    // The players position. (Used for checking if the player enters/leaves the turrets radius)
    private Transform player;

    /*
     * All of the turrets audios sources to play all of the sound effects.
     * 0 = Startup
     * 1 = Shutdown
     */
    public AudioSource[] sounds;

    // Turret body and head pivot animator components

    private Animator headAnimator;
    private Animator bodyAnimator;

    // Turret body animation component
    private Animation bodyAnimation;

    // The Turret Head Helper script
    private TurretHeadHelper turretHeadHelper;

    // The last time the turret has shot.
    private float lastShot = 0;

	//detectionrange
	public float detectionRange;

	bool alerted;

    void Start() {
		this.turretPivot = turretPivot.gameObject;
        this.headAnimator = turretHead.GetComponent<Animator>();
        this.bodyAnimator = turretBody.GetComponent<Animator>();
        this.bodyAnimation = turretBody.GetComponent<Animation>();
        this.turretHeadHelper = turretHead.GetComponent<TurretHeadHelper>();
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        ShowHeadPiviot(false);
    }

    void Update() {
		// Slow down rotation speed by checking if a certain amount of time has passed.
		if (turretPivot.activeSelf && player != null) {
			Vector3 direction = player.position - turretPivot.transform.position;
			turretPivot.transform.rotation = Quaternion.AngleAxis (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);

			if (player.position.x < transform.position.x) {
				turretPivot.transform.localScale = new Vector3 (1, -1, 1);
			} else if (player.position.x > transform.position.x) {
				turretPivot.transform.localScale = new Vector3 (1, 1, 1);
			}
		}
        if (player != null && Time.time > lastShot) {
            headAnimator.SetTrigger("Shoot");
            lastShot = Time.time + fireRate;
        }
		if (Mathf.Abs (player.position.x - transform.position.x) < detectionRange
			&& alerted == false 
			&& player.position.y >= transform.position.y) {
			alerted = true;
			PlayerEnter ();
		}
		if (Mathf.Abs (player.position.x - transform.position.x) > detectionRange 
			&& alerted == true){
				alerted = false;
				PlayerLeave ();
		}
		if (player.position.y >= transform.position.y && alerted == true) {
			alerted = false;
			PlayerLeave ();
		}


    }

	void PlayerEnter() {
        bodyAnimator.SetBool("Active", true);
        //sounds[0].Play();
        StartCoroutine("ShowPiviot");
        StopCoroutine("GoIdle");
    }

    void PlayerLeave() {
        StartCoroutine("GoIdle");
    }

    IEnumerator ShowPiviot() {
        yield return new WaitForSeconds(4f);
        ShowHeadPiviot(true);
    }

    IEnumerator GoIdle() {
        yield return new WaitForSeconds(timeUntilIdle); 
        //sounds[1].Play();
        bodyAnimator.SetBool("Active", false);
        yield return new WaitForSeconds(0.5f); 
        ShowHeadPiviot(false);
    }  

    public void ShowHeadPiviot(bool active) {
        turretHead.SetActive(active);
    }
}

/*
// Convert to Entity
public class TurretTest : Entity {

    // How long until the turret will go back into the defensive state when the user leaves the target area
    public float timeUntilIdle = 5;

    // The distance the player has to be in order for the turret to activate
    public float activationDistance = 7;

    // Turrets projectile spawn
    public Transform projectileSpawn;

    // Turret body and head pivot game objects
    public GameObject turretHead;
    public GameObject turretBody;

    // All of the turrets audios sources to play all of the sound effects
    // 0 = Startup
    // 1 = Shutdown
    // 2 = Shoot
    public AudioSource[] turretAudio;

    // Turret body and head pivot animator components
    private Animator turretHeadAnimator;
    private Animator turretBodyAnimator;

    // The current target that the turret is trying to target 
    private GameObject currentTarget;

    public TurretTest() : base(20, 0, false) { }

    // Using the Awake method otherwise this method would get called a bunch of times
    void Awake () {
        this.turretHeadAnimator = turretHead.GetComponent<Animator>();
        this.turretBodyAnimator = turretBody.GetComponent<Animator>();
        turretHead.SetActive(false);
    }

    void Update () {
        // Check distance
        if (currentTarget != null && turretHead.activeSelf) {
            // Start to slowly rotate towars the player
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            PlayerEnter (other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            PlayerLeave();
        }
    }


    void PlayerEnter(GameObject player) {
        this.currentTarget = player;
        turretBodyAnimator.SetBool("Active", true);
        turretAudio[0].Play();
        StopCoroutine("GoIdle");
    }

    void PlayerLeave() {
        this.currentTarget = null;
        turretHeadAnimator.SetBool("Active", false);
        StartCoroutine("GoIdle");
    }

    IEnumerator GoIdle() {
        yield return new WaitForSeconds(timeUntilIdle);
        turretHead.SetActive(false);
        turretAudio[1].Play();
        turretBodyAnimator.SetBool("Active", false);
        turretBodyAnimator.SetTrigger("Shutdown");
    }

    public void ShowTurretHead() {
        turretHead.SetActive(true);
    }

    public override void Death() {

    }
}
    void AddAnimationEvent() {
        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.functionName = "Shoot";
        animationEvent.time = 0f;
        //turretAudio[2].Play()
        foreach(AnimationClip clip in turretHeadAnimator.runtimeAnimatorController.animationClips) {
            print(clip.name);
            clip.AddEvent(animationEvent);
            print("Event Size: " + clip.events.Length);
        }
    }

*/