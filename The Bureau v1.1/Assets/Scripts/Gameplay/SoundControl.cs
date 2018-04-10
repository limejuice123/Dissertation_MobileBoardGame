using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is an old, unused script that was to control the old sound design
public class SoundControl : MonoBehaviour 
{
	public Gameplay gameplay;
	public AudioListener listener;
	//the script utilisied multiple audio sources
	public AudioSource source;
	public AudioSource source2;
	public AudioSource source3;
	public AudioSource source4;
	public AudioSource source5;
	//all of the old audio clips
	public AudioClip bombcount;
	public AudioClip bombcount2x;
	public AudioClip bombcount3x;
	public AudioClip bombcount4x;
	public AudioClip bombexplode;
	public AudioClip upheaval;

	void Start () 
	{
		gameplay = GetComponent<Gameplay> ();
		listener = Camera.main.GetComponent<AudioListener> ();
		source = Camera.main.GetComponent<AudioSource> ();
		source2 = GameObject.Find ("AudioSource2").GetComponent<AudioSource> ();
		source3 = GameObject.Find ("AudioSource3").GetComponent<AudioSource> ();
		source4 = GameObject.Find ("AudioSource4").GetComponent<AudioSource> ();
		source5 = GameObject.Find ("AudioSource5").GetComponent<AudioSource> ();
		source.clip = bombcount;
		source2.clip = bombcount2x;
		source3.clip = bombcount3x;
		source4.clip = bombcount4x;
		source5.clip = upheaval;
		source.enabled = false;
		source2.enabled = false;
		source3.enabled = false;
		source4.enabled = false;
		source5.Play ();
		FindWhichSound ();
	}

	//this script would have checked against the timer and enable new sounds (disabling old ones) once certain points of the game had been reached.
	void FindWhichSound()
	{
		if (gameplay.timer > 60 && gameplay.prepcanvas.enabled == false) 
		{
			source.enabled = true;
		}

		if (gameplay.timer <= 60 && gameplay.timer > 30) 
		{
			source2.enabled = true;
			source.enabled = false;
		}

		if (gameplay.timer <= 20 && gameplay.timer > 10) 
		{
			source3.enabled = true;
			source2.enabled = false;
		}

		if (gameplay.timer <= 10 && gameplay.timer > 0) 
		{
			source4.enabled = true;
			source3.enabled = false;
		}
	}

	void Update()
	{
		FindWhichSound ();
	}
}
