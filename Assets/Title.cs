using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {
    Touch t;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touchCount!=0)
        {
            t = Input.GetTouch(0);
        }

        if(t.phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel("tsty");
        }
	}
}
