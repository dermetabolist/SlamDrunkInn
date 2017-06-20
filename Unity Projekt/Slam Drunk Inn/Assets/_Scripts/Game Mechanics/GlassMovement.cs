using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassMovement : MonoBehaviour {

    float speed = 7.5f;

    bool DestroyGameObject = false;
    bool _DestroyGameObject = false;
    float Timer;
    float _Timer;
    float thrust = 5f;


    //throw stuff
    Vector2 LastPos;
    public Rigidbody2D rb;
    public Transform Launcher;
    float projectileSpeed = 35f;
    float rotSpeed = 15f;

    bool InArea = false;
    bool playShatter = true;
    bool throwMe = true;

    GameObject Head;
    Rigidbody2D rb2D;

    //soundkram
    public AudioClip swoosh;
    public AudioClip shatter;
    public AudioClip swallow;
    public AudioSource audio;

	void Start ()
    {
        Timer = 0f;
        _Timer = 0f;
        DestroyGameObject = false;
        _DestroyGameObject = false;
        Head = GameObject.Find("Head");
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //normale vorwärtsbewegung

        if(InArea == true)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                this.transform.parent = Head.transform; //mache glas zum child
                StaticHolder.IsHoldingGlas = true;
                speed = 0f;
                StaticHolder.Drinks++;
                StaticHolder.Combo++;
                StaticHolder.Drinks_sinceLevelStart++;
                StaticHolder.Score += 100 * StaticHolder.Combo;
                audio.PlayOneShot(swallow, 0.75f);
                rb2D.simulated = false;
                transform.position = new Vector3(-1, 0, 0);
                DestroyGameObject = true;
            }
        }

        if (DestroyGameObject == true)
        {
            Timer += Time.deltaTime;

            if (Timer > .5) // rotiert glas
            {
                transform.Rotate(Vector3.forward * -rotSpeed);
            }

            if (Timer > .5f && throwMe == true) //löst glas vom parent, addiert velocity
            {
                this.transform.parent = null;
                rb2D.simulated = true;
                //rb.AddForce(Vector2.up * projectileSpeed, ForceMode2D.Impulse);
                rb.velocity = new Vector3(2, 8, 0);
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }

            if(Timer > .75f) //schaltet velocity etc. wieder ab
            {
                throwMe = false;
            }

            if(Timer > 5.5f)
            {
                if (playShatter == true) //spielt den sound
                {
                    audio.PlayOneShot(shatter, 0.75f);
                    playShatter = false;
                }

                if (Timer > 6.5f)
                {
                    Destroy(gameObject);
                }
            }
        }

        if (_DestroyGameObject == true)
        {
            _Timer += Time.deltaTime;
            if (_Timer > 1.5)
            {
                Destroy(gameObject);
            }
        }
    }

    //
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            audio.PlayOneShot(shatter, 0.75f);
            _DestroyGameObject = true;
        }

        if (collision.tag == "Head")
        {
            InArea = true;
        }

        if (collision.tag == "Edge")
        {
            audio.PlayOneShot(swoosh, 0.75f);
        }

        


    }
}
