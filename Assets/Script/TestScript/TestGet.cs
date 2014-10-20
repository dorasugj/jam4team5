using UnityEngine;
using System.Collections;

public class TestGet : MonoBehaviour {
    bool[] Buttons = new bool[4];

    SEPlayer se;

    Rect[] r = {
                   new Rect(Screen.width / 4, Screen.height / 4, 100, 100) ,
                   new Rect(Screen.width/4 * 3,Screen.height/4,100,100),
                   new Rect(Screen.width/4,Screen.height/4*3,100,100),
                   new Rect(Screen.width/4*3,Screen.height/4*3,100,100),
               };

	// Use this for initialization
	void Start () {
        se = GetComponent<SEPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < 4; i++)
        {
            Buttons[i] = Controller.GetButtonState(i);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            se.Play(SEName.START_CHIME);
        }
	}

    void OnGUI() { 
        for(int i = 0;i<4;i++)
        {
            GUI.Label(new Rect(0,10*i,100,100),i+""+Buttons[i]);
            if (Buttons[i]) {
                GUI.Label(r[i], "ThisButtonIsOn");
            }
        }
    }
}
