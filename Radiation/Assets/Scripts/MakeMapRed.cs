using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMapRed : MonoBehaviour 
{
	public TimeCount timeCount;
	public SpriteRenderer thisSpriteRend;
	public float timePoint;
	public bool isDead;
	public Vector2 transformPosition;

	void Start () 
	{
		timeCount = GameObject.Find ("Map").GetComponent<TimeCount> ();
		timePoint = Random.Range (50f, 100f);
		thisSpriteRend = this.GetComponent<SpriteRenderer> ();
		isDead = false;
		transformPosition = new Vector2 (this.transform.position.x, this.transform.position.y);
	}

	void Update () 
	{
		thisSpriteRend.color = Color.Lerp (Color.white, Color.red, timeCount.timer / timePoint);

		if (timeCount.timer >= timePoint)
			isDead = true;

		if (isDead == true)
			thisSpriteRend.color = Color.grey;

		if (Input.GetTouch (0).phase == TouchPhase.Began && Input.touchCount > 0) 
		{
			if (Input.GetTouch (0).position == transformPosition)
				Debug.Log ("meme");
		}
	}
}
