using UnityEngine;
using System.Collections;

public class CamShakeSimple : MonoBehaviour
{

    Vector3 originalCameraPosition;
    float shakeAmt = 0;
    public Camera mainCamera;

    public static bool CameraIsShaking = false;

    //audiostuff
    public AudioSource aud;
    public AudioClip hit;

    void OnCollisionEnter2D(Collision2D coll)
    {
        print("collision fired");
        aud.PlayOneShot(hit, 1f);
        shakeAmt = .05f;
        InvokeRepeating("CameraShake", 0, .01f);
        Invoke("StopShaking", .5f);
        StaticHolder.Combo = 0;
    }

    void CameraShake()
    {
        CameraIsShaking = true;

        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.y += quakeAmt;
            pp.x += quakeAmt;// can also add to x and/or z
            mainCamera.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CameraIsShaking = false;

        CancelInvoke("CameraShake");
        mainCamera.transform.position = new Vector3(0,0,-10);
    }

}