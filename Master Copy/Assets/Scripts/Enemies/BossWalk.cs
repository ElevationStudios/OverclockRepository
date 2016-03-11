using UnityEngine;
using System.Collections;

public class BossWalk : MonoBehaviour {
	
	private GameObject player;
	private Vector2 playerLoc;
	private Vector2 bossLoc;
	public Animator animator;
	private bool stomping;
	public float speed;
	public float sightRange;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerLoc = new Vector2 (player.transform.position.x, player.transform.position.y);
	}

	void Update () 
	{

		playerLoc.x = player.transform.position.x;
		playerLoc.y = player.transform.position.y;
		bossLoc.x = transform.position.x;
		bossLoc.y = transform.position.y;

		if (!stomping) 
		{
			if ((bossLoc.x - playerLoc.x) < sightRange && (bossLoc.x - playerLoc.x) > 0) 
			{
				animator.SetBool ("isWalking", true);
				transform.localScale = new Vector3 (-2, 2, 2);
				transform.position = Vector3.Lerp (transform.position, new Vector3 (playerLoc.x, playerLoc.y, 1), speed * Time.deltaTime);
			} 
			else if ((bossLoc.x - playerLoc.x) < 0 && (bossLoc.x - playerLoc.x) > -sightRange) 
			{
				animator.SetBool ("isWalking", true);
				transform.localScale = new Vector3 (2, 2, 2);
				transform.position = Vector3.Lerp (transform.position, new Vector3 (playerLoc.x, playerLoc.y, 1), speed * Time.deltaTime);
			}
			else
				animator.SetBool ("isWalking", false);
		}

		if ((bossLoc.x - playerLoc.x) < sightRange / 3 && (bossLoc.x - playerLoc.x) > -sightRange / 3) 
		{
			stomping = true;
			animator.SetBool ("isStomping", true);
			animator.SetBool ("isWalking", false);
		} 
		else 
		{
			animator.SetBool ("isStomping", false);
			stomping = false;
		}
	}
}
