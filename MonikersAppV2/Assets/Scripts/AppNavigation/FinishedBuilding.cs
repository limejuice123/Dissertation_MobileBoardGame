using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishedBuilding : MonoBehaviour 
{
	public Button finishedButton;

	void Start () 
	{
		finishedButton = GetComponent<Button>();
		finishedButton.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick()
	{
		SceneManager.LoadScene ("game");
	}
}
