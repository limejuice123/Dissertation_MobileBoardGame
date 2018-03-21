using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour 
{
	public Canvas prepcanvas;
	public Text timerText;
	public Text amountNeeded_text;
	public Slider timerSlider;
	public Text howManyLeft_Text;
	public SpriteRenderer resourceNeeded_SpriteRend;
	public SpriteRenderer background;
	public Sprite[] resourceNeeded_Sprite;
	public int howManyLeft;
	public int resourceNeeded;
	public int amountNeeded;
	public float timer;
	public bool needNewResource;
	public bool didWin;
	//public int textRandomiser;

	void Start () 
	{
		DontDestroyOnLoad (this.gameObject);
		prepcanvas = GameObject.Find ("PrepCanvas").GetComponent<Canvas> ();
		timerText = GameObject.Find ("TimerText").GetComponent<Text> ();
		timerSlider = GameObject.Find ("TimeSlider").GetComponent<Slider> ();
		howManyLeft_Text = GameObject.Find ("HowManyLeft").GetComponent<Text> ();
		resourceNeeded_SpriteRend = GameObject.Find ("ResourceNeeded").GetComponent<SpriteRenderer> ();
		background = GameObject.Find ("Background").GetComponent<SpriteRenderer> ();
		amountNeeded_text = GameObject.Find ("AmountNeeded").GetComponent<Text> ();
		howManyLeft = 20;
		timer = 180f;
		PickNewNeededResource ();
	}

	void PickNewNeededResource()
	{
		resourceNeeded = Random.Range (0, 3);
		//textRandomiser = Random.Range (0, 3);
		switch (resourceNeeded) 
		{
		case 0:
			resourceNeeded_SpriteRend.sprite = resourceNeeded_Sprite [resourceNeeded];
			//resourceNeeded_SpriteRend.color = Color.red;
			amountNeeded_text.color = Color.red;
			//background.color = redtransparent;
			Debug.Log (resourceNeeded);
			break;
		
		case 1:
			resourceNeeded_SpriteRend.sprite = resourceNeeded_Sprite [resourceNeeded];
			//resourceNeeded_SpriteRend.color = Color.blue;
			amountNeeded_text.color = Color.blue;
			//background.color = bluetransparent;
			Debug.Log (resourceNeeded);
			break;

		case 2:
			resourceNeeded_SpriteRend.sprite = resourceNeeded_Sprite [resourceNeeded];
			//resourceNeeded_SpriteRend.color = Color.yellow;
			amountNeeded_text.color = Color.yellow;
			//background.color = yellowtransparent;
			Debug.Log (resourceNeeded);
			break;
		}

		amountNeeded = Random.Range (3, 6);
		amountNeeded_text.text = "x" + amountNeeded.ToString ();
		needNewResource = false;
	}

	void Update () 
	{
		string minutes = Mathf.Floor (timer / 60).ToString("0");
		string seconds = Mathf.Floor (timer % 60).ToString ("00");

		timerText.text = minutes + ":" + seconds;
		timerSlider.value = timer;
		howManyLeft_Text.text = howManyLeft.ToString() + " to win";

		if (prepcanvas.enabled != true) 
		{
			if (timer > 0)
				timer = timer - Time.deltaTime;
			else 
			{
				didWin = false;
				SceneManager.LoadScene ("winlose");
			}

			if (needNewResource)
				PickNewNeededResource ();

			if (Input.GetTouch (0).phase == TouchPhase.Began && Input.touchCount > 0) 
			{
				Transform UpTag = GameObject.Find ("UpTag").transform;
				Transform DownTag = GameObject.Find ("DownTag").transform;

				if (Input.GetTouch (0).position.y >= DownTag.position.y || Input.GetTouch (0).position.y <= UpTag.position.y) 
				{
					PickNewNeededResource ();
					howManyLeft--;
				}
			}

			if (howManyLeft <= 0) 
			{
				didWin = true;
				SceneManager.LoadScene ("winlose");
			}
		}
	}
}
