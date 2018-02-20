using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckHealth : MonoBehaviour 
{
	public Text healthText;
	public SpriteRenderer healthSymbol;
	public Vector2 thisTransformPosition;
	public Color[] playerColours;
	public int colourCount;
	public int[] playerHealth;

	void Start () 
	{
		healthText = GameObject.Find ("HealthText").GetComponent<Text> ();
		healthSymbol = this.gameObject.GetComponent<SpriteRenderer> ();
		colourCount = 0;
		healthSymbol.color = playerColours [colourCount];
		thisTransformPosition = new Vector2 (this.transform.position.x, this.transform.position.y);

		for (int i = 0; i < playerColours.Length; i++) 
		{
			playerHealth [i] = 50;
		}
	}

	void Update () 
	{
		healthText.text = playerHealth [colourCount].ToString ();

		if (Input.GetTouch (0).phase == TouchPhase.Began && Input.touchCount > 0) 
		{
			if (Input.GetTouch (0).position == thisTransformPosition) 
			{
				if (colourCount < playerColours.Length)
					colourCount++;
				else
					colourCount = 0;
			}
		}
	}
}
