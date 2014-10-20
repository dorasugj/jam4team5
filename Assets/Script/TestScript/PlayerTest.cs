using UnityEngine;
using System.Collections;

public class PlayerTest : MonoBehaviour {
    Vector3 pos;

	// Use this for initialization
	void Start () {
        pos = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
       transform.position = pos;
	}
}
