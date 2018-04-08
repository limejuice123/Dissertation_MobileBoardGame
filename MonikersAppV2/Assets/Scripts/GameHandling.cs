﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandling : MonoBehaviour 
{
	public GameObject asThis;
	public GameObject currentCard;
	public Sprite[] cardSprites;
	public GameObject addedCard;
	public int counter = 0;
	public List<GameObject> cardsInPlay = new List<GameObject> ();

	public Scene currentScene;
	public Text cardCount_Text;

	public Text countdown_text;
	public float countdown = 3f;
	public List<GameObject> wonCards = new List<GameObject> ();
	public float timer = 0f;
	public Text timer_text;

	void Awake()
	{
		asThis = this.gameObject;
		DontDestroyOnLoad (asThis);
		cardSprites = Resources.LoadAll<Sprite> ("");
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelLoaded;
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnLevelLoaded;
	}

	void OnLevelLoaded(Scene scene, LoadSceneMode mode)
	{
		if (scene.name == "deckbuilding") 
		{
			cardCount_Text = GameObject.Find ("cardcount").GetComponent<Text> ();
			currentScene = scene;
			currentCard = GameObject.Find ("StartCard");
			currentCard.GetComponent<SpriteRenderer> ().sprite = cardSprites [counter];
			currentCard.transform.position = new Vector2 (0f, -0.4f);
			currentCard.transform.localScale = new Vector2 (0.65f, 0.65f);
		}

		if (scene.name == "game") 
		{
			currentScene = scene;
			counter = 0;
			timer_text = GameObject.Find ("timer").GetComponent<Text> ();
			countdown_text = GameObject.Find ("Countdown").GetComponent<Text> ();
			currentCard = cardsInPlay [counter];
			currentCard.transform.position = new Vector2(0f, -0.4f);
		}

		if (scene.name == "finish") 
		{
			currentScene = scene;
			counter = 0;
			currentCard = wonCards [counter];
			currentCard.transform.position = new Vector2 (0f, -0.4f);
			for (int i = 0; i < wonCards.Count; i++) 
			{
				currentCard = wonCards [i];
				currentCard.GetComponent<SpriteRenderer> ().enabled = true;
			}
		}
	}

	void AddCardToList()
	{
		addedCard = Instantiate(currentCard);
		DontDestroyOnLoad (addedCard);
		cardsInPlay.Add (addedCard);
		addedCard.GetComponent<SpriteRenderer> ().enabled = false;
		counter++;
		currentCard.transform.position = new Vector3 (0f, -0.4f, 0f);
		currentCard.GetComponent<SpriteRenderer> ().sprite = cardSprites [counter];
	}

	void DiscardCardFromList()
	{
		counter++;
		currentCard.transform.position = new Vector3 (0f, -0.4f, 0f);
		currentCard.GetComponent<SpriteRenderer> ().sprite = cardSprites [counter];
	}

	void WinCard()
	{
		try
		{
		wonCards.Add (currentCard);
		cardsInPlay.Remove (currentCard);
		currentCard.GetComponent<SpriteRenderer> ().enabled = false;
		currentCard = cardsInPlay [counter];
		currentCard.transform.position = new Vector2 (0f, -0.4f);
		}
		catch (ArgumentOutOfRangeException) 
		{
			SceneManager.LoadScene ("finish");
		}
	}

	void SkipCard()
	{
		cardsInPlay.Remove (currentCard);
		cardsInPlay.Add (currentCard);
		currentCard.GetComponent<SpriteRenderer> ().enabled = false;
		currentCard = cardsInPlay [counter];
		currentCard.transform.position = new Vector2 (0f, -0.4f);
	}

	void ResetWonCards()
	{
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
			Transform centrepoint = GameObject.Find ("CentrePoint").GetComponent<Transform> ();

			if (Input.GetTouch (0).phase == TouchPhase.Began && Input.touchCount > 0) 
			{
				var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

				if (pos.x > centrepoint.position.x)
					AddCardToList ();

				if (pos.x < centrepoint.position.x)
					DiscardCardFromList ();
			}

			if (counter >= cardSprites.Length)
				SceneManager.LoadScene ("game");

			cardCount_Text.text = counter.ToString();
		}

		if (currentScene.name == "game") 
		{
			Transform centre = GameObject.Find ("Centre").GetComponent<Transform> ();

			if (countdown > 0)
				countdown = countdown - Time.deltaTime;

			countdown_text.text = countdown.ToString ("F");

			if (countdown <= 0) 
			{
				countdown_text.gameObject.SetActive (false);
				currentCard.GetComponent<SpriteRenderer> ().enabled = true;
				timer = timer + Time.deltaTime;
				timer_text.text = timer.ToString ("F");
			}

			if (Input.GetTouch (0).phase == TouchPhase.Began && Input.touchCount > 0) 
			{
				var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

				if (pos.x > centre.position.x)
					WinCard ();

				if (pos.x < centre.position.x)
					SkipCard ();
			}

			if (timer >= 60f || cardsInPlay.Count == 0) 
			{
				SceneManager.LoadScene ("finish");
				currentCard.GetComponent<SpriteRenderer> ().enabled = false;
			}
		}

		if (currentScene.name == "finish") 
		{
			if (Input.GetTouch (0).phase == TouchPhase.Began && Input.touchCount > 0) 
			{
				currentCard.GetComponent<SpriteRenderer> ().enabled = false;
				counter++;
				currentCard = wonCards [counter];
			}

			if (counter >= wonCards.Count) 
			{
				ResetWonCards ();
				counter = 0;
			}
		}
	}
}
