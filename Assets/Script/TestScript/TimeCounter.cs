using UnityEngine;
using System.Collections;

public class TimeCounter : MonoBehaviour {
    float MAX_TIME = 10.0f;

    float Timer;

	// Use this for initialization
	void Start () {
        Timer = MAX_TIME;
	}
	
	// Update is called once per frame
	void Update () {
        Timer -= Time.deltaTime;
	}

    void OnGUI() {
        
    }
}
