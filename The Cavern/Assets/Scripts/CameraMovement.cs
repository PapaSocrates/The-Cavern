using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float smoothTime = .15f;

    [SerializeField]
    public float MaxX, MinX, MaxY, MinY;
    private Transform Objetivo;

    float offsety;
    float offsetx;
    private Vector3 pos = new Vector3();
    Vector3 velocidad = Vector3.zero;

    void Start()
    {
        Objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        offsety = 0;
        offsetx = 0;
    }

    void FixedUpdate()
    {
        try
        {
            pos = Objetivo.position + new Vector3 (offsetx,offsety,0);
        }
        catch (Exception e) { }


        if (pos != null)
        {
            pos.y = Mathf.Clamp(pos.y, MinY, MaxY);
            pos.x = Mathf.Clamp(pos.x, MinX, MaxX);
            pos.z = transform.position.z;
            transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocidad, smoothTime);
        }
    }
}