using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
		gamehandling.currentCard.GetComponent<SpriteRenderer> ().enabled = false;
		gamehandling.wonCards.Clear();
		gamehandling.counter = 0;
		SceneManager.LoadScene ("game");
	}
}
