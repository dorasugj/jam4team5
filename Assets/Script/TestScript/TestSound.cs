using UnityEngine;
using System.Collections;

public class TestSound : MonoBehaviour {
    [SerializeField]
    AudioClip[] SE;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            audio.PlayOneShot(SE[0]);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            audio.PlayOneShot(SE[1]);
        }
	}
}
