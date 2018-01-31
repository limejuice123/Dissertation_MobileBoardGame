using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinOrLose : MonoBehaviour 
{
	public Button btn;
	public Text text;
	public Gameplay gameplay;

	void Start () 
	{
		btn = GameObject.Find ("backtomenu").GetComponent<Button> ();
		text = GameObject.Find ("WinLoseText").GetComponent<Text> ();
		gameplay = GameObject.Find ("GameHandler").GetComponent<Gameplay> ();
		btn.onClick.AddListener (TaskOnClick);

		if (gameplay.didWin == true)
			text.text = "You win";
		else
			text.text = "You lose";
	}

	void TaskOnClick () 
	{
		SceneManager.LoadScene ("mainmenu");
	}
}
