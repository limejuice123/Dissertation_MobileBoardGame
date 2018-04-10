using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script needs to declare its use of the UI and SceneManagement modules to be able to access the APIs associated with.
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//most of the game logic is handled within this one class. This script is attached to an otherwise empty gameobject that is created at the start of the app, and is kept constant throughout.
public class GameHandling : MonoBehaviour 
{
	//this variable is for reference to the gameobject this script is attached to.
	public GameObject asThis;
	//this variable is for the card currently displayed on screen at any one time.
	public GameObject currentCard;
	//an array of all the sprites taken from Resource.
	public Sprite[] cardSprites;
	//this variable is for a references to a card being added to a list.
	public GameObject addedCard;
	//a counter that keeps a reference to which card in the card library is active at one time.
	public int counter = 0;
	//the list of all the cards currently loaded into the deck.
	public List<GameObject> cardsInPlay = new List<GameObject> ();

	//a reference to the current unity scene open at any time.
	public Scene currentScene;
	//the text displaying the card count.
	public Text cardCount_Text;

	//the text that displays the countdown on game start.
	public Text countdown_text;
	//the variable holding the countdown.
	public float countdown = 3f;
	//a list containing all the cards that have been won in a round.
	public List<GameObject> wonCards = new List<GameObject> ();
	//the timer that counts up in a game.
	public float timer = 0f;
	//the text displaying the timer.
	public Text timer_text;

	//this function executes as soon as the app is loaded.
	void Awake()
	{
		asThis = this.gameObject;
		//makes sure the object containing this script isn't destroyed between scenes.
		DontDestroyOnLoad (asThis);
		//loads all the sprites from the resources folder into the cardSprites array.
		cardSprites = Resources.LoadAll<Sprite> ("");
	}

	//allows the app to execute behaviour when a new level is loaded.
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelLoaded;
	}
		
	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnLevelLoaded;
	}

	//these behaviours execute on scene changes, equivalent to the Start function. This void allows multiple scenes to be run from one script.
	void OnLevelLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "deckbuilding") 
		{
			cardCount_Text = GameObject.Find ("cardcount").GetComponent<Text> ();
			//sets the variable tracking which scene is active to the currently open scene.
			currentScene = scene;
			//sets the currentCard variable to the first card in the cardSprites array, and positions it in the middle of the scene.
			currentCard = GameObject.Find ("StartCard");
			currentCard.GetComponent<SpriteRenderer> ().sprite = cardSprites [counter];
			currentCard.transform.position = new Vector2 (0f, -0.4f);
			currentCard.transform.localScale = new Vector2 (0.65f, 0.65f);
		}

		if (scene.name == "game") 
		{
			currentScene = scene;
			//resets the in game variables upon scene load - primarily useful for reloading scene upon next round.
			counter = 0;
			timer = 0;
			countdown = 3f;
			timer_text = GameObject.Find ("timer").GetComponent<Text> ();
			countdown_text = GameObject.Find ("Countdown").GetComponent<Text> ();
			//sets the currentCard to the first card in the built deck.
			currentCard = cardsInPlay [counter];
			currentCard.transform.position = new Vector2(0f, -0.4f);
			//sets the timer going.
			StartCoroutine (Timer());
		}

		if (scene.name == "finish") 
		{
			currentScene = scene;
			//reset the counter to 0 - this makes sure the apps displays the first card in the deck upon review.
			counter = 0;
			//sets the currentCard to the first in the deck of won cards.
			currentCard = wonCards [counter];
			currentCard.transform.position = new Vector2 (0f, -0.4f);

			//for all the cards in the wonCards list, re-enable the sprite renderers (i.e. makes them visible again), and re-add those cards to the play deck.
			for (int i = 0; i < wonCards.Count; i++) 
			{
				currentCard = wonCards [i];
				currentCard.GetComponent<SpriteRenderer> ().enabled = true;
				cardsInPlay.Add (currentCard);
			}
		}
	}

	void AddCardToList()
	{
		//creates a copy of the currentCard to add to the deck.
		addedCard = Instantiate(currentCard);
		//makes sure the gameObjects that represent the cards in the deck aren't destroyed on transition to a new scene.
		DontDestroyOnLoad (addedCard);
		//add that card to the deck.
		cardsInPlay.Add (addedCard);
		//makes the card invisible so that it doesn't overlay the next card.
		addedCard.GetComponent<SpriteRenderer> ().enabled = false;
		//moves onto the next card.
		counter++;
		currentCard.transform.position = new Vector3 (0f, -0.4f, 0f);
		currentCard.GetComponent<SpriteRenderer> ().sprite = cardSprites [counter];
	}

	void DiscardCardFromList()
	{
		//moves onto the next card without adding it to the deck.
		counter++;
		currentCard.transform.position = new Vector3 (0f, -0.4f, 0f);
		currentCard.GetComponent<SpriteRenderer> ().sprite = cardSprites [counter];
	}

	void WinCard()
	{
		//I use a try/catch here to alleviate an issue with transitioning between scenes in the eventuality that players win the entire deck.
		try
		{
		//removes the currentCard from the deck and adds it to the win pile.
		wonCards.Add (currentCard);
		cardsInPlay.Remove (currentCard);
		currentCard.GetComponent<SpriteRenderer> ().enabled = false;
		//move onto the next card.
		currentCard = cardsInPlay [counter];
		currentCard.transform.position = new Vector2 (0f, -0.4f);
		}
		//transition to next scene if out of cards.
		catch (ArgumentOutOfRangeException) 
		{
			SceneManager.LoadScene ("finish");
		}
	}

	void SkipCard()
	{
		//removes the card from the current position in the deck and places it at the back.
		cardsInPlay.Remove (currentCard);
		cardsInPlay.Add (currentCard);
		currentCard.GetComponent<SpriteRenderer> ().enabled = false;
		//moves onto the next card.
		currentCard = cardsInPlay [counter];
		currentCard.transform.position = new Vector2 (0f, -0.4f);
	}

	void ResetWonCards()
	{
		//when a player is reviewing the cards they have won, this void ensures that should they reach the end of the win pile, the app cycles back to the beginning of said win pile.
		for (int i = 0; i < wonCards.Count; i++) 
		{
			currentCard = wonCards [i];
			currentCard.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void Update () 
	{
		if (currentScene.name == "deckbuilding") 
		{
			//creates a local variable containing the centre point of the screen.
			Transform centrepoint = GameObject.Find ("CentrePoint").GetComponent<Transform> ();

			//detects if the user has touched the screen.
			if (Input.GetTouch (0).phase == TouchPhase.Began && Input.touchCount > 0) 
			{
				//a local variable that converts the position of the touch to an orthographic value, similar to the x and y properties of Transforms.
				var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

				//adds a card to the deck upon a rightwards tap.
				if (pos.x > centrepoint.position.x)
					AddCardToList ();

				//discards upon a leftwards tap.
				if (pos.x < centrepoint.position.x)
					DiscardCardFromList ();
			}

			//if there are no more potential cards to add to the deck, start the game.
			if (counter >= cardSprites.Length)
				SceneManager.LoadScene ("game");

			//assignes the text displaying the card counter to display the counter value.
			cardCount_Text.text = counter.ToString();
		}

		if (currentScene.name == "game") 
		{
			Transform centre = GameObject.Find ("Centre").GetComponent<Transform> ();

			//starts the countdown before the game starts.
			if (countdown > 0)
				countdown = countdown - Time.deltaTime;

			countdown_text.text = countdown.ToString ("F");

			//stops the countdown once it has reached 0.
			if (countdown <= 0) 
			{
				countdown_text.gameObject.SetActive (false);
				currentCard.GetComponent<SpriteRenderer> ().enabled = true;
				timer_text.text = timer.ToString ();
			}

			if (Input.GetTouch (0).phase == TouchPhase.Began && Input.touchCount > 0) 
			{
				var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

				//places the card in the win pile for a rightwards tap
				if (pos.x > centre.position.x)
					WinCard ();

				//places it at the bottom of the deck for a leftwards tap.
				if (pos.x < centre.position.x)
					SkipCard ();
			}

			//if players run out of cards in play, move on to the end round screen.
			if (timer >= 60f || cardsInPlay.Count == 0) 
			{
				SceneManager.LoadScene ("finish");
				currentCard.GetComponent<SpriteRenderer> ().enabled = false;
			}
		}

		if (currentScene.name == "finish") 
		{
			//upon a touch anywhere on the screen, view the next card in the win pile.
			if (Input.GetTouch (0).phase == TouchPhase.Began && Input.touchCount > 0) 
			{
				currentCard.GetComponent<SpriteRenderer> ().enabled = false;
				counter++;
				currentCard = wonCards [counter];
			}

			//if you reach the end of the win pile, move back to the start.
			if (counter >= wonCards.Count) 
			{
				ResetWonCards ();
				counter = 0;
			}
		}
	}

	//the timer is in a CoRoutine to avoid a bug in which the timer check condition (timer == 60) does not trigger.
	IEnumerator Timer()
	{
		//this while statement counts the timer up by 1 every second.
		while (timer < 60) 
		{
			yield return new WaitForSeconds (1);
			timer++;
		}

		//once the timer reaches 60 the round is finished.
		if (timer == 60)
			SceneManager.LoadScene ("finish");
	}
}
