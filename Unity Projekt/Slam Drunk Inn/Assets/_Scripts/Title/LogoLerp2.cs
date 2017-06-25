using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoLerp2 : MonoBehaviour {

    Vector3 startPos;
    float speed = 5f;
    float Timer;

    void Start()
    {
        startPos = new Vector3(0, 0, 0);
        Timer = 0f;
    }

    void Update()
    {
        if(StaticHolder.GameWon)
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

