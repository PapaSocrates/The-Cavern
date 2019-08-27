using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exitdoor : MonoBehaviour
{
    Scene EscenaActual;
    // Start is called before the first frame update
    void Start()
    {
        EscenaActual = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            SceneManager.LoadScene(EscenaActual.buildIndex + 1);
        }

    }
}
