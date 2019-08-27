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
    public float maxvelocity;
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
    bool grounded;
    public LayerMask playerLayer;
    public LayerMask groundLayer;


    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movright = false;
        movleft = false;
        jump = false;
        frenar = false;
        anim.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {

        currentVelocity = rb.velocity.x;
        if (!Input.GetKey(KeyCode.D) && (!Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D) && (Input.GetKey(KeyCode.A))))
        {
            movright = false;
            movleft = false;
            frenar = true;
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
        }


        else if (Input.GetKey(KeyCode.D))
        {
            movleft = false;
            movright = true;
            frenar = false;
            render.flipX = false;
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", true);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            movright = false;
            movleft = true;
            frenar = false;
            render.flipX = true;
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", true);
        }


        if (Input.GetKeyDown(KeyCode.W ) || Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            anim.SetBool("Idle", false);
            anim.SetBool("Walk", false);
            anim.SetTrigger("Jump");
        }

        if (rb.velocity.y < fallingpoint && !grounded && rb.velocity.y > -maxdropvelocity)
        {           
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - dropvelocity);
        }

        rayposition = transform.position + new Vector3(0, 0.1f, 0);
        raydirection = -transform.up;
    }

    private void FixedUpdate()
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
        Debug.DrawRay(rayposition + new Vector2(0.17f, 0), raydirection * raydistance, Color.red);
        Debug.DrawRay(rayposition + new Vector2(-0.17f, 0), raydirection * raydistance, Color.cyan);
        RaycastHit2D hitsuelo = Physics2D.Raycast(rayposition, raydirection, raydistance, groundLayer);
        RaycastHit2D hitsuelo1 = Physics2D.Raycast(rayposition + new Vector2(0.17f, 0), raydirection, raydistance, groundLayer);
        RaycastHit2D hitsuelo2 = Physics2D.Raycast(rayposition + new Vector2(-0.17f, 0), raydirection, raydistance, groundLayer);


        if (hitsuelo.collider != null || hitsuelo1.collider != null || hitsuelo2.collider != null)
        {
            grounded = true;

        }
        else
        {
            grounded = false;

        }


        if (jump && grounded)
        {
            rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            jump = false;
        }


    }
}
