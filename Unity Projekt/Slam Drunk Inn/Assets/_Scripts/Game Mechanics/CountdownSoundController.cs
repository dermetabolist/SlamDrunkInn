using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownSoundController : MonoBehaviour {

    float Timer = 0f;
    public AudioSource aud;
    public AudioClip count;

	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Timer += Time.deltaTime;
  
		if(Timer == 0)
        {
            aud.PlayOneShot(count, 0.75f);
        }

        if (Timer == 2)
        {
            aud.PlayOneShot(count, 0.75f);
        }

        if (Timer == 3)
        {
            aud.PlayOneShot(count, 0.75f);
        }

        if (Timer == 4)
        {
            aud.PlayOneShot(count, 0.75f);
        }

        //if (Timer == 0)
        //{
        //    aud.PlayOneShot(start, 0.75f);
        //}

    }
}
