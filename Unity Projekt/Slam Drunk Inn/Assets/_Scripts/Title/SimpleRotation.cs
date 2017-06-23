using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
    float speed = .025f;

	void Update ()
    {
        transform.Rotate(Vector3.forward * -speed);
	}
}
