using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameOverScreen_bottom : MonoBehaviour
{

    float lerpTime = 0.5f;
    float currentLerpTime;
    float moveDistance = 8.62f;

    Vector3 startPos;
    Vector3 endPos;
    
	// Use this for initialization
	void Start ()
    {
        startPos = transform.position;
        endPos = transform.position + transform.up * moveDistance;
    }
	
	// Update is called once per frame
	void Update ()
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
    }
}
