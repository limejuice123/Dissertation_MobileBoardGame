using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class plays the sounds upon winning or losing a game.
public class WinOrLose_Sound : MonoBehaviour 
{
	public AudioSource source;
	public AudioClip win;
	public AudioClip lose;
	//allows access to variables in Gameplay.cs
	public Gameplay gameplay;

	void Start () 
	{
		source = Camera.main.GetComponent<AudioSource> ();
		gameplay = GameObject.Find ("GameHandler").GetComponent<Gameplay> ();

		//if the players won, play the "you win" sound. If not, play the "you lose" sound.
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
