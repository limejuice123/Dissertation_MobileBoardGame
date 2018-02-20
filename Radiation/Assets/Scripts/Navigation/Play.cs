using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour 
{
	public Button playButton;

	void Start () 
	{
		playButton = GameObject.Find ("Play Button").GetComponent<Button> ();
		playButton.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		SceneManager.LoadScene ("addplayers");
	}
}
