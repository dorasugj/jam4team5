using UnityEngine;
using System.Collections;

public class TouchTest : MonoBehaviour {
    const int MAX_TOUCH = 4;

    KeyCode[] keys = { KeyCode.A,KeyCode.S , KeyCode.K,KeyCode.L };
    bool[] isTouch = new bool[MAX_TOUCH];
    public GameObject test;
    private Touch[] touch = new Touch[MAX_TOUCH];
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Input.touchCount);
        for (int i = 0; i < MAX_TOUCH; i++)
        {
            if (Input.touchCount != 0)
            {
                touch[i] = Input.GetTouch(i);
                Debug.Log(touch[i].phase);
                if (touch[i].phase == TouchPhase.Began)
                {
                    isTouch[i] = true;
                    Instantiate(test, new Vector3(0,i,0), Quaternion.identity);
                }
                else if(touch[i].phase == TouchPhase.Ended||touch[i].phase==TouchPhase.Canceled) {
                    isTouch[i] = false;
                }
            }
        }
        Debug.Log("動いてる");
        
	}

    void OnGUI() {
        for (int i = 0; i < MAX_TOUCH; i++)
        {
            GUI.Label(new Rect(0, 10*i, 100, 100),i+"="+isTouch[i]);
            GUI.Label(new Rect(100, 10 * i, 100, 100),i+":X="+touch[i].position.x+"Y="+touch[i].position.y);
        }
        GUI.Label(new Rect(0, 500, 100, 100), "Wid=" + Screen.width + "Heig = " + Screen.height);

    }

    void a() {
        for (int i = 0; i < MAX_TOUCH; i++)
        {
            if (Input.GetKey(keys[i])) isTouch[i] = true;
            else isTouch[i] = false;
        }
    }
}
