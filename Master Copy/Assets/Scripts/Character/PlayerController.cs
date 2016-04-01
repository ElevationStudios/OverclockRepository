using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public float runSpeed;
	public float jumpheight;
	float moveVelocity;
	bool grounded;
	public Animator animator;
	public Transform playerGraphics;
	private float playerScaleX;
	private bool faceRight;
    bool running;
    bool canRun;
    bool regen;
	private int jumpCount;
    public float energyCur;
    public float energyMax;
    float energyTimer;

	void Start()
	{
        energyCur = energyMax;
		animator.GetComponent<Animator> ();
		playerGraphics = transform.FindChild ("Sprite");
	}

	void Update ()
    {
        energyTimer += Time.deltaTime;
        playerScaleX = playerGraphics.localScale.x;

        if (playerScaleX == 1)
            faceRight = true;
        else
            faceRight = false;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            if (jumpCount == 1 && energyCur >= 5)
            {
                regen = false;
                energyCur -= 5;
                energyTimer = 0;
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpheight);
                animator.SetBool("doubleJumping", true);
                animator.SetBool("isJumping", false);
                animator.SetBool("isFalling", false);
                jumpCount++;
            }
            else if (jumpCount == 0)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpheight);
                animator.SetBool("isJumping", true);
                animator.SetBool("isFalling", false);
                grounded = false;
                jumpCount++;
            } 

        }
        if (GetComponent<Rigidbody2D>().velocity.y < 0)
        {
            if (grounded == false)
            {
                animator.SetBool("doubleJumping", false);
                animator.SetBool("isFalling", true);
                animator.SetBool("isJumping", false);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            animator.SetBool("isWalking", true);
            if (faceRight == false)
                animator.SetBool("isBackwards", false);
            else
                animator.SetBool("isBackwards", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            animator.SetBool("isWalking", true);
            if (faceRight == true)
                animator.SetBool("isBackwards", false);
            else
                animator.SetBool("isBackwards", true);
        }


        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed / 2, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed / 2, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canRun)
        {
            speed = runSpeed;
            running = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 8;
            energyTimer = 0;
            running = false;
        }
        if (running)
        {
            energyCur -= 10 * Time.deltaTime;
            energyTimer = 0;

            if (energyCur >= 0)
                canRun = true;
            else
            {
                energyTimer = 0;
                canRun = false;
                speed = 8;
            }
            if (energyTimer > 2 && energyCur < energyMax)
                energyCur += 10 * Time.deltaTime;
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
