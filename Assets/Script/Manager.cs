using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {
    enum SceneState { 
        Start,
        Game,
        End,
    }
    SceneState state;
    private static bool IsControll;

    static int Dusts;

    public static bool GetIsControll {
        get { return IsControll; }
    }

	// Use this for initialization
	void Start () {
        SEPlayer se = GetComponent<SEPlayer>();
        se.Play(SEName.START_CHIME);

        Dusts = GameObject.FindGameObjectsWithTag("Dust").Length;

	}

    void GetDust() {
        Dusts--;
        if (Dusts <= 0)
        {
            state = SceneState.End;
        }
    }

	
	// Update is called once per frame
	void Update () {
        switch (state)
        {
            case SceneState.Start:
                bool isStart = false;
                IsControll = false;
                for (int i = 0; i < Controller.GET_MAX_TOUCH; i++)
                {
                    if (Controller.GetButtonState(i))
                    {
                        isStart = true;
                    }
                    else
                    {
                        isStart = false;
                        break;
                    }
                }
                if (isStart)
                {
                    state = SceneState.Game;
                    IsControll = true;
                    isStart = false;
                }
                break;
            case SceneState.Game:
                IsControll = true;
                break;
            case SceneState.End:
                IsControll = false;
                Application.LoadLevel("Title");
                break;
        }
	}

    void OnGUI() {
        GUI.Label(new Rect(100, 0, 100, 100), "" + Dusts);
    }
}
