using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassMovement : MonoBehaviour {

    float speed = 7.5f;

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
