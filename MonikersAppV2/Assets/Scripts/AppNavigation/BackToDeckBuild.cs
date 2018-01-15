using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToDeckBuild : MonoBehaviour 
{
	public Button BackToDeck;
	public GameHandling gamehandling;

	void Start () 
	{
		BackToDeck = GameObject.Find ("BackToDeckBuild").GetComponent<Button> ();
		gamehandling = GameObject.Find ("GameHandler").GetComponent<GameHandling> ();
		BackToDeck.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		gamehandling.currentCard.GetComponent<SpriteRenderer> ().enabled = false;
		gamehandling.cardsInPlay.Clear();
		gamehandling.wonCards.Clear();
		gamehandling.counter = 0;
		SceneManager.LoadScene ("deckbuilding");
	}
}
