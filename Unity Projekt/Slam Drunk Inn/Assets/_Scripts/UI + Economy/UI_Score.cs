using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Score : MonoBehaviour {

    public Text Score;

    void Start()
    {
        Score = GetComponent<Text>();
    }

    void Update()
    {
        Score.text = "Score: " + StaticHolder.Score;
    }
}
