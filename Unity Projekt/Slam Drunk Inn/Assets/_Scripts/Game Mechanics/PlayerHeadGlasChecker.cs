using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadGlasChecker : MonoBehaviour {

	void Update ()
    {
        if(transform.childCount > 3)
        {
            StaticHolder.IsHoldingGlas = true;
        }
        
        if(transform.childCount <= 3)
        {
            StaticHolder.IsHoldingGlas = false;
        }
	}
}
