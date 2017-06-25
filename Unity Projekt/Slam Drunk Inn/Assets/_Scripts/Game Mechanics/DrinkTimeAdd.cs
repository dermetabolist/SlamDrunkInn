using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkTimeAdd : MonoBehaviour {

    bool addTime = true;
    public float TimeAddValue;
	
	
	void Update ()
    { 
        if (transform.parent != null && addTime)
        {
            StaticHolder.CollectedTime += TimeAddValue;
            addTime = false;
        }
    }
}
