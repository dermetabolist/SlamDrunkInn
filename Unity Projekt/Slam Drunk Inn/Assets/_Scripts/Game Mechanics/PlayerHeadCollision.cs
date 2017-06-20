using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadCollision : MonoBehaviour {

    public static bool Hit_Table = false;
    public static bool Hit_Glas_InArea = false;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Table")
        {
            Hit_Table = true;
        }

        if(collision.tag == "Glas" && StaticHolder.IsHoldingGlas == false)
        {
            Hit_Glas_InArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        Hit_Glas_InArea = false;   
        Hit_Table = false;
    }

    
    
}
