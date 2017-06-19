using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_ButtonController : MonoBehaviour {

    float Timer = 0f;
    float _Timer = 0f;

    public Image Button_fg;
    public Image Button_bg;
    public Image Button_text;

    bool Button_activated;

	void Start ()
    {
        Button_fg.fillAmount = 0;
    }
	
	
	void Update ()
    {
        ButtonTouchControls();

        if (StaticHolder.Menu_active == true)
        {
            //menu controls
            ButtonMenuControls();
        }
 
        if(StaticHolder.TimeOver == true && StaticHolder.Menu_active == false)
        {
            //game over controls
            ButtonGameOverControls();
        }

        
    }

    private void ButtonMenuControls()
    {
        if (Input.GetButton("Fire1"))
        {
            _Timer += Time.deltaTime;
            Button_fg.fillAmount = _Timer * 0.5f;

            if (_Timer > 2f)
            {
                StaticHolder.Countdown_done = false;
                StaticHolder.Menu_active = false;
            }
        }

        if (Input.GetButton("Fire1") == false && _Timer > 0)
        {
            Button_fg.fillAmount = _Timer * 0.5f;
            _Timer -= Time.deltaTime * 2;
        }
    }

    private void ButtonGameOverControls()
    {
        if (Input.GetButton("Fire1"))
        {
            Button_fg.fillAmount = _Timer * 0.5f;
            _Timer += Time.deltaTime;

            if (_Timer > 2f)
            {
                StaticHolder.Countdown_done = !StaticHolder.Countdown_done;
                //StaticHolder.Menu_active = false;
                SceneManager.LoadScene("_Scenes/GameScreen");
            }
        }

        if (Input.GetButton("Fire1") == false && _Timer > 0 && Button_fg.fillAmount >= 0)
        {
            Button_fg.fillAmount = _Timer * 0.5f;
            _Timer -= Time.deltaTime * 2;
        }
    }

    
}
