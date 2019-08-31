using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : MonoBehaviour
{
    private bool left;
    void Start()
    {
        left = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            transform.Translate(new Vector3(-1,0,0));
        }
        else
        {
            transform.Translate(new Vector3(1, 0, 0));
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
