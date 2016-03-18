using UnityEngine;
using System.Collections;

// Convert to Entity
public class TurretTest : MonoBehaviour {

	// How long until the turret will go back into the defensive state when the user leaves the target area
	public float timeUntilIdle = 5;

	// Turrets bullet prefab to fire.
	public GameObject bulletPrefab;

	// Turrets projectile spawn
	public Transform projectileSpawn;

	// Turret body and head pivot game objects
	public GameObject turretHead;
	public GameObject turretBody;

	// All of the turrets audios sources to play all of the sound effects
	/*
     * 0 = Startup
     * 1 = Shutdown
     * 2 = Shoot
     */
	public AudioSource[] turretAudio;

	// Turret body and head pivot animator components
	private Animator turretHeadAnimator;
	private Animator turretBodyAnimator;

	// The current target that the turret is trying to target 
	private GameObject currentTarget;

	// Notes:
	//    - Make sure to edit the animations
	//    - Make sure to add animation events with code

	// Using the Awake method otherwise this method would get called a bunch of times
	void Awake () {
		this.turretHeadAnimator = turretHead.GetComponent<Animator>();
		this.turretBodyAnimator = turretBody.GetComponent<Animator>();
		//turretHead.SetActive(false);
		// Might need to put this in its own script.
		AddAnimationEvent();

	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Z)) {
			Debug.Log("Play");
			turretHeadAnimator.SetBool("Active", true);
		}

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
		StartCoroutine("GoIdle");
	}

	void Shoot() {
		Instantiate(bulletPrefab, projectileSpawn.position, turretHead.transform.rotation);
	}

	IEnumerator GoIdle() {
		yield return new WaitForSeconds(timeUntilIdle);
		turretHead.SetActive(false);
		turretAudio[1].Play();
		turretBodyAnimator.SetBool("Active", false);
		turretBodyAnimator.SetTrigger("Shutdown");
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
}
/*
    void AddAnimationEvent() {
        animation["pickupthenpocket"].layer = 2;
        animation["pickupthenpocket"].wrapMode = WrapMode.Once;

        //This returns 0.999995
        Debug.Log("Length: " + animation["pickupthenpocket"].clip.length);

        var animationPickupEvent = new AnimationEvent();
        animationPickupEvent.functionName = "RunPickupLogic";
        animationPickupEvent.time = 0.0;

        animation["pickupthenpocket"].clip.AddEvent(animationPickupEvent);


    }
    */