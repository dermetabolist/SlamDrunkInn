using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCalculator : MonoBehaviour
{
    public AudioSource aud;
    public AudioClip Timeget;

    private void Update()
    {
        DrunknessLevelCalculator();
    }

    void DrunknessLevelCalculator()
    {
        if(StaticHolder.DrunknessCounter >= 10)
        {
            StaticHolder.DrunknessLevel++;
            StaticHolder.Time += 5;
            aud.PlayOneShot(Timeget, 0.75f);
            StaticHolder.DrunknessCounter = 0;
        }
    }
}
