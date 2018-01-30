using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public bool needNewResource;

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
		resourceNeeded = Random.Range (0, 3);
		switch (resourceNeeded) 
		{
		case 0:
			resourceNeeded_SpriteRend.sprite = resourceNeeded_Sprite [resourceNeeded];
			Debug.Log (resourceNeeded);
			break;
		
		case 1:
			resourceNeeded_SpriteRend.sprite = resourceNeeded_Sprite [resourceNeeded];
			Debug.Log (resourceNeeded);
			break;

		case 2:
			resourceNeeded_SpriteRend.sprite = resourceNeeded_Sprite [resourceNeeded];
			Debug.Log (resourceNeeded);
			break;
		}

		needNewResource = false;
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

			if (timer <= 0)
				SceneManager.LoadScene ("winlose");

			if (howManyLeft <= 0)
				SceneManager.LoadScene ("winlose");
		}
	}
}
