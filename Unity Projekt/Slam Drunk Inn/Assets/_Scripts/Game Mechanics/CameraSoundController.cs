using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSoundController : MonoBehaviour {

    public AudioSource aud;
    public AudioClip menu_theme;
    public AudioClip main_theme;
    public AudioClip game_over;
    public AudioClip game_won;

    bool changeAudio = true;
    bool playTheme = true;
    bool playIntro = true;


	// Use this for initialization
	void Start ()
    {
        AudioSource audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(StaticHolder.Menu_active == true && playIntro == true)
        {
            aud.clip = menu_theme;
            aud.Play();
            playIntro= false;
        }

        if(StaticHolder.Menu_active == false && StaticHolder.Countdown_done == false)
        {
            aud.volume -= (Time.deltaTime * 0.2f);
        }

        if(StaticHolder.Countdown_done && playTheme == true)
        {
            aud.clip = main_theme;
            aud.volume = 1;
            aud.Play();
            playTheme = false;
        }

		if(StaticHolder.TimeOver == true && changeAudio == true)
        {
            AudioSource audio = GetComponent<AudioSource>();
            aud.clip = game_over;
            aud.volume = 0.75f;
            aud.Play();
            changeAudio = false;
        }

        if (StaticHolder.TimeOver == false && StaticHolder.GameWon == true && changeAudio == true)
        {
            AudioSource audio = GetComponent<AudioSource>();
            aud.clip = game_won;
            aud.volume = 0.75f;
            aud.Play();
            changeAudio = false;
        }
    }
}
