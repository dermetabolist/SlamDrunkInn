using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement2 : MonoBehaviour {

    bool _RotateDown = false;
    float rotSpeed = 7;

    bool Hit_Glas_InArea = false;
    public static bool Hit_Glas = false;

    public Transform target;

    public Image Button_fg;
    public Image Button_bg;
    public Image Button_text;

    float Timer = 0f;
    float _Timer = 0f;

    public void Update()
    {
        ButtonFillAmount();

        if(StaticHolder.Disoriented == false && StaticHolder.TimeOver == false && StaticHolder.Countdown_done == true && StaticHolder.Menu_active == false)
        {
            if (Input.GetButton("Fire1") && Hit_Glas == false)
            {
                _RotateDown = true;
            }

            if (Input.GetButtonUp("Fire1")) //wenn Knopf losgelassen wird
            {
                _RotateDown = false;
            }

            if (_RotateDown)
            {
                RotateDown();
            }
            else
            {
                RotateUp();
            }
        }

        if (StaticHolder.Disoriented)
        {
            RotateUp();
            _RotateDown = false;
        }

    }

    private void ButtonFillAmount()
    {
        _Timer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            Button_fg.fillAmount = _Timer * 8f;
        }

        if (Input.GetButton("Fire1") == false && _Timer > 0 && Button_fg.fillAmount >= 0)
        {
            Button_fg.fillAmount = 0;
            _Timer -= Time.deltaTime * 3;
        }
    }

    void RotateUp()
    {
        Vector3 to = new Vector3(0, 0, 0);

        if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
        {
            transform.eulerAngles = Vector3.Slerp(transform.rotation.eulerAngles, to, rotSpeed * Time.deltaTime);  
        }
    }

    void RotateDown()
    {
        Vector3 to = new Vector3(0, 0, 90);

        if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
        {
            transform.eulerAngles = Vector3.MoveTowards(transform.rotation.eulerAngles, to, (rotSpeed * 100) * Time.deltaTime);
        }
    }
    
}
