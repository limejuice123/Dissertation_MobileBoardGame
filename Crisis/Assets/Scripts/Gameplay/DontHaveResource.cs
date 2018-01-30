using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DontHaveResource : MonoBehaviour 
{
	public Button btn;
	public Gameplay gameplay;
	public Text timertext;

	void Start () 
	{
		btn = GameObject.Find ("DontHave").GetComponent<Button> ();
		gameplay = GameObject.Find ("GameHandler").GetComponent<Gameplay> ();
		timertext = GameObject.Find ("TimerText").GetComponent<Text> ();
		btn.onClick.AddListener (TaskOnClick);
	}

	void TaskOnClick () 
	{
		gameplay.timer = gameplay.timer - 20;
		StartCoroutine (Flasher());
		gameplay.needNewResource = true;
	}

	IEnumerator Flasher()
	{
		for (int i = 0; i < 5; i++) 
		{
			btn.image.color = Color.red;
			timertext.color = Color.red;
			yield return new WaitForSeconds (0.1f);
			btn.image.color = Color.white;
			timertext.color = Color.white;
			yield return new WaitForSeconds (0.1f);
		}
	}
}
