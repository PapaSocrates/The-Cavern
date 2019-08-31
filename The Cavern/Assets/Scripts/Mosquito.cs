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

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            transform.Translate(new Vector3(-5,0,0));
            render.flipX = true;
        }
        else
        {
            transform.Translate(new Vector3(5, 0, 0));
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
