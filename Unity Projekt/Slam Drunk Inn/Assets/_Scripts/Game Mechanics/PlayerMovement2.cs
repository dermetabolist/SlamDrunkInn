using UnityEngine;

public class PlayerMovement2 : MonoBehaviour {

    bool _RotateDown = false;
    float rotSpeed = 7;

    bool Hit_Glas_InArea = false;
    public static bool Hit_Glas = false;

    public Transform target;

    public void Update()
    {
        
        if(StaticHolder.Disoriented == false && StaticHolder.TimeOver == false)
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
