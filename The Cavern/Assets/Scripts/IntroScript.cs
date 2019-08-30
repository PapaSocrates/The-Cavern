using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    [SerializeField]
    GameObject gameIntro;

    VideoPlayer player;
    private bool game;
    void Start()
    {
        player = GetComponent<VideoPlayer>();
        game = false;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!player.isPlaying)
        {
            gameIntro.SetActive(true);
            game = true;
        }

        if (player.isPlaying || gameIntro.GetComponent<VideoPlayer>().isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(1);
            }
        }

        if (!gameIntro.GetComponent<VideoPlayer>().isPlaying && game)
        {
            SceneManager.LoadScene(1);
        }
    }
}