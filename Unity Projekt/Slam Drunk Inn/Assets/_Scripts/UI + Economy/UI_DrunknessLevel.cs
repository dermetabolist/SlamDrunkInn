using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_DrunknessLevel : MonoBehaviour {

    public Text Drinks;

    void Start()
    {
        Drinks = GetComponent<Text>();
    }

    void Update()
    {
        Drinks.text = "" + StaticHolder.DrunknessLevel;
    }
}
