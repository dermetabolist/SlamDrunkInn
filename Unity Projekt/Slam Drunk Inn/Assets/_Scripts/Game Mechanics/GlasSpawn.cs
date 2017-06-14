using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlasSpawn : MonoBehaviour {

    public Transform GlassPrefab;
    float timer = 0f;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if(StaticHolder.TimeOver == false)
        {
            timer += (Time.deltaTime * Time.timeScale);
            float TimeMax = (1 - (Time.timeSinceLevelLoad / 150));
            if (timer >= TimeMax)
            {
                Instantiate(GlassPrefab, transform.position, Quaternion.identity);
                timer = 0f;
            }
        }
        
    }

    

    
}
