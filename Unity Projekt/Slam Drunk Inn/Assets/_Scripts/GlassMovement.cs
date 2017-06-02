using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassMovement : MonoBehaviour {

    float speed = 7.5f;

    bool TouchedFloor = false;
    float Timer = 0f;

    //soundkram
    public AudioClip swoosh;
    public AudioClip shatter;
    public AudioSource audio;

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if(TouchedFloor == true)
        {
            Timer += Time.deltaTime;
            if (Timer > 1)
            {
                Destroy(gameObject);
            }
        }
    }

    //
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Edge")
        {
            audio.PlayOneShot(swoosh, 1f);
        }

        if (collision.tag == "Floor")
        {
            audio.PlayOneShot(shatter, 1f);
            TouchedFloor = true;       
        }
    }
}
