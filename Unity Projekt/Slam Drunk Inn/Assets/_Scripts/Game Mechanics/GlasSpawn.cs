using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlasSpawn : MonoBehaviour {

    //public Transform GlassPrefab;
    //public GameObject[] pieces;
    public GameObject Drink01;
    public GameObject Drink02;
    public GameObject Drink03;
    public GameObject Drink04;
    public GameObject Drink05;
    public GameObject Drink06;

    float timer = 0f;
    float _timer = 0f;
    float RandomValue;
    bool CalculateRandomValue;

    void Start ()
    {
        RandomValue = 1f;
        _timer = 0f;
	}
	
	void Update ()
    {
        if (StaticHolder.TimeOver == false && StaticHolder.Countdown_done == true && StaticHolder.GameWon == false)
        {
            _timer += Time.deltaTime;
            timer += (Time.deltaTime * Time.timeScale);
            float TimeMax = (1 - (StaticHolder.DrunknessLevel / 20));

            if (timer >= TimeMax && CalculateRandomValue)
            {
                RandomValue = UnityEngine.Random.value;
                CalculateRandomValue = false;
            }

            if (timer >= TimeMax)
            {
                if(StaticHolder.DrunknessLevel < 1)
                {
                    Level0();
                }
                if (StaticHolder.DrunknessLevel == 1)
                {
                    Level1();
                }
                if (StaticHolder.DrunknessLevel == 2)
                {
                    Level2();
                }
                if (StaticHolder.DrunknessLevel == 3)
                {
                    Level3();
                }
                if (StaticHolder.DrunknessLevel == 4)
                {
                    Level4();
                }
                if (StaticHolder.DrunknessLevel > 4)
                {
                    Level5();
                }   
            }
        }      
    }


    private void Level0()
    {
            Instantiate(Drink01, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
    }

    private void Level1()
    {
        if (RandomValue > 0.25) //%50 percent chance (Drink01)
        {//code here
            Instantiate(Drink01, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.25) //%20 percent chance (Drink02)
        { //code here
            Instantiate(Drink02, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }
    }

    private void Level2()
    {
        if (RandomValue > 0.6) 
        {//code here
            Instantiate(Drink01, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.6 && RandomValue > 0.2) 
        { //code here
            Instantiate(Drink02, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.2) 
        { //code here
            Instantiate(Drink03, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }
    }

    private void Level3()
    {
        if (RandomValue > 0.55) //%50 percent chance (Drink01)
        {//code here
            Instantiate(Drink01, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.55 && RandomValue > 0.25) //%20 percent chance (Drink02)
        { //code here
            Instantiate(Drink02, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.25 && RandomValue > 0.1) //%15 percent chance (Drink03)
        { //code here
            Instantiate(Drink03, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.1) //%10 percent chance (Drink04)
        { //code here
            Instantiate(Drink04, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }
    }

    private void Level4()
    {
        if (RandomValue > 0.5) //%50 percent chance (Drink01)
        {//code here
            Instantiate(Drink01, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.5 && RandomValue > 0.3) //%20 percent chance (Drink02)
        { //code here
            Instantiate(Drink02, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.3 && RandomValue > 0.15) //%15 percent chance (Drink03)
        { //code here
            Instantiate(Drink03, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.15 && RandomValue > 0.06) //%10 percent chance (Drink04)
        { //code here
            Instantiate(Drink04, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.06) //%3 percent chance (Drink05)
        { //code here
            Instantiate(Drink05, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }
    }

    private void Level5()
    {
        if (RandomValue > 0.5) //%50 percent chance (Drink01)
        {//code here
            Instantiate(Drink01, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.5 && RandomValue > 0.3) //%20 percent chance (Drink02)
        { //code here
            Instantiate(Drink02, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.3 && RandomValue > 0.15) //%15 percent chance (Drink03)
        { //code here
            Instantiate(Drink03, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.15 && RandomValue > 0.05) //%10 percent chance (Drink04)
        { //code here
            Instantiate(Drink04, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.05 && RandomValue > 0.02) //%3 percent chance (Drink05)
        { //code here
            Instantiate(Drink05, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }

        if (RandomValue <= 0.02) //%2 percent chance (Drink06)
        { //code here
            Instantiate(Drink06, transform.position, transform.rotation);
            CalculateRandomValue = true;
            timer = 0f;
        }
    }
}
