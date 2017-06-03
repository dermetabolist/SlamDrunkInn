using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssistMovement : MonoBehaviour {

    
    private Vector3 pos1 = new Vector3(-2, -0.3f, 0);
    private Vector3 pos2 = new Vector3(2, -0.3f, 0);

    //Dizzyness
    private Vector3 DizzyFactor_Range;
    float DizzyFactor_Speed = 1;

    public float speed = 1.0f;

        void Update()
        {   
            //Berechne DizzyFactor_Speed
                //Random-Wert aus Minimum + Maximum

            //Berechne DizzyFactor_Range

            transform.position = Vector3.Lerp(pos1 + DizzyFactor_Range, pos2 + DizzyFactor_Range, Mathf.PingPong(Time.time * speed * DizzyFactor_Speed, 1.0f));
        }
    
    
}

