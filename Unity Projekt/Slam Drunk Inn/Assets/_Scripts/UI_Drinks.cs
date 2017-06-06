using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI_Drinks : MonoBehaviour {

    public Text Drinks;

    void Start()
    {
        Drinks = GetComponent<Text>();
    }

    void Update()
    {
            Drinks.text = "Drinks: " + StaticHolder.Drinks;
    }
}
