using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClipAmmo : MonoBehaviour {

	[SerializeField] private Text ammoDisplay;
	GameObject player;
	GameObject pistol;
	GameObject blaster;
	GameObject launcher;
	private int currentClip;
	private int clipSize;
	// Use this for initialization
	void Start () {
		ammoDisplay = GetComponent<Text>();
		player = GameObject.Find ("Carlos");
		pistol = GameObject.Find ("Carlos/ArmPivot/ArmPistol");
		blaster = GameObject.Find ("Carlos/ArmPivot/ArmBlaster");
		launcher = GameObject.Find ("Carlos/ArmPivot/ArmGLauncher");


	}
	
	// Update is called once per frame
	void Update () {
		if (pistol.activeInHierarchy == true) {
			currentClip = pistol.GetComponent<PistolScript> ().currentClip;
			clipSize = pistol.GetComponent<PistolScript> ().clipSize;
		}
		if (blaster.activeInHierarchy == true) {
			currentClip = blaster.GetComponent<BlasterScript> ().currentClip;
			clipSize = blaster.GetComponent<BlasterScript> ().clipSize;
		}
		if (launcher.activeInHierarchy == true) {
			currentClip = launcher.GetComponent<GrenadeScript> ().currentClip;
			clipSize = launcher.GetComponent<GrenadeScript> ().clipSize;
		}

		ammoDisplay.text = currentClip.ToString () + "/" + clipSize.ToString ();
	}
}
