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
	}

	void TaskOnClick ()
	{
		if (GameObject.Find ("GameHandler")) 
		{
			Destroy (GameObject.Find ("GameHandler"));
		}

		Initiate.Fade ("mainmenu", Color.black, 2);
		//SceneManager.LoadScene ("mainmenu");
	}
}
