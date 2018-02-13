using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLose_Sound : MonoBehaviour 
{
	public AudioSource source;
	public AudioClip explosion;
	public Gameplay gameplay;

	void Start () 
	{
		source = Camera.main.GetComponent<AudioSource> ();
		source.enabled = false;
		gameplay = GameObject.Find ("GameHandler").GetComponent<Gameplay> ();

		if (gameplay.didWin == false) 
		{
			source.enabled = true;
			source.Play ();
		}
	}
}
