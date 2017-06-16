using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoLerp : MonoBehaviour {

    Vector3 startMarker;
    Vector3 endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    bool movedown = true;
    bool moveup = false;

    void Start()
    {
        startMarker = new Vector3(0, 2.3f, 0);
        endMarker = new Vector3(0, 1.7f, 0);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);
    }
    void Update()
    {   
        if(transform.position.y >= 2.3f)
        {
            movedown = true;
            moveup = false;
        }
        if (transform.position.y <= 1.7f)
        {
            movedown = false;
            moveup = true;
        }

        if(movedown)
        {
            MoveDown();
        }
        if(moveup)
        {
            MoveUp();
        }
    }

    void MoveDown()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
    }

    void MoveUp()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(endMarker, startMarker, fracJourney);
    }
}
