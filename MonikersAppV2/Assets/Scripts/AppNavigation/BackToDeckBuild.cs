using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script utilises the UI and SceneManagement APIs.
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToDeckBuild : MonoBehaviour 
{
	//the button to press.
	public Button BackToDeck;
	//allows access to the variables in GameHandling.cs
	public GameHandling gamehandling;

	void Start () 
	{
		//assigns the variables to their associated components of gameObjects.
		BackToDeck = GameObject.Find ("BackToDeckBuild").GetComponent<Button> ();
		gamehandling = GameObject.Find ("GameHandler").GetComponent<GameHandling> ();
		//allows execution of tasks upon tapping of the button.
		BackToDeck.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		//makes the current card invisible to ensure it doesn't overlay anything.
		gamehandling.currentCard.GetComponent<SpriteRenderer> ().enabled = false;
		//clears the built deck
		gamehandling.cardsInPlay.Clear();
		//clears the win pile.
		gamehandling.wonCards.Clear();
		//resets the counter
		gamehandling.counter = 0;
		//moves back to the deckbuilder.
		SceneManager.LoadScene ("deckbuilding");
	}
}
