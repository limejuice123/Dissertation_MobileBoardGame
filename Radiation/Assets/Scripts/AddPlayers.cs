using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AddPlayers : MonoBehaviour 
{
	public InputField player1;
	public InputField player2;
	public InputField player3;
	public InputField player4;
	public InputField player5;
	public Button ready;

	public string player1name;
	public string player2name;
	public string player3name;
	public string player4name;
	public string player5name;

	void Start () 
	{
		DontDestroyOnLoad (this.gameObject);
		player1 = GameObject.Find ("Player1").GetComponent<InputField> ();
		player2 = GameObject.Find ("Player2").GetComponent<InputField> ();
		player3 = GameObject.Find ("Player3").GetComponent<InputField> ();
		player4 = GameObject.Find ("Player4").GetComponent<InputField> ();
		player5 = GameObject.Find ("Player5").GetComponent<InputField> ();
		ready = GameObject.Find ("Ready").GetComponent<Button> ();
		ready.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		SceneManager.LoadScene ("ingame");
	}

	void Update()
	{
		player1name = player1.text;
		player2name = player2.text;
		player3name = player3.text;
		player4name = player4.text;
		player5name = player5.text;
	}
}
