using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoLerp : MonoBehaviour {

    Vector3 startPos;
    float speed = 5f;

    protected void Start()
    {
        startPos = transform.position;
    }

    protected void Update()
    {
        float distance = Mathf.Sin(Time.timeSinceLevelLoad);
        transform.position = startPos + Vector3.up * (distance/4);
    }
}

