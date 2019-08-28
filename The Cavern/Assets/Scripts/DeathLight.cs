using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLight : MonoBehaviour
{
    [SerializeField]
    public GameObject startPoint;
    public GameObject player;

    public void lightOut()
    {
        player.transform.position = startPoint.transform.position;
        GetComponent<Animator>().SetTrigger("Reduce");
    }

    public void disableLight()
    {
        gameObject.SetActive(false);
    }
}
