using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NextLevel : MonoBehaviour
{
    [SerializeField]
    public GameObject fuse;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            fuse.SetActive(true);
        }
    }
}