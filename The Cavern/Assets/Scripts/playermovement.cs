using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    public AudioClip[] clips;
    public ParticleSystem groundHit;
    SpriteRenderer render;
    Animator anim;
    Rigidbody2D rb;
    AudioSource audio;
    public float velocity;
    public float fallingpoint;
    public float dropvelocity;
    public float maxdropvelocity;
    public float aceleracion;

    public float jumpforce;
    public float friccion;
    public float raydistance;
    public float currentVelocity;
    Vector2 rayposition;
    Vector2 raydirection;
    bool movright;
    bool movleft;
    bool frenar;
    bool jump;
    public bool grounded;
    public LayerMask playerLayer;
    public LayerMask groundLayer;
    public bool fall;

    private bool hit,walk;
    private float maxvelocity;


    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        movright = false;
        movleft = false;
        jump = false;
        frenar = false;
        maxvelocity = 4f;
        anim.SetBool("Idle", true);
        hit = false;
        walk = false;
        fall = false;
    }


    void Update()
    {
        currentVelocity = rb.velocity.x;
        if (!Input.GetKey(KeyCode.D) && (!Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.A))))
        {
            movright = false;
            movleft = false;
            frenar = true;
            //audio.Stop();
        }


        else if (Input.GetKey(KeyCode.D))
        {
            movleft = false;
            movright = true;
            frenar = false;
            render.flipX = false;
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetBool("Sprint", true);
                maxvelocity = 8f;
                jumpforce = 14f;
                /*if (walk)
                {
                    audio.Stop();
                    walk = false;
                    Debug.Log("Stop walk sound");
                    Debug.Log(walk);
                }
                if (!audio.isPlaying)
                {
                    audio.PlayOneShot(clips[1]);
                    Debug.Log("Play sprint sound");
                }*/
            }
            else if (grounded)
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", true);
                /*if (!walk)
                {
                    audio.Stop();
                    walk = true;
                    Debug.Log("Stop sprint sound");
                    Debug.Log(walk);
                }
                if (!audio.isPlaying)
                {
                    audio.PlayOneShot(clips[0]);
                    Debug.Log("Play walk sound");
                }*/
            }
        }

        else if (Input.GetKey(KeyCode.A))
        {
            movright = false;
            movleft = true;
            frenar = false;
            render.flipX = true;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                anim.SetBool("Sprint", true);
                maxvelocity = 8f;
                jumpforce = 14f;
                /*if (walk)
                {
                    audio.Stop();
                    walk = false;
                }
                if (!audio.isPlaying)
                {
                    audio.PlayOneShot(clips[1]);
                }*/
            }
            else if (grounded)
            {
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", true);
                /*if (!walk)
                {
                    audio.Stop();
                    walk = true;
                }
                if (!audio.isPlaying)
                {
                    audio.PlayOneShot(clips[0]);
                }*/
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && (grounded) || Input.GetKeyDown(KeyCode.Space) && (grounded))
        {
            jump = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("Sprint", false);
            maxvelocity = 4f;
            jumpforce = 12f;
        }

        if (rb.velocity.y < fallingpoint && !grounded && rb.velocity.y > -maxdropvelocity)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - dropvelocity);
            if (jump)
            {
                fall = true;
                jump = false;
            }
        }

        rayposition = transform.position + new Vector3(0, 0.1f, 0);
        raydirection = -transform.up;
        
    }

    private void FixedUpdate()
    {
        if (Globals.move)
        {
            if (movright && rb.velocity.x < maxvelocity)
            {
                rb.velocity += new Vector2(velocity * aceleracion, 0);
            }

            if (movleft && rb.velocity.x > -maxvelocity)
            {
                rb.velocity += new Vector2(-velocity * aceleracion, 0);
            }

            if (frenar && rb.velocity.x != 0)
            {
                rb.velocity = new Vector2(rb.velocity.x * friccion, rb.velocity.y);
            }

            Debug.DrawRay(rayposition, raydirection * raydistance, Color.green);
            Debug.DrawRay(rayposition + new Vector2(0.30f, 0), raydirection * raydistance, Color.red);
            Debug.DrawRay(rayposition + new Vector2(-0.30f, 0), raydirection * raydistance, Color.cyan);
            RaycastHit2D hitsuelo = Physics2D.Raycast(rayposition, raydirection, raydistance, groundLayer);
            RaycastHit2D hitsuelo1 = Physics2D.Raycast(rayposition + new Vector2(0.30f, 0), raydirection, raydistance, groundLayer);
            RaycastHit2D hitsuelo2 = Physics2D.Raycast(rayposition + new Vector2(-0.30f, 0), raydirection, raydistance, groundLayer);


            if (hitsuelo.collider != null || hitsuelo1.collider != null || hitsuelo2.collider != null)
            {
                Globals.grounded = true;
                grounded = true;
                anim.SetBool("Jump", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Idle", true);
                if (hit)
                {
                    groundHit.Play();
                    audio.Stop();
                    audio.PlayOneShot(clips[3]);
                    hit = false;
                }
            }
            else
            {
                Globals.grounded = false;
                grounded = false;
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Jump", true);
                hit = true;
            }


            if (jump && grounded)
            {
                audio.Stop();
                audio.PlayOneShot(clips[2]);
                rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Jump", true);                
            }
        }
    }
}