using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GameStartScreen : MonoBehaviour {

    string Countdown;
    public Text Countdown_Text;
    float Timer = 0f;
	
	void Start ()
    {
        Countdown = "GET READY!";
	}
	
	
	void Update ()
    {
        Countdown_Text.text = Countdown;
        Timer += Time.deltaTime;
        
	}
}
