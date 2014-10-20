using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    //タッチは4つまで見る。
    private static int MAX_TOUCH = 4;

    //PC上でも動作するよう、キーボードを取得
    private static KeyCode[] Keys = { KeyCode.A, KeyCode.S, KeyCode.LeftArrow, KeyCode.RightArrow };


    //どのタッチがonになっているか。
    private static bool[] IsTouch = new bool[MAX_TOUCH];

    //どのボタンがタッチされているか
    private static bool[] IsButtonOn = new bool[MAX_TOUCH];

    private Touch TouchEvent;

    public static int GET_MAX_TOUCH{
                                   get {return MAX_TOUCH;} 
                                   }


	// Use this for initialization
	void Start () {
	
	}

    /// <summary>
    /// スクリーン上のどこがタッチされたかを取得するメソッド。
    /// 0=左上
    /// 1=右上
    /// 2=左下
    /// 3=右下
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public static bool GetButtonState(int index) {
        return IsButtonOn[index];
    }


	// Update is called once per frame
	void Update () {
        FlameInit();
        OnTouch();
   //     OnKeybordInput();
	}

    //フレームごとに初期化する処理
    void FlameInit() {
        for (int i = 0; i < MAX_TOUCH; i++)
        {
            IsTouch[i] = false;
            IsButtonOn[i] = false;
        }
    }


    //タッチされた際の処理。戻り値は1つでもタッチされていたかどうか
    bool OnTouch() {
        bool Touch = false;
        for (int i = 0; i < MAX_TOUCH; i++)
        {
            if (Input.touchCount > 0)
            {
                TouchEvent = Input.GetTouch(i);
                //まずタッチされているかどうかを見る
                if (TouchEvent.phase == TouchPhase.Began || TouchEvent.phase == TouchPhase.Moved || TouchEvent.phase == TouchPhase.Stationary)
                {
                    IsTouch[i] = true;
                    Touch = true;
                }
                //次に。タッチされていたらどこのボタンがタッチされているかを見る
                if (IsTouch[i])
                {
                    ButtonTouch(TouchEvent);
                }
            }
            else break;

         }
        return Touch;
    }


    //どのボタンがタッチされたかを見る
    void ButtonTouch(Touch Event)
    {
        Vector2 Tpos = Event.position;
        float Wid = Screen.width;
        float Heig = Screen.height;
        //左上
        if (Tpos.x< Wid / 2.0f&& Tpos.y > Heig/2.0f) {
            IsButtonOn[0] = true;
        }
        //右上
        else if (Tpos.x > Wid / 2.0f && Tpos.y > Heig / 2.0f) {
            IsButtonOn[1] = true;
        }
        //左下
        else if (Tpos.x < Wid / 2.0f && Tpos.y < Heig / 2.0f)
        {
            IsButtonOn[2] = true;
        }
        //右下
        else if (Tpos.x > Wid / 2.0f && Tpos.y < Heig / 2.0f)
        {
            IsButtonOn[3] = true;
        }
    }

    
    //キーボード入力用メソッド
    bool OnKeybordInput() {
        bool IsInput = false;

        for (int i = 0; i < MAX_TOUCH; i++)
        {
            if (Input.GetKeyDown(Keys[i]))
            {
                IsButtonOn[i] = true;
            }
        }


            return false;
    }
    
}
