using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script uses the UI and SceneManagement APIs
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this class is for the back button on the rules screen
public class BackButton : MonoBehaviour 
{
	//the variable for the button component
	public Button btn;
	//allows access to the variables in RuleScript.cs
	public RuleScript rulescript;

	void Start () 
	{
		//finds the required components and assigns them to their respective variables
		rulescript = Camera.main.GetComponent<RuleScript> ();
		btn = this.gameObject.GetComponent<Button> ();
		//adds a listener to the button to execute TaskOnClick upon pressing
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		//move back to the menu
		Initiate.Fade ("mainmenu", Color.black, 2);
	}
}
