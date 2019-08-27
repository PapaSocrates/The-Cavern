using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("Out");
        }
    }

    public void disapear()
    {
        gameObject.SetActive(false);
    }
}
