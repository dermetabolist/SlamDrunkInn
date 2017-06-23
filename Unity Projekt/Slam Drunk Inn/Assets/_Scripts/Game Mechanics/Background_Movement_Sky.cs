using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Movement_Sky : MonoBehaviour {

    Vector3 startMarker;
    Vector3 endMarker;
    float speed = .15F;
    private float startTime;
    private float journeyLength;

    // Use this for initialization
    void Start ()
    {
        startMarker = new Vector3(0, 11.5f, 0);
        endMarker = new Vector3(0, -13f, 0);
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker, endMarker);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(StaticHolder.Countdown_done == true)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
        }
        
    }
}
