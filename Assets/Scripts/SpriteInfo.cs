using UnityEngine;
using System.Collections;

/*
	Therese Henriksson
	Collision Assignment

	A helper class to provide us with information about the sprites,
	such as min and max values of Sprite Renderer bounding box, changing
	the color of the sprite, and the size.
 */
public class SpriteInfo : MonoBehaviour {
	Camera camera;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//SpriteRenderer sR = gameObject.GetComponent<SpriteRenderer> ();

		// to debug the sprite rendered bounds
		//Debug.DrawLine(new Vector2(sR.bounds.min.x, sR.bounds.max.y), new Vector2(sR.bounds.max.x, sR.bounds.max.y), Color.blue);
		//Debug.DrawLine(new Vector2(sR.bounds.min.x, sR.bounds.min.y), new Vector2(sR.bounds.max.x, sR.bounds.min.y), Color.blue);
		//Debug.DrawLine(new Vector2(sR.bounds.min.x, sR.bounds.max.y), new Vector2(sR.bounds.min.x, sR.bounds.min.y), Color.green);
		//Debug.DrawLine(new Vector2(sR.bounds.max.x, sR.bounds.max.y), new Vector2(sR.bounds.max.x, sR.bounds.min.y), Color.green);


	}

	/// <summary>
	/// Gets the minimum x.
	/// </summary>
	/// <returns>The minimum x.</returns>
	public float getMinX() {
		SpriteRenderer sR = gameObject.GetComponent<SpriteRenderer> ();
		return sR.bounds.min.x;
	}

	/// <summary>
	/// Gets the max x.
	/// </summary>
	/// <returns>The max x.</returns>
	public float getMaxX() {
		SpriteRenderer sR = gameObject.GetComponent<SpriteRenderer> ();
		return sR.bounds.max.x;
	}

	/// <summary>
	/// Gets the minimum y.
	/// </summary>
	/// <returns>The minimum y.</returns>
	public float getMinY() {
		SpriteRenderer sR = gameObject.GetComponent<SpriteRenderer> ();
		return sR.bounds.min.y;
	}

	/// <summary>
	/// Gets the max y.
	/// </summary>
	/// <returns>The max y.</returns>
	public float getMaxY() {
		SpriteRenderer sR = gameObject.GetComponent<SpriteRenderer> ();
		return sR.bounds.max.y;
	}

	/// <summary>
	/// Gets the size of the sprite.
	/// </summary>
	/// <returns>The sprite size.</returns>
	public Vector3 getSpriteSize() {
		SpriteRenderer sR = gameObject.GetComponent<SpriteRenderer> ();
		return sR.bounds.size;
	}

	/// <summary>
	/// Sets the color to red
	/// </summary>
	public void redColor()
	{
		SpriteRenderer sR = gameObject.GetComponent<SpriteRenderer> ();
		sR.material.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
	}

	/// <summary>
	/// Sets the color to white
	/// </summary>
	public void originalColor()
	{
		SpriteRenderer sR = gameObject.GetComponent<SpriteRenderer> ();
		sR.material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	}

}
