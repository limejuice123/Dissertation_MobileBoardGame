using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script uses the UI APIs
using UnityEngine.UI;

//this class controls in game sounds
public class SoundScript : MonoBehaviour 
{
	//these variables are for the components associated with the background music
	public AudioListener listener;
	public AudioSource backgroundmusic_source;
	public AudioClip backgroundmusic_clip;

	//these variables are associated with sounds that play as feedback to player action.
	public AudioSource ingameaudio;
	public AudioClip winround;
	public AudioClip skipround;

	//variable holding the skip button.
	public Button skipbutton;

	void Start () 
	{
		skipbutton = GameObject.Find ("DontHave").GetComponent<Button> ();
		skipbutton.onClick.AddListener (TaskOnClick);
		listener = Camera.main.GetComponent<AudioListener> ();
		//gets the audiosource attached to the main camera, and plays the background music.
		backgroundmusic_source = Camera.main.GetComponent<AudioSource> ();
		backgroundmusic_source.clip = backgroundmusic_clip;
		backgroundmusic_source.Play ();
		ingameaudio = GameObject.Find ("InGameAudio").GetComponent<AudioSource> ();
	}

	void TaskOnClick () 
	{
		//sets the volume of the skip sound and plays it once
		ingameaudio.volume = 0.5f;
		ingameaudio.PlayOneShot (skipround);
	}

	void Update()
	{
		//if the player has touched the screen...
		if (Input.GetTouch (0).phase == TouchPhase.Began && Input.touchCount > 0) 
		{
			//local variables for tracking of acceptable tap bounds.
			Transform UpTag = GameObject.Find ("UpTag").transform;
			Transform DownTag = GameObject.Find ("DownTag").transform;

			//local variable converting tap position to orthographic values shared by transforms.
			var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

			//...and it's within acceptable bounds...
			if (pos.y >= DownTag.position.y && pos.y <= UpTag.position.y) 
			{
				Debug.Log (Input.GetTouch (0).position.y);
				//...play the win round sound once
				ingameaudio.volume = 1f;
				ingameaudio.PlayOneShot (winround);
			}

		}
	}
}
