using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour 
{
	public Canvas prepcanvas;
	public Canvas regcanvas;
	public SpriteRenderer sprite;
	public SpriteRenderer callout;
	public Text countdown;
	public float timer;

	void Start () 
	{
		prepcanvas = GameObject.Find ("PrepCanvas").GetComponent<Canvas> ();
		regcanvas = GameObject.Find ("Canvas").GetComponent<Canvas> ();
		countdown = GameObject.Find ("Countdown").GetComponent<Text> ();
		sprite = GameObject.Find ("ResourceNeeded").GetComponent<SpriteRenderer> ();
		callout = GameObject.Find ("Callout").GetComponent<SpriteRenderer> ();
		regcanvas.enabled = false;
		prepcanvas.enabled = true;
		sprite.enabled = false;
		callout.enabled = false;
		timer = 3f;
	}

	void Update () 
	{
		timer = timer - Time.deltaTime;
		countdown.text = timer.ToString ("F1");

		if (timer <= 0) 
		{
			prepcanvas.enabled = false;
			regcanvas.enabled = true;
			sprite.enabled = true;
			callout.enabled = true;
		}
	}
}
