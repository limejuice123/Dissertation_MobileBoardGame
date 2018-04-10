using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script utilises the UI and SceneManagement APIs.
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this script moves the app onto the game scene when the player has finished building the deck.
public class FinishedBuilding : MonoBehaviour 
{
	public Button finishedButton;

	void Start () 
	{
		finishedButton = GetComponent<Button>();
		finishedButton.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick()
	{
		SceneManager.LoadScene ("game");
	}
}
