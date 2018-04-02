using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PressPlay : MonoBehaviour 
{
	public Button btn;

	void Start () 
	{
		btn = GameObject.Find ("playbutton").GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		Initiate.Fade ("game", Color.black, 2);
		//SceneManager.LoadScene ("game");
	}
}
