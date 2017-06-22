using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlasSpawn : MonoBehaviour {

    public Transform GlassPrefab;
    public GameObject[] pieces;
    float timer = 0f;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        if(StaticHolder.TimeOver == false && StaticHolder.Countdown_done == true)
        {
            //if(StaticHolder.DrunknessLevel < 1)
            //{
            //    timer += (Time.deltaTime * Time.timeScale);
            //    float TimeMax = (1 - (Time.timeSinceLevelLoad / 150));
            //    if (timer >= TimeMax)
            //    {
            //        Instantiate(GlassPrefab, transform.position, Quaternion.identity);
            //        timer = 0f;
            //    }
            //}
                timer += (Time.deltaTime * Time.timeScale);
                float TimeMax = (1 - (Time.timeSinceLevelLoad / 150));
                if (timer >= TimeMax)
                {
                    //Random.Range(min, max) -> reguliert die gespawnten prefabs. erhöhen für verschiedene drinks
                    Instantiate(pieces[UnityEngine.Random.Range(0, 5)], transform.position, transform.rotation);
                    timer = 0f;
                }
            
        }
        
    }

    

    
}
