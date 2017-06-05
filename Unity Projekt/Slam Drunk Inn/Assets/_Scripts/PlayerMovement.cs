using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float speed = .5f;
    float rotSpeed = 10f;
    Vector3 RotatePoint;

    public bool Hit_Glas = false;

    public AudioSource Audio;
    public AudioClip HitTable;
    public AudioClip HitGlas;

    

    private void Start()
    {
        RotatePoint = new Vector3(0, 0, 30);
    }

    void Update()
    {
        
        //wenn Button1 gedrückt wird, rotiere vorwärts
        if(Input.GetButton("Fire1"))
        {
            transform.Rotate(RotatePoint * rotSpeed * Time.deltaTime);
            
            
            //wenn "tisch getroffen"
                //führe treffer-reaktion aus
                //bewege kopf zurück
            if(PlayerHeadCollision.Hit_Table == true || PlayerHeadCollision.Hit_Glas_InArea == true)
            {
                //Audio.PlayOneShot(HitTable, 1f);
                transform.Rotate(RotatePoint * -rotSpeed * Time.deltaTime);
            }

            if (PlayerHeadCollision.Hit_Glas_InArea == true) //wenn "glas im bereich"
            {
                Time.timeScale = .5f; //verlangsame zeit
                if (Input.GetButtonUp("Fire1")) //und wenn knopf losgelassen wird
                {
                    Hit_Glas = true;
                }
            }
        }
        else
        {
            //bewege kopf zurück zu ausgangsposition
        }

        // Aim/Hit/Miss
            //wenn Button 1 released
                //wenn Axis Horizontal bewegt wird
                    //berechne DrunknessFactor_Movement
                        //Random Wert aus Min + Max
                    //Position x + (Axis Horizontal * DrunknessFactor_Movement)

            //wenn das glas berührt wird
                //Glas trinken & wegwerfen
                    //glas aufnehmen
                        //Combo +1
                        //mache Glas zu Child
                            //spawne neues Glas
                            //mache neues Glas zu Ziel
                        //bewege kopf zurück
                        //spiele schlucksound
                        //PunkteAddieren()
                        //werfe glas hinter dich
                    // -> zurück zu ziel auf ziel

            //wenn das glas nicht berührt wird
                //gegen tisch stoßen
                //spiele sound
                //fehlversuche +1
                //setze Combo auf 0
                //wenn fehlversuche < 3
                    //bewege kopf zurück
                    // -> gehe zurück zu ziel auf ziel
                //wenn fehlversuche >= 3
                    //bewege kopf zurück
                    // wechsel in Disoriented State für 3 Sekunden
                    // -> gehe zurück zu ziel auf ziel

        //Drunk Movement
            //bewege Kopf zufällig nach links und rechts 
            //bewegen kopf zufällig nach oben und unten
            //rotiere kopf zufällig zwischen werten

        //Berechnung von Punkten & Zeit
            //Score Berechnung
                //Addiere Glaswert * Combo zu Score 
                //Addiere Glaswert * Combo zu Gorge Gauge
                //Addiere (GlassPosition - KopfPosition) * Combo zu Score
                //Addiere (GlassPosition - KopfPosition) * Combo zu Gorge Gauge

            //Drunkness Berechnung
                //addiere (GlasDrunkWert * AlkoholStärke) zu Drunkness
                //wenn Drunkness > 10
                    //DrunkLevel +1
                    //Zeit +5 Sekunden

            //Dizzyness berechnung
                //addiere (GlasDizzyWert * AlkoholStärke) zu Dizzyness
                //wenn Dizzyness > 100
                    //Dizzy Level +1

            //Gorge Gauge Berechnung
                //wenn Gorge Gauge > 1000
                    //Gorge Level +1
                
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
