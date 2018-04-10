using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script utilises the UI and SceneManagement APIs.
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this script moves the app onto the next round using the same deck as the previous.
public class NextRound : MonoBehaviour 
{
	public Button NextRoundButton;
	public GameHandling gamehandling;

	void Start () 
	{
		NextRoundButton = GameObject.Find ("NextRound").GetComponent<Button>();
		gamehandling = GameObject.Find ("GameHandler").GetComponent<GameHandling> ();
		NextRoundButton.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick()
	{
		//makes the current card invisible to avoid overlay.
		gamehandling.currentCard.GetComponent<SpriteRenderer> ().enabled = false;
		//clears the win pile.
		gamehandling.wonCards.Clear();
		//reset the counter
		gamehandling.counter = 0;
		//go back to the game scene.
		SceneManager.LoadScene ("game");
	}
}
