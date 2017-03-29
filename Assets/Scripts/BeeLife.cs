using UnityEngine;
using System.Collections;

/*

	Therese Henriksson
	IGME 202
	Project 2

	This class keeps track on the life of the bee, and activas stealth when the player has been hit,
	so you have some time to drive to safety.
 */

public class BeeLife : MonoBehaviour {

	public int totalHealth = 3;
	public GameObject canvas;
	public GameObject healthObj;
	public bool hit;
	public float stealth = 3.0f;
	float timer = 0.0f;
	public bool isStealth = false;
	private bool gameOver;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (hit) {
			Colliding ();
		}
		if (isStealth) {
			timer += Time.deltaTime;
		}
		if (timer >= stealth) {
			NotColliding();
		}
	}

	/// <summary>
	/// The bee did collide with a flower, so activate stealth and change alpha
	/// </summary>
	private void Colliding()
	{
		isStealth = true;
		totalHealth -= 1;
		gameObject.GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 0.6f);
		hit = false;
	}

	/// <summary>
	/// Not colliding anymore, take off stealth and change alpha back up again
	/// and restart the timer
	/// </summary>
	private void NotColliding()
	{
		isStealth = false;
		gameObject.GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 1f);
		timer = 0.0f;
	}
}
