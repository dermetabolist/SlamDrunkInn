using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    float speed = .5f;

    public Transform Target;

    //Gameobject Glas
    //GameObject AimPoint

    private void Start()
    {
        
    }

    void Update()
    {
        
        
        //wenn Button1 gedrückt wird, bewege dich zum ziel
        if(Input.GetButton("Fire1"))
        {
            Quaternion rotation = Quaternion.LookRotation
            (Target.transform.position - transform.position, transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
        // Aim/Hit/Miss
            //wenn Button 1 released
                //MoveToAim();
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

    void MoveToAim()
    {
        if(transform.position.y >= 0.25)
        {
            transform.Translate(Vector2.left * speed);
        }
    }

}
