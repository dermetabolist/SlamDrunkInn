using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_TimeAddCounter : MonoBehaviour {

    public GameObject TimeAddCounter_Splash;
    Text TimeAddCounter_Splashtext;

    public GameObject TimeAddCounter;
    Text TimeAddText;

    public GameObject ComboMultiplier;
    Text ComboMultiplierText;

    public Image TimeGain_Scale;

    Color opacity;
    public static float TimeAddCounter_opacity;
    public static bool TimeAddCounter_showPoints = false;

    float TimeAdd;

    void Start()
    {
        TimeAddText = TimeAddCounter.GetComponent<Text>();
        ComboMultiplierText = ComboMultiplier.GetComponent<Text>();
        TimeGain_Scale = TimeGain_Scale.GetComponent<Image>();
        TimeAddCounter_Splashtext = TimeAddCounter_Splash.GetComponent<Text>();
        TimeAddCounter_Splashtext.CrossFadeAlpha(0, 0, false);
        TimeGain_Scale.fillAmount = 0;
        opacity = TimeAddText.color;
        TimeAddText.text = "";
    }

    void Update()
    {
        
        TimeAddText.text = "+" + StaticHolder.CollectedTime_accumulated;
        ComboMultiplierText.text = "x" + StaticHolder.Combo_Multiplier;
        TimeGain_Scale.fillAmount = StaticHolder.CollectedTime;

      
            if (TimeAddCounter_showPoints)
            {
                
            
                TimeAddCounter_Splashtext.CrossFadeAlpha(1, 0f, false);
                TimeAddCounter_Splashtext.text = "+" + StaticHolder.CollectedTime_accumulated * StaticHolder.Combo_Multiplier;
                TimeAddCounter_showPoints = false;
            
            
            }

            if (!TimeAddCounter_showPoints)
            {
                TimeAddCounter_Splashtext.CrossFadeAlpha(0, .75f, false);
            }
        
        
    }
}
