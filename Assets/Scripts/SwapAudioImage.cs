using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*

	Therese Henriksson
	IGME 202
	Project 2

	This class swaps buttons for either muting or turning on the background music
 */

public class SwapAudioImage : MonoBehaviour {
	public GameObject music;
	public GameObject mute;
	public GameObject bg;

	bool playMusic = true;
	// Use this for initialization

	// we start with the music on
	void Start () {
		mute.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Turns on the audio
	/// </summary>
	public void PlayAudio()
	{
		bg.GetComponent<AudioSource> ().mute = false;
		music.SetActive (true);
		mute.SetActive(false);
	}

	/// <summary>
	/// Mutes the audio.
	/// </summary>
	public void MuteAudio()
	{
		bg.GetComponent<AudioSource> ().mute = true;
		mute.SetActive(true);
		music.SetActive(false);

	}
}
