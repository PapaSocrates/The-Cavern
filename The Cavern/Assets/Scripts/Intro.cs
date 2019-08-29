using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField]
    GameObject video;

    private bool menu;

    void Start()
    {
        Cursor.visible = false;
        menu = false;
    }


    void Update()
    {
        if (!gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().isPlaying)
        {
            menu = true;
        }

        if (menu)
        {
            video.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && menu)
        {
            Application.Quit();
        }
        
        if (Input.GetKeyDown(KeyCode.Return) && menu)
        {
            SceneManager.LoadScene(1);
        }
    }
}