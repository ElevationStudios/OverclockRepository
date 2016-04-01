using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour {
	public float speed;
	public float jumpheight;
	float moveVelocity;
	bool grounded;
	public Animator animator;
	public Transform playerGraphics;
	private float playerScaleX;
	private bool faceRight;
	private int jumpCount;


	void start()
	{
		animator.GetComponent<Animator> ();
		playerGraphics = transform.FindChild ("Sprite");
	}

	void Update () 
	{
		playerScaleX = playerGraphics.localScale.x;

		if (playerScaleX == 1)
			faceRight = true;
		else
			faceRight = false;

		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.W)) 
		{
			if (jumpCount == 1) 
			{
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpheight);
				animator.SetBool ("doubleJumping", true);
				animator.SetBool ("isJumping", false);
				animator.SetBool ("isFalling", false);
				jumpCount++;
			}
			else if (jumpCount == 0) 
			{
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpheight);
				animator.SetBool ("isJumping", true);
				animator.SetBool ("isFalling", false);
				grounded = false;
				jumpCount++;
			} 

		}
		if (GetComponent<Rigidbody2D> ().velocity.y < 0) 
		{
			if (grounded == false) {
				animator.SetBool ("doubleJumping", false);
				animator.SetBool ("isFalling", true);
				animator.SetBool ("isJumping", false);
			}
		}

		if(Input.GetKey(KeyCode.A))
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-speed, GetComponent<Rigidbody2D> ().velocity.y);
			animator.SetBool ("isWalking", true);
			if (faceRight == false)
				animator.SetBool ("isBackwards", false);
			else
				animator.SetBool ("isBackwards", true);
		}
		if(Input.GetKey(KeyCode.D))
		{
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (speed, GetComponent<Rigidbody2D> ().velocity.y);
			animator.SetBool("isWalking", true);
			if (faceRight == true)
				animator.SetBool ("isBackwards", false);
			else
				animator.SetBool ("isBackwards", true);
		}
		if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D)) 
		{
			animator.SetBool ("isWalking", false);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Ground") 
		{
			animator.SetBool ("doubleJumping", false);
			animator.SetBool ("isFalling", false);
			animator.SetBool ("isJumping", false);
			grounded = true;
			jumpCount = 0;
		} 
	}

	void OnTriggerExit2D (Collider2D col)
	{
		grounded = false;
	}
}
