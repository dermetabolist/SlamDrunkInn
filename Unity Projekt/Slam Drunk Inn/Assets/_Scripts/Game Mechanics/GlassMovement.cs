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
    float RandX;
    float RandY;


    //throw stuff
    Vector2 LastPos;
    public Rigidbody2D rb;
    public Transform Launcher;
    float projectileSpeed = 35f;
    float RandRotSpeed;

    bool InArea = false;
    bool playShatter = true;
    bool throwMe = true;
    bool GlasDone = false;
    bool playSound = true;

    GameObject Head;
    Rigidbody2D rb2D;

    //soundkram
    public AudioClip swoosh;
    public AudioClip shatter;
    public AudioClip swallow;
    public AudioSource audio;
    float RandomPitch;

    Animator anim;

    void Start ()
    {
        Timer = 0f;
        _Timer = 0f;
        RandomPitch = 1;
        DestroyGameObject = false;
        _DestroyGameObject = false;
        Head = GameObject.Find("Head");
        rb2D = GetComponent<Rigidbody2D>();
        RandRotSpeed = Random.Range(0, -10);
        RandX = Random.Range(0, 3);
        RandY = Random.Range(0, 3);
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
       

        transform.Translate(Vector2.right * speed * Time.deltaTime); //normale vorwärtsbewegung
        
        if(InArea == true)
        {
            if (Input.GetButtonUp("Fire1") && StaticHolder.IsHoldingGlas == false && GlasDone == false)
            {
                this.transform.parent = Head.transform; //mache glas zum child
                speed = 0f;
                StaticHolder.Drinks++;
                StaticHolder.Combo++;
                StaticHolder.Drinks_sinceLevelStart++;
                StaticHolder.Score += 100 * StaticHolder.Combo;
                rb2D.simulated = false;
                transform.localPosition = new Vector3(-0.4f, 2.71f, 0);
                DestroyGameObject = true;
                
            }
        }

        if (DestroyGameObject == true)
        {
            GlasDone = true;
            Timer += Time.deltaTime;
           
            if(Input.GetButtonDown("Fire1") && throwMe == true)
            {
                this.transform.parent = null;
                rb2D.simulated = true;
                rb.velocity = new Vector3(6 + RandX, 8 + RandY, 0);
                transform.Translate(Vector2.up * speed * Time.deltaTime);
                transform.Rotate(Vector3.forward * RandRotSpeed);
                throwMe = false;
            }
            if(Timer > .5 && playSound)
            {
                anim.SetBool("empty", true);
                audio.PlayOneShot(swallow, 1f);
                playSound = false;
            }



            if (Timer > .75f && throwMe == true) //löst glas vom parent, addiert velocity
            {
                this.transform.parent = null;
                rb2D.simulated = true;
                rb.velocity = new Vector3(6 + RandX, 8 + RandY, 0);
                transform.Translate(Vector2.up * speed * Time.deltaTime);
                transform.Rotate(Vector3.forward * RandRotSpeed);
            }

            if (Timer > 1.25f) //schaltet velocity etc. wieder ab
            {
                throwMe = false;
            }
        

            if (Timer > 5.5f)
            {
                if (playShatter == true) //spielt den sound
                {
                    RandomPitch = (Random.Range(.5f, 1.5f));
                    audio.pitch = RandomPitch;
                    audio.PlayOneShot(shatter, 0.5f);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Floor")
        {
            RandomPitch = (Random.Range(.5f, 1.5f));
            audio.pitch = RandomPitch;
            audio.PlayOneShot(shatter, 0.5f);
            _DestroyGameObject = true;
        }

        if (collision.tag == "Head")
        {
            InArea = true;
        }

        if (collision.tag == "Edge")
        {
            RandomPitch = (Random.Range(.5f, 1.5f));
            audio.pitch = RandomPitch;
            audio.PlayOneShot(swoosh, 0.75f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Head")
        {
            InArea = false;
        }
    }
}
