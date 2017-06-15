using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameStartScreen_bottom : MonoBehaviour {


    //lerp stuff
    float lerpTime = 0.5f;
    float currentLerpTime;
    float moveDistance = -12f;
    Vector3 startPos;
    Vector3 endPos;

    // Use this for initialization
    void Start()
    {
        
        startPos = transform.position;
        endPos = transform.position + transform.up * moveDistance;
    }

    // Update is called once per frame
    void Update ()
    {
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
