using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public bool StartDefeatMusic;

    public GameObject DefeatMenuUI;

    void Start()
    {
        StartDefeatMusic = false;
    }
        // Update is called once per frame
        void Update()
    {
        if (GameObject.Find("IsAlive") == null)
        {
            DefeatMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;

            FindObjectOfType<AudioManager>().Stop("MainTheme");
            FindObjectOfType<AudioManager>().Stop("BossTheme");

            if (StartDefeatMusic == false)
            {
                FindObjectOfType<AudioManager>().Play("LoseTheme");
                StartDefeatMusic = true;

            }

        }
    }
}
