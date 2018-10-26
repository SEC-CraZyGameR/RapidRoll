using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public GameObject mute;
    public GameObject Unmute;

    void Start()
    {

        if (AudioListener.pause == true)
        {
            Unmute.SetActive(true);
            mute.SetActive(false);
        }
        else if (AudioListener.pause == false)
        {
            mute.SetActive(true);
            Unmute.SetActive(false);
        }
    }
    public void Mute()
    {
        AudioListener.pause = true;
        Unmute.SetActive(true);
        mute.SetActive(false);
    }
    public void UnMute()
    {
        AudioListener.pause = false;
        Unmute.SetActive(false);
        mute.SetActive(true);
    }
}
