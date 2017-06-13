using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Combo : MonoBehaviour {

    public Text Combo;

    void Start()
    {
        Combo = GetComponent<Text>();
    }

    void Update()
    {
        Combo.text = "Chain: " + StaticHolder.Combo;
    }
}
