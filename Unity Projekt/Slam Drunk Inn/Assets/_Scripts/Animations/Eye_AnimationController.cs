using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye_AnimationController : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(StaticHolder.Disoriented == true)
        {
            anim.SetBool("Disoriented", true);
        }
        else
        {
            anim.SetBool("Disoriented", false);
        }

        if (PlayerHeadCollision.Hit_Table == true)
        {
            anim.SetBool("HitTable", true);
        }
        else
        {
            anim.SetBool("HitTable", false);
        }
    }
}
