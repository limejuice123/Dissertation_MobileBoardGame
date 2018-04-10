using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script uses the UI and SceneManagement APIs
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this class controls the quit button on the main menu
public class Quit : MonoBehaviour 
{
	//the quit button is held in a variable
	public Button quitbutton;

	void Start () 
	{
		//finds the button and adds a listener that executes commands upon the pressing of the button
		quitbutton = GameObject.Find ("quitbutton").GetComponent<Button> ();
		quitbutton.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		//quits the app
		Application.Quit ();
	}
}
