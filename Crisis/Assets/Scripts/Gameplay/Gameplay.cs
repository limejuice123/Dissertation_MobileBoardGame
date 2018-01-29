using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour 
{
	public Canvas prepcanvas;
	public Text timerText;
	public Slider timerSlider;
	public Text howManyLeft_Text;
	public SpriteRenderer resourceNeeded_SpriteRend;
	public Sprite[] resourceNeeded_Sprite;
	public int howManyLeft;
	public int resourceNeeded;
	public float timer;


	void Start () 
	{
		prepcanvas = GameObject.Find ("PrepCanvas").GetComponent<Canvas> ();
		timerText = GameObject.Find ("TimerText").GetComponent<Text> ();
		timerSlider = GameObject.Find ("TimeSlider").GetComponent<Slider> ();
		howManyLeft_Text = GameObject.Find ("HowManyLeft").GetComponent<Text> ();
		resourceNeeded_SpriteRend = GameObject.Find ("ResourceNeeded").GetComponent<SpriteRenderer> ();
		howManyLeft = 20;
		timer = 300f;
		PickNewNeededResource ();
	}

	void PickNewNeededResource()
	{
		
	}

	void Update () 
	{
		string minutes = Mathf.Floor (timer / 60).ToString("0");
		string seconds = Mathf.Floor (timer % 60).ToString ("00");

		timerText.text = minutes + ":" + seconds;
		timerSlider.value = timer;
		howManyLeft_Text.text = howManyLeft.ToString() + " to go!";

		if (prepcanvas.enabled != true) 
		{
			timer = timer - Time.deltaTime;
		}
	}
}
