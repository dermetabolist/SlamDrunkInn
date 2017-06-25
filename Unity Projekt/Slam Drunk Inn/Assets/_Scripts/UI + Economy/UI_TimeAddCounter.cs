using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TimeAddCounter : MonoBehaviour {

    public GameObject TimeAddCounter;
    Text TimeAddText;
    Color opacity;
    public static float TimeAddCounter_opacity;
    public static bool TimeAddCounter_showPoints = false;

    float TimeAdd;

    void Start()
    {
        TimeAddText = TimeAddCounter.GetComponent<Text>();
        opacity = TimeAddText.color;
        TimeAddText.text = "";
    }

    void Update()
    {
        if (TimeAddCounter_showPoints)
        {
            TimeAddText.CrossFadeAlpha(1, 0f, false);
            TimeAddText.text = "+" + Mathf.Round(StatCalculator.TimeAdd);
            StaticHolder.CollectedTime = 0f;
            TimeAddCounter_showPoints = false;
        }
      
        if (!TimeAddCounter_showPoints)
        {
            TimeAddText.CrossFadeAlpha(0, .75f, false);
        }
        
    }
}
