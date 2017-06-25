using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoLerp1 : MonoBehaviour {

    Vector3 startPos;
    float speed = 5f;
    float Timer;

    protected void Start()
    {
        startPos = new Vector3(0.2f, 0, 0);
        Timer = 0f;
    }

    protected void Update()
    {
        if(StaticHolder.TimeOver)
        {
            Timer += Time.deltaTime;
            if(Timer > .5)
            {
                float distance = Mathf.Sin(Time.timeSinceLevelLoad);
                transform.position = startPos + Vector3.up * (distance / 4);
            }
            
        }
        else
        {
            transform.position = transform.position;
        }
        
    }
}

