using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSoundController : MonoBehaviour {

    public AudioSource aud;
    public AudioClip main_theme;
    public AudioClip game_over;

    bool changeAudio = true;
    bool playTheme = true;


	// Use this for initialization
	void Start ()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Time.timeSinceLevelLoad > 5.5f && playTheme == true)
        {
            aud.clip = main_theme;
            aud.Play();
            playTheme = false;
        }

		if(StaticHolder.TimeOver == true && changeAudio == true)
        {
            AudioSource audio = GetComponent<AudioSource>();
            aud.clip = game_over;
            aud.Play();
            changeAudio = false;
        }
	}
}
