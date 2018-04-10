using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script uses the UI APIs.
using UnityEngine.UI;

//this class is responsible for the countdown present upon starting the game portion of the app.
public class Countdown : MonoBehaviour 
{
	//the canvas containing the countdown timer.
	public Canvas prepcanvas;
	//the canvas containing the rest of the UI elements.
	public Canvas regcanvas;
	//the current demand sprite.
	public SpriteRenderer sprite;
	//the demand sprite background.
	public SpriteRenderer callout;
	//the text for the countdown.
	public Text countdown;
	//the number of the timer.
	public float timer;

	void Start () 
	{
		//finds all the components of gameObjects that the variables represent, and apply them to their respective variables.
		prepcanvas = GameObject.Find ("PrepCanvas").GetComponent<Canvas> ();
		regcanvas = GameObject.Find ("Canvas").GetComponent<Canvas> ();
		countdown = GameObject.Find ("Countdown").GetComponent<Text> ();
		sprite = GameObject.Find ("ResourceNeeded").GetComponent<SpriteRenderer> ();
		callout = GameObject.Find ("Callout").GetComponent<SpriteRenderer> ();
		//disables the normal UI canvas, the demand sprite and the sprite background.
		regcanvas.enabled = false;
		prepcanvas.enabled = true;
		sprite.enabled = false;
		callout.enabled = false;
		//sets the timer to 3
		timer = 3f;
	}

	void Update () 
	{
		//counts down the timer.
		timer = timer - Time.deltaTime;
		//displays the countdown on screen, in a X:XX format.
		countdown.text = timer.ToString ("F1");

		//if the timer has run out, disable the countdown and re-enable everything else.
		if (timer <= 0) 
		{
			prepcanvas.enabled = false;
			regcanvas.enabled = true;
			sprite.enabled = true;
			callout.enabled = true;
		}
	}
}
