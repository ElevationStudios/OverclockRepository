using UnityEngine;
using System.Collections;

public class MeleeT1Move : MonoBehaviour
{
	int phase = 1;

	float jspeed;
	public float speed;
	public float xOffset;
	float dist;
	float jumpX;
	float jumpHeight = 10;
	public float slowdownPoint = 1;

	public float rotRate = 1.0f;
	float nextRot = 0.0f;

	Vector3 endPosition;
	Transform target;
	 public Transform rotPoint;
	GameObject player;
	
	private bool leftSide = false;
	private bool rightSide = false;
	public bool jumpTrigger;
	public bool grounded;

	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform;
		speed /= 50f;
		/*
		jumpHeight = speed * 60;
		if (speed < 0.1)
			jumpHeight = 10;
		*/
		endPosition = target.transform.position;
	}

	void Update ()
	{
		dist = Vector3.Distance (transform.position, target.position);
		jspeed = speed * Time.deltaTime;
		if (jspeed > 1f)
			jspeed = 1f;

		if (target.position.x > transform.position.x)
		{
			leftSide = true;
			rightSide = false;
		} else if (target.position.x < transform.position.x)
		{
			leftSide = false;
			rightSide = true;
		}

		if (leftSide == true && dist < 40)
		{
			this.transform.localScale = new Vector3 (-1, 1, 1);

			if (dist < xOffset + slowdownPoint)
				transform.position = Vector3.Lerp (transform.position, new Vector3 (target.transform.position.x - xOffset, 
					transform.position.y, 
					target.transform.position.z), jspeed * 5);
			else
				transform.position = Vector3.MoveTowards (transform.position, endPosition, jspeed * 30);
		}

		if (rightSide == true && dist < 40)
		{
			this.transform.localScale = new Vector3 (1, 1, 1);

			if (dist < xOffset + slowdownPoint)
				transform.position = Vector3.Lerp (transform.position, new Vector3 (target.transform.position.x + xOffset, 
					transform.position.y, 
					target.transform.position.z), jspeed * 5);
			else
				transform.position = Vector3.MoveTowards (transform.position, endPosition, jspeed * 30);
		}

		if (jumpTrigger && grounded)
		{
			//jumpX = GetComponent<Rigidbody2D> ().velocity.x;
			endPosition = transform.position;
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, jumpHeight);
			grounded = false;
			jumpTrigger = false;
		}

		endPosition = target.transform.position;

		if (grounded && dist < xOffset + slowdownPoint && Time.time > nextRot)
		{
			nextRot = Time.time + rotRate;
			
			if (phase > 2)
				phase = 1;
			
			if (phase == 1)
				rotPoint.transform.Rotate (Vector3.forward * 90);
			else
				rotPoint.transform.Rotate (Vector3.forward * -90);
			
			phase ++;
		}
	}
}