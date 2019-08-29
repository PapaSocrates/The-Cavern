using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    SpriteRenderer render;
    Animator anim;
    Rigidbody2D rb;
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

    private float maxvelocity;


    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movright = false;
        movleft = false;
        jump = false;
        frenar = false;
        maxvelocity = 4f;
        anim.SetBool("Idle", true);
    }


    void Update()
    {
        if (Globals.move)
        {


            currentVelocity = rb.velocity.x;
            if (!Input.GetKey(KeyCode.D) && (!Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.A))))
            {
                movright = false;
                movleft = false;
                frenar = true;
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
                }
                else if (grounded)
                {
                    anim.SetBool("Idle", false);
                    anim.SetBool("Walk", true);
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
                }
                else if (grounded)
                {
                    anim.SetBool("Idle", false);
                    anim.SetBool("Walk", true);
                }
            }


            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetBool("Sprint", false);
                maxvelocity = 4f;
            }

            if (rb.velocity.y < fallingpoint && !grounded && rb.velocity.y > -maxdropvelocity)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - dropvelocity);
            }

            rayposition = transform.position + new Vector3(0, 0.1f, 0);
            raydirection = -transform.up;
        }
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
            }
            else
            {
                Globals.grounded = false;
                grounded = false;
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Jump", true);
            }


            if (jump && grounded)
            {
                rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                anim.SetBool("Idle", false);
                anim.SetBool("Walk", false);
                anim.SetBool("Jump", true);
                jump = false;
            }
        }
    }
}