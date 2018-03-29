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
	//public Animator animator;
	public Animation anim;

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
		anim = GameObject.Find ("ResourceNeeded").GetComponent<Animation> ();
		//animator = GameObject.Find ("ResourceNeeded").GetComponent<Animator> ();
		//animator.enabled = false;
		howManyLeft = 20;
		timer = 180f;
		PickNewNeededResource ();
	}

	void PickNewNeededResource()
	{
		//animator.enabled = true;
		anim.Play();
		resourceNeeded = Random.Range (0, 3);
		switch (resourceNeeded) 
		{
		case 0:
			resourceNeeded_SpriteRend.sprite = resourceNeeded_Sprite [resourceNeeded];
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

		amountNeeded = Random.Range (3, 6);
		amountNeeded_text.text = "x" + amountNeeded.ToString ();
		needNewResource = false;
		//animator.enabled = false;
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
			{
				PickNewNeededResource ();
			}

			if (Input.GetTouch (0).phase == TouchPhase.Began && Input.touchCount > 0) 
			{
				Transform UpTag = GameObject.Find ("UpTag").transform;
				Transform DownTag = GameObject.Find ("DownTag").transform;

				var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

				if (pos.y >= DownTag.position.y && pos.y <= UpTag.position.y) 
				{
					PickNewNeededResource ();
					howManyLeft--;
				}
			}

			if (howManyLeft <= 0) 
			{
				didWin = true;
				Initiate.Fade ("winlose", Color.black, 2);
			}
		}
	}
}
