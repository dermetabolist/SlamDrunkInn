using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DisorientedScale : MonoBehaviour {

    public Image Disoriented_scale;

    void Start ()
    {
        Disoriented_scale.fillAmount = 0f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Disoriented_scale.fillAmount = StaticHolder.Disoriented_level * 0.2f;
    }
}
