using UnityEngine;
using System.Collections;

/*

	Therese Henriksson
	IGME 202
	Project 2

	This class is in charge of the movement of the flowers, I decided to allow the flowers to wrap,
	there is not acceleration. 
 */

public class FlowerMovement : MonoBehaviour {

	public Vector3 direction;
	public Vector3 position;
	public float speed = 0.1f;
	public Vector3 velocity;

	public int level = 1;

	// Use this for initialization
	void Start () {
		position = Vector3.zero;
		velocity = Vector3.zero;
		GetRandomDirection ();

	}
	
	// Update is called once per frame
	void Update () {
		Move ();
		Wrap ();
	}

	/// <summary>
	/// Move this instance.
	/// </summary>
	private void Move()
	{
		position = gameObject.transform.position;
		velocity = direction * speed * Time.deltaTime;
		position += velocity;
		gameObject.transform.position = position;
	}

	/// <summary>
	/// Wrap this instance.
	/// </summary>
	private void Wrap ()
	{
		Vector3 pos = gameObject.transform.position;
		// if all the way to the right
		if (pos.x >= 6.5f)
		{
			position.x = -1*(pos.x);
		}
		// if all the way to the left
		if (pos.x <= -6.5f)
		{
			position.x = -1*(pos.x);
		}
		
		// top
		if (pos.y >= 6f) 
		{
			position.y = -1*(pos.y);
		}
		// bottom
		if (pos.y <= -6f)
		{
			position.y = -1*(pos.y);
		}

		gameObject.transform.position = position;
	}

	/// <summary>
	/// Get a random direction to head towards, by getting a random point from a unit circle of radius 1.
	/// </summary>
	private void GetRandomDirection()
	{
		direction = Random.insideUnitCircle;
	}

}
