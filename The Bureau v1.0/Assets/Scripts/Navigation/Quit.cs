using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour 
{
	public Button quitbutton;

	void Start () 
	{
		quitbutton = GameObject.Find ("quitbutton").GetComponent<Button> ();
		quitbutton.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		Application.Quit ();
	}
}
