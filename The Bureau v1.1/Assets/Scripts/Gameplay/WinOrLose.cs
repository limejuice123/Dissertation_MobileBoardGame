using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script uses the UI and SceneManagement APIs.
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this class controls the UI elements in the win/lose screen
public class WinOrLose : MonoBehaviour 
{
	public Button btn;
	public Text text;
	//allows access to variables in Gameplay.cs
	public Gameplay gameplay;

	void Start () 
	{
		btn = GameObject.Find ("backtomenu").GetComponent<Button> ();
		text = GameObject.Find ("WinLoseText").GetComponent<Text> ();
		gameplay = GameObject.Find ("GameHandler").GetComponent<Gameplay> ();
		btn.onClick.AddListener (TaskOnClick);

		//checks if the players won. If so, display the "you win" text. If not, display the "you lose" text.
		if (gameplay.didWin == true)
			text.text = "The recent congressional audit has found that your services were invaluable to the country during this term. The cabinet has decided to let your ministry continue with its current apparatus over the course of the next term. YOU WIN!";
		else
			text.text = "The recent congressional audit has found that there were large flaws in the running of this ministry during the course of the term. A civil service reshuffle is imminent, with you on the chopping block first. YOU LOSE!";
	}

	void TaskOnClick () 
	{
		//fade out back to the main menu
		Initiate.Fade ("mainmenu", Color.black, 2);
	}
}
