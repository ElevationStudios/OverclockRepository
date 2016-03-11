using UnityEngine;
using System.Collections;
// Place this in the GunPivot component of the drone
public class droneTurretFollow : MonoBehaviour {

	private Vector2 targetPos;
	private Vector2 mousePos;
	private float targetX, charX;

	private Transform target;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 difference = target.position - transform.position;
		difference.Normalize ();

		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;

		if (target.position.x < transform.position.x) 
		{
			transform.rotation = Quaternion.Euler (0f, 0f, 180+rotZ);
		} 
		else 
		{
			transform.rotation = Quaternion.Euler (0f, 0f, -rotZ);
		}
	}
}
