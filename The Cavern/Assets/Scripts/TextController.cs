using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField]
    GameObject secondText;

    private Animator anim;
    private float timer;
    void Start()
    {
        anim = GetComponent<Animator>();
        timer = 0;
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
        if (secondText != null)
        {
            secondText.SetActive(true);
        }
    }
}
