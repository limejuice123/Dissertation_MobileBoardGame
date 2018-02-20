using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour 
{
	public float timer;

	void Update () 
	{
		timer = timer + Time.deltaTime;
	}
}
