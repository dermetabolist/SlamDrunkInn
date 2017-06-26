using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemOnOff : MonoBehaviour {

    
    // Use this for initialization
    void Start ()
    {
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        //particle system on / off
        if (StaticHolder.GameWon == true)
        {
            ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
            em.enabled = true;
        }
        else
        {
            ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
            em.enabled = false;
        }

    }
}
