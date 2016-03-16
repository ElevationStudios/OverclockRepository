using UnityEngine;
using System.Collections;

public class BlasterShell : MonoBehaviour {

	void Start () 
	{
		GetComponent<Rigidbody2D>().AddForce(transform.up * 35, ForceMode2D.Force);
		Destroy (gameObject, 3);
	}

	void Update () {
	
	}
}
