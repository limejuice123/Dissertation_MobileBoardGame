using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour 
{
	public Canvas prepcanvas;
	public Text countdown;
	public float timer;

	void Start () 
	{
		prepcanvas = GameObject.Find ("PrepCanvas").GetComponent<Canvas> ();
		countdown = GameObject.Find ("Countdown").GetComponent<Text> ();
		prepcanvas.enabled = true;
		timer = 3f;
	}

	void Update () 
	{
		timer = timer - Time.deltaTime;
		countdown.text = timer.ToString ("F1");

		if (timer <= 0)
			prepcanvas.enabled = false;
	}
}
