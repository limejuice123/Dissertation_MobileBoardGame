using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour 
{
	public Button exit;
	public GameObject gamehandler;

	void Start () 
	{
		exit = GameObject.Find ("Exit").GetComponent<Button> ();
		exit.onClick.AddListener (TaskOnClick);
		gamehandler = GameObject.Find ("GameHandler").GetComponent<GameObject> ();
	}

	void TaskOnClick ()
	{
		Destroy (gamehandler);
		SceneManager.LoadScene ("mainmenu");
	}
}
