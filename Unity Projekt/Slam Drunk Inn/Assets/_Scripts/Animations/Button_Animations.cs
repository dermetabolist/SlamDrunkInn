using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Animations : MonoBehaviour {

    Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (StaticHolder.Menu_active == true && StaticHolder.Countdown_done == false && StaticHolder.TimeOver == false && StaticHolder.GameWon == false)
        {
            anim.SetBool("Menu_Active", true);
        }
        else
        {
            anim.SetBool("Menu_Active", false);
        }

        if (StaticHolder.Menu_active == false && StaticHolder.Countdown_done == false && StaticHolder.TimeOver == false && StaticHolder.GameWon == false)
        {
            anim.SetBool("Countdown_Active", true);
        }
        else
        {
            anim.SetBool("Countdown_Active", false);
        }

        if (StaticHolder.Menu_active == false && StaticHolder.Countdown_done == true && StaticHolder.TimeOver == false && StaticHolder.GameWon == false)
        {
            anim.SetBool("Game_Active", true);
        }
        else
        {
            anim.SetBool("Game_Active", false);
        }

        if (StaticHolder.Menu_active == false && StaticHolder.Countdown_done == true && StaticHolder.TimeOver == true && StaticHolder.GameWon == false || StaticHolder.Menu_active == false && StaticHolder.Countdown_done == true && StaticHolder.TimeOver == false && StaticHolder.GameWon == true)
        {
            anim.SetBool("GameOver_Active", true);
        }
        else
        {
            anim.SetBool("GameOver_Active", false);
        }
    }
}
