﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
/*

	Therese Henriksson
	IGME 202
	Project 2

	This is my major class, which is the Game Manager. It initiates the prefabs (flowers),
	checks for detection and checks when the game is over.
 */

public class GameManager : MonoBehaviour {
	public GameObject[] flowers;	// an array of prefabs to choose from randomly
	public GameObject bee;
	public GameObject puff;
	public GameObject canvas;
	public GameObject gameOverCanvas;

	public AudioClip poff;
	private AudioSource source;

	public int totalNumOfFlowers = 20;

	public List<GameObject> spawns;	// my current flowers
	public List<GameObject> bullets; // all bullets active

	public float spawnTime = 4.0f;
	private float timer = 0f;
	private Vector3 spawnPoint;

	bool gameOver = false;

	// Use this for initialization
	void Start () {
		gameOverCanvas.SetActive (false);
		source = GetComponent<AudioSource>();
		spawns = new List<GameObject> ();
		InititalSpawn ();

	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
	
			// timer for when spawning new flowers
			timer += Time.deltaTime;

			// checks if any of the list contains empty elements (from destroying game objects)
			spawns.RemoveAll (GameObject => GameObject == null);
			bullets.RemoveAll (GameObject => GameObject == null); 

			// spawn new flowers
			if (timer >= spawnTime) {
				SpawnFlowers ();
			}

			CheckBulletHit ();
			CheckShipCollision ();

			// if no more life left
			if (bee.GetComponent<BeeLife> ().totalHealth == 0) {
				GameOver ();
			}
		}
	}

	/// <summary>
	/// Initial Spawn, called only once the first time you play
	/// </summary>
	void InititalSpawn()
	{
		for (int i = 0; i < 4; i++) {
			GetRandomPoint ();
			GameObject copy = Instantiate(flowers[Random.Range(0, flowers.Length)], spawnPoint, Quaternion.identity) as GameObject;
			float scale = Random.Range(1f, 1.2f);
			copy.GetComponent<FlowerMovement>().speed = Random.Range(1.0f, 1.5f);
			copy.transform.localScale = new Vector3(scale, scale, scale);
			spawns.Add(copy);
		}
	}

	/// <summary>
	/// Spawns new flowers, has a timer so it's not too crazy
	/// </summary>
	private void SpawnFlowers()
	{
		if (spawns.Count < totalNumOfFlowers) {
			GetRandomPoint ();
			GameObject copy = Instantiate(flowers[Random.Range(0, flowers.Length)], spawnPoint, Quaternion.identity) as GameObject;
			float scale = Random.Range(1f, 1.2f);
			copy.GetComponent<FlowerMovement>().speed = Random.Range(1.0f, 1.5f);
			copy.transform.localScale = new Vector3(scale, scale, scale);
			spawns.Add(copy);
		}
		timer = 0.0f;
	}


	/// <summary>
	/// Gets a random point on the screen, makes sure that a flower is not placed
	/// on top of the player, or on top of each other
	/// </summary>
	private void GetRandomPoint()
	{
		int n = 0;

		// keep looking for a random point until it's one that's not taken
		// or too close
		// all current flowers + player
		while (n < spawns.Count + 1) {
			// get a spawnpoint
			spawnPoint = new Vector3 (Random.Range (-5.1f, 5.1f), Random.Range (-5.1f, 5.1f), 0f);

			// check if there is already a flower at this point
			for(int i = 0; i < spawns.Count; i++) {
				// get the position of the flower
				Vector3 currPos = spawns[i].transform.position;
				// check if they are overlapping or not
				if ((spawnPoint.x >= currPos.x + 0.3f) || (spawnPoint.x <= currPos.x - 0.3f) &&
				    (spawnPoint.y >= currPos.y + 0.3f) || (spawnPoint.y <= currPos.y - 0.3f))
				{
					n++;
				}
			}
			// grt curr position of the bee and check if the point is OK
			Vector3 beePos = bee.transform.position;
			if ((spawnPoint.x >= beePos.x + 4f) || (spawnPoint.x <= beePos.x - 4f) &&
			    (spawnPoint.y >= beePos.y + 4f) || (spawnPoint.y <= beePos.y - 4f))
			{
				n++;
			}

		}
	}

	/// <summary>
	/// Checks if a honey "bullet" hits any of my flowers
	/// </summary>
	void CheckBulletHit()
	{
		// for each flower, is any of my bullets colliding with it
		for(int i = 0; i < spawns.Count; i++)  
		{
			// obj1 = flower
			for(int j = 0; j < bullets.Count; j++) 
			{
				// i = honey bullet
				// check if they are colliding
				// if so
				if(gameObject.GetComponent<CollisionDetection>().CircleCollision(spawns[i], bullets[j]))
				{
					// get the position of the flower
					Vector3 pos = spawns[i].transform.position;
					// destroy the flower and the bullet
					Destroy(spawns[i]);
					Destroy(bullets[j]);
					source.PlayOneShot(poff,0.7f); 

					// if this was a first level flower (big one)
					if (spawns[i].GetComponent<FlowerMovement>().level == 1)
					{
						gameObject.GetComponent<UpdateUI>().GetScore(20);
					// get a random number of second level smaller flower puffs
					int num = Random.Range(2, 4);
						for (int k = 0; k < num; k++)
						{
							GameObject copy = Instantiate(puff, new Vector3(pos.x + Random.Range(-0.4f, 0.4f), pos.y + Random.Range(-0.4f, 0.4f), 0.0f), Quaternion.identity) as GameObject;
							// scale the sprite
							copy.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
							copy.GetComponent<FlowerMovement>().speed = 2.0f;
							copy.GetComponent<FlowerMovement>().level = 2;
							spawns.Add (copy);
						}
					}
					else
					{
						gameObject.GetComponent<UpdateUI>().GetScore(50);
					}
				}
			}
		}
	}

	/// <summary>
	/// Checks if the player collides with any of the flowers.
	/// </summary>
	void CheckShipCollision()
	{
		// for each flower
		for (int i = 0; i < spawns.Count; i++) {
			// if this flower is colliding with the player

			// if colliding and the player is currently not in "recovering" stealth mode
			if (gameObject.GetComponent<CollisionDetection> ().CircleCollision (spawns [i], bee) && 
				bee.GetComponent<BeeLife> ().isStealth == false) {
				// then the player is hit
				bee.GetComponent<BeeLife> ().hit = true;

				// get the position of the flower
				Vector3 pos = spawns [i].transform.position;
				// destroy it
				Destroy (spawns [i]);
				source.PlayOneShot(poff,0.7f); 

				// and create smaller puffs if the flower was a level 1 flower
				if (spawns [i].GetComponent<FlowerMovement> ().level == 1) {
					int num = Random.Range (2, 4);

					for (int k = 0; k < num; k++) {
						GameObject copy = Instantiate (puff, new Vector3 (pos.x + Random.Range (-0.4f, 0.4f), pos.y + Random.Range (-0.4f, 0.4f), 0.0f), Quaternion.identity) as GameObject;
						copy.transform.localScale = new Vector3 (0.7f, 0.7f, 0.7f);
						copy.GetComponent<FlowerMovement> ().speed = 2.0f;
						copy.GetComponent<FlowerMovement> ().level = 2;
						spawns.Add (copy);
					}
				}
			}

		}
	}

	/// <summary>
	/// Games is over, display game over canvas.
	/// </summary>
	void GameOver()
	{
		gameOver = true;
		// destroy all flowers
		for (int i = 0; i < spawns.Count; i++) 
		{
			Destroy(spawns[i]);
		}
		spawns.Clear();
		// change canvases 
		canvas.SetActive (false);
		gameOverCanvas.SetActive (true);
		bee.SetActive (false);
	}
}
