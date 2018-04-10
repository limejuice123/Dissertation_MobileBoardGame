using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script uses the UI APIs.
using UnityEngine.UI;

public class AddAllCards : MonoBehaviour 
{
	//this variable is the button to add all the cards
	public Button UseAllCards;
	//this variable allows access to variables included in GameHandling.cs
	public GameHandling gamehandling;
	//an array of all the sprites in the resources folder
	public Sprite[] cardsToUse;
	//the current card
	public GameObject current;
	//the card to be added
	public GameObject added;

	void Start () 
	{
		//finds the object with GameHandling.cs attached
		gamehandling = GameObject.Find ("GameHandler").GetComponent<GameHandling> ();
		//finds the button
		UseAllCards = GameObject.Find ("UseAllCards").GetComponent<Button> ();
		//allows tasks to execute from the TaskOnClick void upon tapping the button.
		UseAllCards.onClick.AddListener (TaskOnClick);
		//fills the array with all the sprites in the Resources folder.
		cardsToUse = Resources.LoadAll<Sprite> ("");
	}

	void TaskOnClick () 
	{
		//until the end of the array...
		for (int i = 0; i < cardsToUse.Length; i++) 
		{
			//...create a clone of the current card...
			added = Instantiate (gamehandling.currentCard);
			//...add that card to the deck...
			gamehandling.cardsInPlay.Add (added);
			//...ensure that the clone is not destroyed between scenes...
			DontDestroyOnLoad (added);
			//...make the clone invisible to the player to prevent overlap...
			added.GetComponent<SpriteRenderer> ().enabled = false;
			//...increment the counter to move onto the next card...
			gamehandling.counter = gamehandling.counter + 1;
			//...and replace the current card with the next one.
			gamehandling.currentCard.GetComponent<SpriteRenderer> ().sprite = gamehandling.cardSprites [gamehandling.counter];
		}
	}
}
