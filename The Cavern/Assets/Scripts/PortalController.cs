using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour
{
    public Transform otherPortalRight;
    public Transform otherPortalLeft;
    private Vector3 finalPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //FindObjectOfType<audioController>().Play("portalSound");
            if (collision.gameObject.GetComponent<playermovement>().currentVelocity >= 0)
            {
                finalPosition = otherPortalRight.position;
            }
            else
            {
                finalPosition = otherPortalLeft.position;
            }
            collision.gameObject.transform.position = finalPosition;
        }
    }
}
