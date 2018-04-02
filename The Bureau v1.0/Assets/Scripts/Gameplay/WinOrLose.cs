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
			text.text = "The recent congressional audit has found that your services were invaluable to the country during this term. The cabinet has decided to let your ministry continue with its current apparatus over the course of the next term. YOU WIN!";
		else
			text.text = "The recent congressional audit has found that there were large flaws in the running of this ministry during the course of the term. A civil service reshuffle is imminent, with you on the chopping block first. YOU LOSE!";
	}

	void TaskOnClick () 
	{
		Initiate.Fade ("mainmenu", Color.black, 2);
		//SceneManager.LoadScene ("mainmenu");
	}
}
