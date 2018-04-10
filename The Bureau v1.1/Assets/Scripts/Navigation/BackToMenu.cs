using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script uses the UI and SceneManagement APIs
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this class controls buttons that take the user back to the main menu
public class BackToMenu : MonoBehaviour 
{
	//the variable containing the button component
	public Button exit;
	//the gamehandler object, which contains the script for the game logic
	public GameObject gamehandler;

	void Start () 
	{
		//assigns the button to its respective variable and adds a listener to it, which will execute TaskOnClick upon pressing it.
		exit = GameObject.Find ("Exit").GetComponent<Button> ();
		exit.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick ()
	{
		//destroy the gamehandler object if one is present (a new one is created upon starting a new game)
		if (GameObject.Find ("GameHandler")) 
		{
			Destroy (GameObject.Find ("GameHandler"));
		}

		//move to the menu
		Initiate.Fade ("mainmenu", Color.black, 2);
	}
}
