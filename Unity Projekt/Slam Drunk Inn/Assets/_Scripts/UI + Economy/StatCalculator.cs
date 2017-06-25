using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCalculator : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip Timeget;

    float TimeAdd;
    bool LooseHealth;
    float Timer;

    private void Start()
    {
        //werte für Reset nach Game Over
        StaticHolder.TimeOver = false;
        StaticHolder.DrunknessLevel = 0;
        StaticHolder.Drinks_sinceLevelStart = 0;
        StaticHolder.Combo = 0;
        UI_Timer.TimeLeft = 60;
        StaticHolder.DrunknessLevel_threshold = 10;
    }

    private void Update()
    {
        TimeAdd = StaticHolder.DrunknessLevel + StaticHolder.CollectedTime + (StaticHolder.Combo / 10); //definiert, wieviel zeit man zurückgewinnt

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
        
        if(StaticHolder.Drinks_sinceLevelStart > 0)
        {
            if (StaticHolder.Drinks_sinceLevelStart >= StaticHolder.DrunknessLevel_threshold)
            {
                StaticHolder.DrunknessLevel++;

                //StaticHolder.Score += 50 * StaticHolder.Combo;
                UI_Timer.TimeLeft += TimeAdd;  //time gain
                UI_TimeAddCounter.TimeAddCounter_showPoints = true;
                aud.PlayOneShot(Timeget, 1f);
                StaticHolder.Drinks_sinceLevelStart = 0;
                //StaticHolder.CollectedTime = 0f;
            }
        }
        
    }
}
