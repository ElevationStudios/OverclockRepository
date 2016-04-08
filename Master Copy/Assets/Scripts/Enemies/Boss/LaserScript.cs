using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour 
{
	private GameObject boss;
	private float timer;
	public bool laserLeft;
	public float damage;

	void Start () 
	{
		StartCoroutine ("LaserPath");
	}
		

	IEnumerator LaserPath()
	{
		yield return new WaitForSeconds (0.8f);
		if (laserLeft) {
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-15, 0);
		} else {
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (12, 0);
		}
		yield return new WaitForSeconds (0.5f);

		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);

		yield return new WaitForSeconds (0.25f);

		if (laserLeft) {
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (12, 0);
		} else {
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-12, 0);
		}

		yield return new WaitForSeconds (0.55f);

		this.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);

		yield return new WaitForSeconds (0.3f);
		GameObject.Destroy (this.gameObject);
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<Player> ().DamagePlayer (damage);
		}
	}
}
