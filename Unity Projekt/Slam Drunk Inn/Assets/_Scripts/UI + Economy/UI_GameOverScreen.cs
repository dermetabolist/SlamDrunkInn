using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_GameOverScreen : MonoBehaviour {

    float lerpTime = 0.5f;
    float currentLerpTime;
    float moveDistance = -10.3f;

    Vector3 startPos;
    Vector3 endPos;

    public AudioSource aud;
    public AudioClip scratch;
    bool playsound = true;

    float Timer = 0f;
    float _Timer = 0f;

    void Start()
    {
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
    }
}
