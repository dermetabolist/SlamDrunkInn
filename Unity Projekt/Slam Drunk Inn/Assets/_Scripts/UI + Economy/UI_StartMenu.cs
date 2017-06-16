using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_StartMenu : MonoBehaviour
{

    //lerp stuff
    float lerpTime = 0.5f;
    float currentLerpTime;
    float moveDistance = 12f;
    Vector3 startPos;
    Vector3 endPos;


    void Start()
    {
        startPos = transform.position;
        endPos = transform.position + transform.up * moveDistance;
    }

    void Update()
    {
        //background lerp 
        if (StaticHolder.Menu_active == false)
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
