using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackground : MonoBehaviour 
{
	public AudioListener listener;
	public AudioSource source;
	public AudioClip clip;

	void Start () 
	{
		listener = Camera.main.GetComponent<AudioListener> ();
		source = Camera.main.GetComponent<AudioSource> ();
		source.clip = clip;
		source.Play();
	}
}
