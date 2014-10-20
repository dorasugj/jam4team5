using UnityEngine;
using System.Collections;

public enum SEName { 
    START_CHIME = 0,
    FINISH_CHIME = 1,
}
//サウンドの再生用クラス
public class SEPlayer : MonoBehaviour {
    [SerializeField]
    AudioClip[] SE;
    
    public void Play(SEName name)
    {
        audio.PlayOneShot(SE[(int)name]);
    }
}
