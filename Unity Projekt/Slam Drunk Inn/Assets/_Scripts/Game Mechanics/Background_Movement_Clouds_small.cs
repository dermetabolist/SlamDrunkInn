using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Movement_Clouds_small : MonoBehaviour {

    Vector3 startMarker;
    Vector3 endMarker;
    float speed = .15F;
    private float startTime;
    private float journeyLength;

    bool moveright = true;
    bool moveleft = false;

    void Start()
    {
        startMarker = new Vector3(-11.5f, -0.35f, 0);
        endMarker = new Vector3(10.4f, -0.35f, 0);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);
    }
    void Update()
    {
        if(StaticHolder.Countdown_done == true)
        {
            if (transform.position.x <= -11f)
            {
                moveright = true;
                moveleft = false;
            }
            if (transform.position.x >= 10f)
            {
                moveright = false;
                moveleft = true;
            }

            if (moveright)
            {
                MoveRight();
            }
            if (moveleft)
            {
                MoveLeft();
            }
        }
        
    }

    void MoveRight()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
    }

    void MoveLeft()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(endMarker, startMarker, fracJourney);
    }
}
