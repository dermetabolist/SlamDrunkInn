using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_GameOverScreen : MonoBehaviour {

    float lerpTime = 0.5f;
    float currentLerpTime;
    float moveDistance = -12f;

    Vector3 startPos;
    Vector3 endPos;

    public AudioSource aud;
    public AudioClip scratch;
    bool playsound = true;

    float Timer = 0f;
    float _Timer = 0f;

    public Image Button_Back;
    public Image Button_Back_bg;
    public Text Button_Back_Text;

    void Start()
    {
        //Button_Back.canvasRenderer.SetAlpha(0.0f);
        //Button_Back.fillAmount = 0f;
        //Button_Back_bg.canvasRenderer.SetAlpha(0.0f);
        //Button_Back_Text.canvasRenderer.SetAlpha(0.0f);


        startPos = transform.position;
        endPos = transform.position + transform.up * moveDistance;
    }

    void Update()
    {
        //background lerp
        if (StaticHolder.TimeOver == true)
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

        //play sound effect
        if(StaticHolder.TimeOver == true && playsound == true)
        {
            aud.PlayOneShot(scratch, 0.75f);
            playsound = false;
        }

        ////blende button ein
        //if(StaticHolder.TimeOver == true)
        //{
        //    Timer += Time.deltaTime;
        //    if(Timer >= 1f)
        //    {
                
        //        Button_Back.CrossFadeAlpha(1.0f, 0.5f, false);
        //        Button_Back_bg.CrossFadeAlpha(1.0f, 0.5f, false);
        //        Button_Back_Text.CrossFadeAlpha(1.0f, 0.5f, false);
        //        //show results
                
        //    }
        //}
    }
}
