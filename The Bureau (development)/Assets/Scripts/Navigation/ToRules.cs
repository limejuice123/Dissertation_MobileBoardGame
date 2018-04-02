using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToRules : MonoBehaviour 
{
	public Button toRules;

	void Start () 
	{
		toRules = GameObject.Find ("rulesbutton").GetComponent<Button> ();
		toRules.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		Initiate.Fade ("rules", Color.black, 2);
	}
}
