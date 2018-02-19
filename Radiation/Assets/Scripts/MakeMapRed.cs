using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMapRed : MonoBehaviour 
{
	public SpriteRenderer[] mapSprites;
	public float[] timerPoints;
	public float timer;

	void Start()
	{
		for (int i = 0; i < timerPoints.Length; i++) 
		{
			timerPoints [i] = Random.Range (20f, 50f);
		}
	}

	void LerpColour()
	{
		for (int y = 0; y < timerPoints.Length; y++) 
		{
			
		}
	}

	void Update () 
	{
		timer = timer + Time.deltaTime;
	}
}
