using UnityEngine;
using System.Collections;

/*

	Therese Henriksson
	IGME 202
	Project 2

	This class creates an instant of my honey bullet, there is a timer so you can't do rapid fire
 */

public class HoneyBullet : MonoBehaviour {
	public GameObject honey;
	private GameObject copy;
	private float timer = 0.5f;
	public GameObject manager;
	private GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = manager.GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
			timer += Time.deltaTime;
		if (Input.GetKeyDown (KeyCode.Space) && timer >= 1.0f) 
		{
			copy = Instantiate(honey, transform.position, transform.rotation) as GameObject;
			// get the direction vector from the bee, and set it in honey movement
			copy.GetComponent<HoneyMovement>().SetDirection(gameObject.GetComponent<VehicleMovement>().direction);
			timer = 0.0f;
			gameManager.bullets.Add (copy);
		}
	
	}

}
