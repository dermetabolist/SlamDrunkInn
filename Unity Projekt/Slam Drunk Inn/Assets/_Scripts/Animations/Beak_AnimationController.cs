using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beak_AnimationController : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("OpenMouth", true);
        }
        else
        {
            anim.SetBool("OpenMouth", false);
        }
    }
}
