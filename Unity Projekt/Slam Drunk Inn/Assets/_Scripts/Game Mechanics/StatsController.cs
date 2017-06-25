using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour {

    public int DrunknessLevel = 0;
    public bool MenuActive;
    public bool Countdown_Done;
    public bool TimeOver;

	void Start ()
    {
        MenuActive = true;
        Countdown_Done = false;
        TimeOver = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        StaticHolder.DrunknessLevel = DrunknessLevel;

        if(MenuActive)
        {
            StaticHolder.Menu_active = true;
        }
        if(!MenuActive)
        {
            StaticHolder.Menu_active = false;
        }

        if (Countdown_Done)
        {
            StaticHolder.Countdown_done = true;
        }
        if (!Countdown_Done)
        {
            StaticHolder.Countdown_done = false;
        }

        if (TimeOver)
        {
            StaticHolder.TimeOver = true;
        }
        if (!TimeOver)
        {
            StaticHolder.TimeOver = false;
        }

    }
}
