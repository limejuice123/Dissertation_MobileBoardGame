using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script utilises the UI and SceneManagement APIs.
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this script moves the app onto the deck builder when pressing play.
public class PressPlay : MonoBehaviour 
{
	public Button playbtn;

	void Start () 
	{
		playbtn = GameObject.Find ("Play Button").GetComponent<Button>();
		playbtn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		SceneManager.LoadScene ("deckbuilding");
	}
}
