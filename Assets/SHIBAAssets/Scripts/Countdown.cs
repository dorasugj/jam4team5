using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float startTimer = 10.0f;
	public float timer;
	public bool End = false;

	// Use this for initialization
	void Start () {
		reset ();
	}

	void reset()
	{
		timer = startTimer;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer <= 0.0f) {
			End = true;
		}
	}
}
