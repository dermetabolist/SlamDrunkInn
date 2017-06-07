using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCalculator : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip Timeget;

    int TimeAdd;

    private void Update()
    {
        TimeAdd = 5 + (StaticHolder.Combo / 10);
        DrunknessLevelCalculator();
    }

    void DrunknessLevelCalculator()
    {
               
        if(StaticHolder.DrunknessCounter >= 10)
        {
            StaticHolder.DrunknessLevel++;
            UI_Timer.TimeLeft += TimeAdd;
            aud.PlayOneShot(Timeget, 0.75f);
            StaticHolder.DrunknessCounter = 0;
        }
    }
}
