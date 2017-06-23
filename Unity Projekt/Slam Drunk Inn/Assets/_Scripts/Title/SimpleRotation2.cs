using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation2 : MonoBehaviour
{
    float speed = .05f;

    void Update()
    {
        transform.Rotate(Vector3.forward * -speed);
    }
}
