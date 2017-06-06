using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCalculator : MonoBehaviour {

    private void Update()
    {
        DrunknessLevelCalculator();
    }

    void DrunknessLevelCalculator()
    {
        if(StaticHolder.DrunknessCounter >= 10)
        {
            StaticHolder.DrunknessLevel++;
            StaticHolder.DrunknessCounter = 0;
        }
    }
}
