using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddAllCards : MonoBehaviour 
{
	public Button UseAllCards;
	public GameHandling gamehandling;
	public Sprite[] cardsToUse;
	public GameObject current;
	public GameObject added;

	void Start () 
	{
		gamehandling = GameObject.Find ("GameHandler").GetComponent<GameHandling> ();
		UseAllCards = GameObject.Find ("UseAllCards").GetComponent<Button> ();
		UseAllCards.onClick.AddListener (TaskOnClick);
		cardsToUse = Resources.LoadAll<Sprite> ("");
	}

	void TaskOnClick () 
	{
		for (int i = 0; i < cardsToUse.Length; i++) 
		{
			added = Instantiate (gamehandling.currentCard);
			gamehandling.cardsInPlay.Add (added);
			DontDestroyOnLoad (added);
			added.GetComponent<SpriteRenderer> ().enabled = false;
			gamehandling.counter = gamehandling.counter + 1;
			gamehandling.currentCard.GetComponent<SpriteRenderer> ().sprite = gamehandling.cardSprites [gamehandling.counter];
		}
	}
}
