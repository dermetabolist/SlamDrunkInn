using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameWinScreen : MonoBehaviour {

    float lerpTime = 0.5f;
    float currentLerpTime;
    float moveDistance = -10.3f;

    Vector3 startPos;
    Vector3 endPos;

    public AudioSource aud;
    public AudioClip cheer;
    bool playsound = true;

    void Start()
    {
        startPos = transform.position;
        endPos = transform.position + transform.up * moveDistance;
        StaticHolder.GameWon = false;
    }


    void Update()
    {
      
        //background lerp
        if (StaticHolder.GameWon == true)
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
        if (StaticHolder.GameWon == true && playsound == true)
        {
            aud.PlayOneShot(cheer, 0.75f);
            playsound = false;
        }
    }
}
