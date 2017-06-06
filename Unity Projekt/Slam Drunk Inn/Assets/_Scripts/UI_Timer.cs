using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Timer : MonoBehaviour {

    public Text counterText;
    public float TimeLeft = 10f;
    

	// Use this for initialization
	void Start () {
        counterText = GetComponent<Text>();
        
    }
	
	// Update is called once per frame
	void Update () {

        if(TimeLeft > 0)
        {
            TimeLeft -= Time.deltaTime;
            counterText.text = "" + Mathf.Round(TimeLeft);
        }

        if(TimeLeft <= 0)
        {
            StaticHolder.TimeOver = true;
        }
       

        
		
	}
}
