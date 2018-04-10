using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script uses the UI and SceneManagement APIs
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this class moves the user to the rules screen
public class ToRules : MonoBehaviour 
{
	//the variable containing the button component
	public Button toRules;

	void Start () 
	{
		//assigns the button to its respective variable and adds a listener to it, which will execute TaskOnClick upon pressing it.
		toRules = GameObject.Find ("rulesbutton").GetComponent<Button> ();
		toRules.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		//fade out to the rules screen
		Initiate.Fade ("rules", Color.black, 2);
	}
}
