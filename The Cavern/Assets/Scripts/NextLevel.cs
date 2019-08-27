using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NextLevel : MonoBehaviour
{
    [SerializeField]
    public GameObject fuse;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            fuse.SetActive(true);           
        }
    }    
}