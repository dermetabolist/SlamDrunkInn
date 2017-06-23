using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Drinks : MonoBehaviour {

    public Image DrunknessLevel_scale;

    float threshold;
    float drinksSinceStart;
    float fillamount;
    float fillamount_onepercent;
    float fillamount_hundredpercent;

    private void Start()
    {
            DrunknessLevel_scale.fillAmount = 0f;
    }

    void Update()
    {
        threshold = StaticHolder.DrunknessLevel_threshold;
        drinksSinceStart = StaticHolder.Drinks_sinceLevelStart;
        fillamount = (1 / threshold) * drinksSinceStart;
       

        if (StaticHolder.DrunknessLevel == 0)
        {
            DrunknessLevel_scale.fillAmount = (0.1f * drinksSinceStart);
        }

        if(StaticHolder.DrunknessLevel >= 1)
        {
            DrunknessLevel_scale.fillAmount = fillamount;
        }
    }
}
