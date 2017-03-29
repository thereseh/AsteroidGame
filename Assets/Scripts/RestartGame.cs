using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/*

	Therese Henriksson
	IGME 202
	Project 2

	This class is called by button that restarts the game by reloading the scene
 */
public class RestartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Restarts the level
	/// </summary>
	public void Restart()
	{
	    SceneManager.LoadScene("scene1");
	}
}
