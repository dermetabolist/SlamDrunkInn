using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour {

    public Text counterText;
    public static float TimeLeft = 60f;
    

	// Use this for initialization
	void Start () {
        counterText = GetComponent<Text>();   
    }
	
	// Update is called once per frame
	void Update () {

        if(TimeLeft > 0 && StaticHolder.Countdown_done == true)
        {
            TimeLeft -= Time.deltaTime;
            counterText.text = "" + Mathf.Round(TimeLeft);
        }

        if(TimeLeft <= 0)
        {
            StaticHolder.TimeOver = true;
        }

        ColourChange();
	}

    void ColourChange()
    {
        //if(TimeLeft <= 9)
        //{
        //    counterText.color = Color.magenta;
        //    //+Countdown sounds
        //}    
    }
}
