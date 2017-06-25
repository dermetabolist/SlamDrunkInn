using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Movement_Clouds_small : MonoBehaviour {

    float speed = .15F;  
    bool moveright = true;

    void Update()
    {
        if(StaticHolder.Countdown_done == true)
        {
            if (transform.position.x <= -11f)
            {
                moveright = true;
            }
            if (transform.position.x >= 12f)
            {
                moveright = false;
            }

            if (moveright)
            {
                MoveRight();
            }
            if (!moveright)
            {
                MoveLeft();
            }
        }
        
    }

    void MoveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void MoveLeft()
    {
        transform.Translate(Vector3.right * -speed * Time.deltaTime);
    }
}
