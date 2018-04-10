using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script uses the UI APIs.
using UnityEngine.UI;

//this class controls the in game skip button
public class DontHaveResource : MonoBehaviour 
{
	//the variable holding the button to be pressed.
	public Button btn;
	//allows access to the variables located in Gameplay.cs
	public Gameplay gameplay;

	void Start () 
	{
		//finds the button and assigns it to a variable.
		btn = GameObject.Find ("DontHave").GetComponent<Button> ();
		//finds the gameObject with Gameplay.cs attached and assigns said component to a variable.
		gameplay = GameObject.Find ("GameHandler").GetComponent<Gameplay> ();
		//allows tasks to be executed upon pressing the button.
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		//depletes the timer by 20 seconds when pressed
		gameplay.timer = gameplay.timer - 20;
		//moves to the next round.
		gameplay.needNewResource = true;
	}
}
