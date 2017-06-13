using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameOverScreen : MonoBehaviour {

    Vector3 startMarker;
    Vector3 endMarker;

    public float speed = 5.0F;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        startMarker = new Vector3(0, 12, 0);
        endMarker = new Vector3(0, 0.45f, 0);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        if(StaticHolder.TimeOver)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        }
        
    }
}
