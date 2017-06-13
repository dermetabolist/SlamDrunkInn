using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCalculator : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip Timeget;

    int TimeAdd;
    bool LooseHealth;
    float Timer;

    private void Start()
    {
        StaticHolder.DrunknessLevel_threshold = 10;
    }

    private void Update()
    {
        

        TimeAdd = 1 + (StaticHolder.Combo / 10);
        DrunknessLevelCalculator();
        DrunknessLevel_Threshold_Calculator();

        DisorientedHealth_Calculator();
    }

    private void DisorientedHealth_Calculator()
    {
        Timer += Time.deltaTime;
        if(Timer > 1 && StaticHolder.Disoriented_level < 5 && StaticHolder.Disoriented_level > 0)
        {
            StaticHolder.Disoriented_level--;
            Timer = 0f;
        }

        if(PlayerHeadCollision.Hit_Table == true && StaticHolder.Disoriented == false)
        {
            Timer = 0f;
        }

        if(StaticHolder.Disoriented_level == 5 && StaticHolder.Disoriented == false)
        {
            Timer = 0;
            StaticHolder.Disoriented = true;
        }

        if(StaticHolder.Disoriented == true && Timer > 3)
        {
            StaticHolder.Disoriented = false;
            StaticHolder.Disoriented_level = 0;
        }
        



        

    }


    private void DrunknessLevel_Threshold_Calculator()
    {
        StaticHolder.DrunknessLevel_threshold = 10 + (StaticHolder.DrunknessLevel * 3);
    }

    void DrunknessLevelCalculator()
    {

        if (StaticHolder.Drinks_sinceLevelStart >= StaticHolder.DrunknessLevel_threshold)
        {
            StaticHolder.DrunknessLevel++;
            StaticHolder.Score += 50 * StaticHolder.Combo;
            UI_Timer.TimeLeft += TimeAdd;
            aud.PlayOneShot(Timeget, 0.75f);
            StaticHolder.Drinks_sinceLevelStart = 0;
        }
    }
}
