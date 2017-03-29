using UnityEngine;
using System.Collections;

/*
	Therese Henriksson
	Vehicle+Collision Assignment

	Code given from class,
	The additional code for deceleration in Drive()
	and the wrapping code in Wrap() has been written and researched by myself.

	Code for wrapping was found online, I provided the link for it.
 */
public class VehicleMovement : MonoBehaviour
{
	// Attributes
	
	//local copy of vehicle position to manipulate
	private Vector3 vehiclePos;
	
	//speed
	public float speed = 1f;
	
	// Speed Variables
	private Vector3 velocity;
	public Vector3 direction;
	
	private Vector3 acceleration;
	public float accelerationRate = 0.1f;
	public float maxSpeed = 2f;
	public float minSpeed = 0f;
	//Vector3 viewPortPos;
	//float buffer = 0.5f;

	Renderer[] renderers;

	//bool isWrappingX = false;
	//bool isWrappingY = false;
	
	// Rotation Variables
	private Quaternion angle;
	public float angleOfRotation;
	
	// Use this for initialization
	void Start()
	{
		renderers = GetComponentsInChildren<Renderer>();

		vehiclePos = new Vector3(0, 0, 0);
		// Another possibility of using a vector with (0,0,0) as components
		// vehiclePos = Vector3.zero;
		
		// Vectors for movement
		direction = new Vector3(0, 1, 0); 
		velocity = new Vector3(0, 0, 0);        // Vector3.Right is the shortcut for this
		acceleration = new Vector3(0, 0, 0);

	}
	
	// Update is called once per frame
	void Update ()
	{
		Rotate();
		Drive();
		SetTransform();
		Wrap();
	}
	
	/// <summary>
	/// Drive this instance
	/// Calculate the velocity and the resulting position of the vehicle
	/// Also the "Calculate Velocity" Method
	/// </summary>
	void Drive()
	{
		if (Input.GetKey (KeyCode.UpArrow)) {
			//Acceleration Code
			// accelerate * direction = accel vector
			acceleration = accelerationRate * direction * Time.deltaTime;
			// Add accel to vel
			velocity += acceleration;
			// Limit Velocity
			velocity = Vector3.ClampMagnitude (velocity, maxSpeed);
			vehiclePos += velocity;
			
			// Velocity = speed x Direction
			// Add velocity to position
		} else {
			//Vector3 test1 = velocity;
			//Vector3 test2 = velocity * 0.8f * Time.deltaTime;
			velocity -= velocity * 0.6f * Time.deltaTime;

			//print (test1.x + "  " + test2.x);
			vehiclePos += velocity;
		}
	
	}
	
	/// <summary>
	/// Wrap this instance.
	/// Reposition the vehicle so it's always on screen
	/// https://github.com/tutsplus/screen-wrapping-unity/blob/master/src/Assets/Scripts/ScreenWrapBehaviour.cs
	/// Uses mesh as a render object to check if visible on screen.
	/// Has boolean values to make sure it only wraps once when you hit the border
	/// </summary>
	

	void Wrap ()
	{
		Vector3 pos = gameObject.transform.position;
		// if all the way to the right
		if (pos.x >= 6.5f)
		{
			vehiclePos.x = -1*(pos.x);
		}
		// if all the way to the left
		if (pos.x <= -6.5f)
		{
			vehiclePos.x = -1*(pos.x);
		}
		
		// top
		if (pos.y >= 6f) 
		{
			vehiclePos.y = -1*(pos.y);
		}
		// bottom
		if (pos.y <= -6f)
		{
			vehiclePos.y = -1*(pos.y);
		}
	}
	
	/// <summary>
	/// Rotates the vehicle based on the direction its facing
	/// </summary>
	/// <returns>The vehicle.</returns>
	void Rotate()
	{
		// if j is pressed rotate to the left 1 degree
		if(Input.GetKey (KeyCode.LeftArrow))
		{
			// Angle of rotation
			angle = Quaternion.Euler(0, 0, 3);
			
			// Rotate the vector by the angle
			direction = angle * direction;
			
			// Set the angle of rotation
			angleOfRotation += 3f;
		}
		
		// if k is pressed rotate to the right 1 degree
		if (Input.GetKey (KeyCode.RightArrow))
		{
			// Angle of rotation
			angle = Quaternion.Euler(0, 0, -3);
			
			// Rotate the vector by the angle
			direction = angle * direction;
			
			// Set the angle of rotation
			angleOfRotation -= 3f;
		}
		

	}
	
	/// <summary>
	/// Sets the transform
	/// </summary>
	void SetTransform()
	{
		// Draw the vehicle at the correct rotation
		gameObject.transform.rotation = Quaternion.Euler(0, 0, angleOfRotation);
		
		//"Draw" the vehicle at its calculated position
		gameObject.transform.position = vehiclePos;
	}
}
