﻿using UnityEngine;
using System.Collections;

public class MeleeT1Jump : MonoBehaviour
{	
	private MeleeT1Move script;
	void Start ()
	{
		GameObject meleeT1 = transform.parent.gameObject;
		script = meleeT1.GetComponent <MeleeT1Move> ();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Ground" && script.grounded == true)
		{
			script.jumpTrigger = true;
		}
	}

	void OnTriggerStay2D (Collider2D col)
	{
		if (col.gameObject.tag == "Ground" && script.grounded == true)
		{
			script.jumpTrigger = true;
		}
	}
}
