using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/*

	Therese Henriksson
	IGME 202
	Project 2

	This class changes my UI features, updates the text and show num of lifes
 */

public class UpdateUI : MonoBehaviour {
	public GameObject bee;
	public Image honey;
	private int totalHealth;
	public Text health;
	public Text score;
	private int totalScore = 0;
	public List<Image> honeyHealth;	// money yars

	// Use this for initialization
	void Start () {
		honeyHealth = new List<Image> ();
		// set total health of bee
		totalHealth = bee.GetComponent<BeeLife> ().totalHealth;
		DrawLife ();
	}
	
	// Update is called once per frame
	void Update () {

		if (bee.GetComponent<BeeLife> ().hit && totalHealth != 0) {
			ChangeLife();
		}
	}

	/// <summary>
	/// Changes the life, takes one away when you have been hit
	/// </summary>
	void ChangeLife()
	{
		Destroy (honeyHealth [honeyHealth.Count - 1]);
		honeyHealth.Remove (honeyHealth [honeyHealth.Count - 1]);
	}

	/// <summary>
	/// Updates the score.
	/// </summary>
	void UpdateScore() 
	{
		score.text = "Points: " + totalScore;
	}

	/// <summary>
	/// Draws the total num of life you start off with
	/// </summary>
	void DrawLife()
	{
		for (int i = 0; i < 3; i++) {
			Vector3 pos = health.transform.position;
			Image copy = Instantiate (honey, new Vector3(pos.x + 65 +(35f*i), pos.y + 5f, pos.z), Quaternion.identity) as Image;;
			copy.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
			copy.transform.SetParent(GameObject.Find ("Canvas").transform);
			honeyHealth.Add (copy);
		}
	}

	/// <summary>
	/// Gets scores when flowers have been hit 
	/// </summary>
	/// <param name="num">Number.</param>
	public void GetScore(int num)
	{
		totalScore += num;
		UpdateScore ();
	}
	
}
