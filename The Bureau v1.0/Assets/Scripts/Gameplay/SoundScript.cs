using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour 
{
	public AudioListener listener;
	public AudioSource backgroundmusic_source;
	public AudioClip backgroundmusic_clip;

	public AudioSource ingameaudio;
	public AudioClip winround;
	public AudioClip skipround;

	public Button skipbutton;

	void Start () 
	{
		skipbutton = GameObject.Find ("DontHave").GetComponent<Button> ();
		skipbutton.onClick.AddListener (TaskOnClick);
		listener = Camera.main.GetComponent<AudioListener> ();
		backgroundmusic_source = Camera.main.GetComponent<AudioSource> ();
		backgroundmusic_source.clip = backgroundmusic_clip;
		backgroundmusic_source.Play ();
		ingameaudio = GameObject.Find ("InGameAudio").GetComponent<AudioSource> ();
	}

	void TaskOnClick () 
	{
		//ingameaudio.clip = skipround;
		ingameaudio.volume = 0.5f;
		ingameaudio.PlayOneShot (skipround);
	}

	void Update()
	{
		if (Input.GetTouch (0).phase == TouchPhase.Began && Input.touchCount > 0) 
		{
			Transform UpTag = GameObject.Find ("UpTag").transform;
			Transform DownTag = GameObject.Find ("DownTag").transform;

			var pos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);

			if (pos.y >= DownTag.position.y && pos.y <= UpTag.position.y) 
			{
				Debug.Log (Input.GetTouch (0).position.y);
				ingameaudio.volume = 1f;
				ingameaudio.PlayOneShot (winround);
			}

		}
	}
}
