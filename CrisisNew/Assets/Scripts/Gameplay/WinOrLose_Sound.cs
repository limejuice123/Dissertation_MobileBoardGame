using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLose_Sound : MonoBehaviour 
{
	public AudioSource source;
	public AudioClip win;
	public AudioClip lose;
	public Gameplay gameplay;

	void Start () 
	{
		source = Camera.main.GetComponent<AudioSource> ();
		gameplay = GameObject.Find ("GameHandler").GetComponent<Gameplay> ();

		if (gameplay.didWin == true) 
		{
			source.clip = win;
			source.Play ();
		} 
		else 
		{
			source.clip = lose;
			source.Play ();
		}

	}
}
