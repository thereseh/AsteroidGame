using UnityEngine;
using System.Collections;

/*

	Therese Henriksson
	IGME 202
	Project 2

	This class is in charge of the movement of the honey bullet, destroys it if goes out of range of camera
 */

public class HoneyMovement : MonoBehaviour {
	public Vector3 velocity;
	private Vector3 direction;
	private Vector3 honeyPos;
	public float honeySpeed = 10.0f;

	Renderer[] renderers;
	// Use this for initialization
	void Start () {
	
		renderers = GetComponentsInChildren<Renderer> ();
		honeyPos = transform.position;
		velocity = new Vector3(0, 0, 0);        
	}
			
	// Update is called once per frame
	void Update () {
		// get position (which is the bees position)
		honeyPos = gameObject.transform.position;
		// get velocity
		velocity = direction * honeySpeed * Time.deltaTime;
		// add it to position
		honeyPos += velocity;
		gameObject.transform.position = honeyPos;

		// if the bullet goes out of range from camera, destroy it, no wrapping.
		foreach(var renderer in renderers)
		{
			if(!renderer.isVisible)
			{
				Destroy (gameObject);
			}
		}
	}

	// get direction from the bee, so the bullet knows what direction to go towards
	public void SetDirection(Vector3 dir) 
	{
		direction = dir;
	}

}
