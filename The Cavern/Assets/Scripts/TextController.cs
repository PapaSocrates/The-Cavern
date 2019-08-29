using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    private Animator anim;
    private float timer;
    void Start()
    {
        anim = GetComponent<Animator>();
        timer = 0;
        Globals.move = false;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            anim.SetTrigger("Out");            
        }
    }

    public void disapear()
    {
        gameObject.SetActive(false);
        Globals.move = true;
    }
}
