using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : MonoBehaviour
{
    private bool left;
    SpriteRenderer render;

    void Start()
    {
        left = true;
        render = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (left)
        {
            transform.Translate(-0.05f,0,0);
            render.flipX = true;
        }
        else
        {
            transform.Translate(0.05f,0,0);
            render.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("WallLeft"))
        {
            left = false;
        }
        if (col.gameObject.tag.Equals("WallRight"))
        {
            left = true;
        }
    }
}
