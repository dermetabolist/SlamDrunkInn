using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_Animation : MonoBehaviour {

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update ()
    {
        anim.SetInteger("Hits", StaticHolder.Disoriented_level);     
    }
}
