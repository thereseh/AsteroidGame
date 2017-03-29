using UnityEngine;
using System.Collections;

/*
	Therese Henriksson
	Collision Assignment
	IGME 202
	10/10/2016

	This class has two methods, one for AABB Collision, and one for
	CircleCollider2D Collision

	Returns true if colliding, false if not.
 */
public class CollisionDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// AABB collision.
	/// </summary>
	/// <returns><c>true</c>, if colliding <c>false</c> otherwise.</returns>
	/// <param name="planet">Planet.</param>
	/// <param name="ship">Ship.</param>

	/// <summary>
	/// Checking the distance between the two sprites,
	/// if the distance is less than the sum of the radious of
	/// the sprites circle colliders, then they are overlapping
	/// </summary>
	/// <returns><c>true</c>, if circles are colliding, <c>false</c> otherwise.</returns>
	/// <param name="planet">Planet.</param>
	/// <param name="ship">Ship.</param>
	public bool CircleCollision(GameObject obj1, GameObject obj2)
	{
		// getting the center vector of the circle collider
		Vector3 c1 = obj1.GetComponent<CircleCollider2D> ().bounds.center;
		Vector3 c2 = obj2.GetComponent<CircleCollider2D> ().bounds.center;

		// getting the radius
		float r1 = obj1.GetComponent<CircleCollider2D> ().radius;
		float r2 = obj2.GetComponent<CircleCollider2D> ().radius;

		// the distance squared
		Vector3 distance = new Vector3 (0, 0, 0);
		distance.x = (c1.x - c2.x) * (c1.x - c2.x);
		distance.y = (c1.y - c2.y) * (c1.y - c2.y);

		// getting the magnitude of the distance
		float distMag = distance.magnitude;

		// getting the sum of the radiuses
		float total = r1 + r2;

		// if magnitude of the distance is less than the sum of rad
		// return true
		if (distMag < total) {
			return true;
		}
		else{
			return false;
		}
	}
}
