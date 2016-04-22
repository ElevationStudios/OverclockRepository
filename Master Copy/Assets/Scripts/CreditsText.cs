using UnityEngine;
using System.Collections;

public class CreditsText : MonoBehaviour
{
	public float textSpeed = 5;

	public Transform stopper;
	
	void Start ()
	{
		
	}
	
	void Update ()
	{
		if (!(stopper.transform.position.y > 8))
		{
			transform.Translate (Vector3.up * textSpeed * Time.deltaTime);
			stopper.Translate (Vector3.up * textSpeed * Time.deltaTime);
		}
	}
}
