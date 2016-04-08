using UnityEngine;
using System.Collections;

public class BossAnimSound : MonoBehaviour {

	void stompSnd(){
		AudioManager.instance.PlayBossWalking ();
	}
}
