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
            timer += Time.deltaTime;
            if (timer >= 1)
            {
                Instantiate(GlassPrefab, transform.position, Quaternion.identity);
                timer = 0f;
            }
        }
        
    }

    

    
}
