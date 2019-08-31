using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosquitoController : MonoBehaviour
{
    public float speed = 5;
    public float maxSpeed = 5;
    public Rigidbody2D rb2d;
    private float gravity =9.8f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
 
    private void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
        {

            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            if (gameObject.GetComponent<SpriteRenderer>().flipX)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}
