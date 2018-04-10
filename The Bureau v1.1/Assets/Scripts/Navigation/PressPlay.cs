using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script uses the UI and SceneManagement APIs
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this class is responsible for moving the app to the gameplay segment
public class PressPlay : MonoBehaviour 
{
	//the variable containing the button component
	public Button btn;

	void Start () 
	{
		//assigns the button to its respective variable and adds a listener to it, which will execute TaskOnClick upon pressing it.
		btn = GameObject.Find ("playbutton").GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		//moves the app to the game segment
		Initiate.Fade ("game", Color.black, 2);
	}
}
