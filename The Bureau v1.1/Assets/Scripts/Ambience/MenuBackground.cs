using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script plays the music in the background in the menus.
public class MenuBackground : MonoBehaviour 
{
	//variables that reference the components needed to play audio.
	public AudioListener listener;
	public AudioSource source;
	public AudioClip clip;

	void Start () 
	{
		//finds the audio listener and source, and assigns them to their associated variables.
		listener = Camera.main.GetComponent<AudioListener> ();
		source = Camera.main.GetComponent<AudioSource> ();
		//assignes the music to the audio source.
		source.clip = clip;
		//plays the music.
		source.Play();
	}
}
