using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    VideoPlayer player;

    void Start()
    {
        player = GetComponent<VideoPlayer>();
    }


    void Update()
    {
        if (!player.isPlaying)
        {
            SceneManager.LoadScene(1);
        }

        if (player.isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
