using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameStartScreen : MonoBehaviour {

    string Countdown;
    public Text Countdown_Text;
    float Timer = 0f;
    bool playsound = false;
    bool startTheGame = true;

    //audio stuff
    public AudioSource aud;
    public AudioClip count;
    public AudioClip start;

    //lerp stuff
    float lerpTime = 0.5f;
    float currentLerpTime;
    float moveDistance = 12f;
    Vector3 startPos;
    Vector3 endPos;



    void Start ()
    {
        Timer = 0f;
        Countdown_Text.canvasRenderer.SetAlpha(1.0f);
        startPos = transform.position;
        endPos = transform.position + transform.up * moveDistance;
    }
	
	
	void Update ()
    {
        if(StaticHolder.Menu_active == false && StaticHolder.Countdown_done == false)
        {
            Countdown_Text.text = Countdown;
            Timer += Time.deltaTime;

            if (playsound && !aud.isPlaying && Timer < 5)
            {
                aud.PlayOneShot(count, 0.75f);
                playsound = false;
            }

            if (Timer >= 5 && startTheGame)
            {
                aud.PlayOneShot(start, 0.75f);
                startTheGame = false;
            }

            if (Timer > 1)
            {
                playsound = true;
                Countdown = "GET READY!";
            }
            if (Timer > 2)
            {
                playsound = true;
                Countdown = "3";
            }
            if (Timer > 3)
            {
                playsound = true;
                Countdown = "2";
            }
            if (Timer > 4)
            {
                playsound = true;
                Countdown = "1";
            }
            if (Timer > 5)
            {
                playsound = true;
                Countdown = "DRINK UP!";
            }
            if (Timer > 5.5)
            {
                playsound = true;
                StaticHolder.Countdown_done = true;
                Countdown_Text.CrossFadeAlpha(0.0f, 0.15f, false);
            }
        }

        if (StaticHolder.Countdown_done == true)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            //lerp!

            float t = currentLerpTime / lerpTime;
            t = Mathf.Sin(t * Mathf.PI * 0.5f);

            float perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(startPos, endPos, t);
        }

    }
}
