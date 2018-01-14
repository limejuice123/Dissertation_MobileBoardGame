using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PressPlay : MonoBehaviour 
{
	public Button playbtn;

	void Start () 
	{
		playbtn = GameObject.Find ("Play Button").GetComponent<Button>();
		playbtn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		SceneManager.LoadScene ("deckbuilding");
	}
}
