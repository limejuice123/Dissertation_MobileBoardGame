using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script uses the UI and SceneManagement APIs
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//this class handles most of the gameplay.
public class Gameplay : MonoBehaviour 
{
	//the canvas with the countdown on it.
	public Canvas prepcanvas;
	//the text displaying the timer
	public Text timerText;
	//the text displaying the amount of each report needed.
	public Text amountNeeded_text;
	//the slider displaying the timer
	public Slider timerSlider;
	//the text displaying how many rounds are left.
	public Text howManyLeft_Text;
	//the sprite renderer for the report demand
	public SpriteRenderer resourceNeeded_SpriteRend;
	//the sprite renderer for the background of the app
	public SpriteRenderer background;
	//an array of potential report demands
	public Sprite[] resourceNeeded_Sprite;
	//the integer tracking how many rounds are left
	public int howManyLeft;
	//the report being demanded
	public int resourceNeeded;
	//the amount of said report needed
	public int amountNeeded;
	//the timer
	public float timer;
	//checks if the players are on a new round
	public bool needNewResource;
	//checks if the players won
	public bool didWin;
	//the animation for the changing of rounds
	public Animation anim;

	void Start () 
	{
		//makes sure that the object containing this script isn't destroyed between scenes.
		DontDestroyOnLoad (this.gameObject);
		//finds the components of gameObjects that the variables represent, and assign them to said variables.
		prepcanvas = GameObject.Find ("PrepCanvas").GetComponent<Canvas> ();
		timerText = GameObject.Find ("TimerText").GetComponent<Text> ();
		timerSlider = GameObject.Find ("TimeSlider").GetComponent<Slider> ();
		howManyLeft_Text = GameObject.Find ("HowManyLeft").GetComponent<Text> ();
		resourceNeeded_SpriteRend = GameObject.Find ("ResourceNeeded").GetComponent<SpriteRenderer> ();
		background = GameObject.Find ("Background").GetComponent<SpriteRenderer> ();
		amountNeeded_text = GameObject.Find ("AmountNeeded").GetComponent<Text> ();
		anim = GameObject.Find ("ResourceNeeded").GetComponent<Animation> ();
		//assigns how many rounds in the game.
		howManyLeft = 20;
		//assigns the timer
		timer = 180f;
		//picks a random report demand to start off.
		PickNewNeededResource ();
	}

	//this void is responsible for picking a new report demand after the previous round is completed.
	void PickNewNeededResource()
	{
		//plays the flashing animation when changing rounds.
		anim.Play();
		//picks a random report demand (each is assigned an int value from 0 to 2)
		resourceNeeded = Random.Range (0, 3);
		switch (resourceNeeded) 
		{
		case 0:
			//changes the card displayed to the new one picked by the randomiser.
			resourceNeeded_SpriteRend.sprite = resourceNeeded_Sprite [resourceNeeded];
			//changes the amountNeeded text colour to reflect the colour of the card displayed.
			amountNeeded_text.color = Color.red;
			Debug.Log (resourceNeeded);
			break;
		
		case 1:
			resourceNeeded_SpriteRend.sprite = resourceNeeded_Sprite [resourceNeeded];
			amountNeeded_text.color = Color.blue;
			Debug.Log (resourceNeeded);
			break;

		case 2:
			resourceNeeded_SpriteRend.sprite = resourceNeeded_Sprite [resourceNeeded];
			amountNeeded_text.color = Color.yellow;
			Debug.Log (resourceNeeded);
			break;
		}

		//sets the amount of reports needed to a random int value between 3 and 5
		amountNeeded = Random.Range (3, 6);
		//displays the text showing the amountNeeded
		amountNeeded_text.text = "x" + amountNeeded.ToString ();
		//says to the app that a new demand is not needed at the moment.
		needNewResource = false;
	}

	void Update () 
	{
		//converts the time variable to a 60-second-to-a-minute display style
		string minutes = Mathf.Floor (timer / 60).ToString("0");
		string seconds = Mathf.Floor (timer % 60).ToString ("00");

		//displays the timer text in a way that reflects a standard stopwatch-style clock (minutes : seconds)
		timerText.text = minutes + ":" + seconds;
		//sets the slider to the same value as the timer variable
		timerSlider.value = timer;
		//displays the text showing how many rounds are left.
		howManyLeft_Text.text = howManyLeft.ToString() + " to win";

		//only run this code if the countdown has stopped.
		if (prepcanvas.enabled != true) 
		{
			//run the timer only if it is greater than 0
			if (timer > 0)
				timer = timer - Time.deltaTime;
			//if the timer has run out, load the lose state
			else 
			{
				didWin = false;
				SceneManager.LoadScene ("winlose");
			}

			//if the round is complete, move onto the next
			if (needNewResource) 
			{
				PickNewNeededResource ();
			}

			//run this code if the user has touched the screen
			if (Input.GetTouch (0).phase == TouchPhase.Began && Input.touchCount > 0) 
			{
				//local variables that track the acceptable tap areas that will advance the gameplay.
				Transform UpTag = GameObject.Find ("UpTag").transform;
				Transform DownTag = GameObject.Find ("DownTag").transform;

				//local variable that converts the touch position to orthographic values shared by transforms.
				var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

				//if the tap was within acceptable bounds...
				if (pos.y >= DownTag.position.y && pos.y <= UpTag.position.y) 
				{
					//...advance to the next round, and decrease how many rounds are needed to win
					PickNewNeededResource ();
					howManyLeft--;
				}
			}

			//if there are no rounds left to win, load the win state
			if (howManyLeft <= 0) 
			{
				didWin = true;
				//fade out the screen for a transition to the next scene (FlatTutorials, 2017)
				Initiate.Fade ("winlose", Color.black, 2);
			}
		}
	}
}

//FlatTutorials (2017). Simple Scene Fade Load System. Available: https://assetstore.unity.com/packages/tools/particles-effects/simple-fade-scene-transition-system-81753. Last accessed 10th April 2018 
