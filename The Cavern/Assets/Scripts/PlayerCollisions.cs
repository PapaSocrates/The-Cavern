using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField]
    public GameObject light;
    public GameObject lantern;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            light.SetActive(true);           
        }

        if (collision.gameObject.tag.Equals("Bounce") && GetComponent<playermovement>().fall)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            GetComponent<playermovement>().fall = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("LightOn"))
        {
            lantern.SetActive(true);
        }
        if (col.gameObject.tag.Equals("LightOff"))
        {
            lantern.SetActive(false);
        }

        if (col.gameObject.tag.Equals("Ending"))
        {
            Globals.stopMusic = true;
            SceneManager.LoadScene(8);
        }
    }
}