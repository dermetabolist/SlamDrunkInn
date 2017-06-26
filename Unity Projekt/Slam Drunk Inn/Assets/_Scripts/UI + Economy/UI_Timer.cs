using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour {

    public Text counterText;
    public static float TimeLeft = 60f;

    float Timer;
    bool playSound;
    public AudioSource aud;
    public AudioClip CountDown;
    

	// Use this for initialization
	void Start () {
        counterText = GetComponent<Text>();
        playSound = false;
        Timer = 0f;
        counterText.color = new Color(0.4588f, 0, 0.588f, 1);
    }
	
	// Update is called once per frame
	void Update () {

        if(TimeLeft > 0 && StaticHolder.Countdown_done == true)
        {
            TimeLeft -= Time.deltaTime;
            counterText.text = "" + Mathf.Round(TimeLeft);
        }

        if(TimeLeft <= 0)
        {
            StaticHolder.TimeOver = true;
        }

        ColourChange();

        //Audio Countdown
        //if(TimeLeft < 10 && TimeLeft > 0)
        //{
        //    Timer += Time.deltaTime;
        //    if(Timer > 0)
        //    {
        //        playSound = true;
        //        Timer = 0f;
        //    }
        //}

        //if(playSound && !aud.isPlaying)
        //{
        //    aud.PlayOneShot(CountDown, 1f);
        //    playSound = false;
        //}
    }

    void ColourChange()
    {
        if (TimeLeft < 10)
        {
            counterText.color = new Color(1, 0, 0.5176f, 1);
        }
        else
        {
            counterText.color = new Color(0.4588f, 0, 0.588f, 1);
        }


    }
}
