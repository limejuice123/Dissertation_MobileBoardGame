using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour 
{
	public Button btn;
	public RuleScript rulescript;

	void Start () 
	{
		rulescript = Camera.main.GetComponent<RuleScript> ();
		btn = this.gameObject.GetComponent<Button> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		Initiate.Fade ("mainmenu", Color.black, 2);
	}
}
