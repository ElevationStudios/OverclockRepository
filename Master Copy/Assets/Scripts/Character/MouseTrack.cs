using UnityEngine;
using System.Collections;

public class MouseTrack : MonoBehaviour {
	public GameObject graphics;
	private Vector2 charPos;
	private Vector2 mousePos;
	private float mouseX, charX;
	public Camera gameCamera;
	public Animator animator;

	void Start ()
	{
		gameCamera = Camera.main;
		animator.GetComponent<Animator> ();
	}

	void OnLevelWasLoaded(){
		gameCamera= Camera.main;
	}

	void Update () {
		Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		difference.Normalize ();

		float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, rotZ);

		charPos = this.transform.position;
		mousePos = Input.mousePosition;
		mousePos = gameCamera.ScreenToWorldPoint (mousePos);
		charX = charPos.x;
		mouseX = mousePos.x;

		if (mouseX < charX) 
		{
			graphics.transform.localScale = new Vector3 (-1, 1, 1);
			this.transform.localScale = new Vector3 (1, -1, 1);
		} 
		else 
		{
			graphics.transform.localScale = new Vector3 (1, 1, 1);
			this.transform.localScale = new Vector3 (1, 1, 1);
		}
	}
}
