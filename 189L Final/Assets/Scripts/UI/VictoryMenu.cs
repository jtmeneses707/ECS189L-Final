using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public bool StartVictoryMusic;

    public GameObject VictoryMenuUI;

    void Start()
    {
        StartVictoryMusic = false;
    }
        // Update is called once per frame
        void Update()
    {
        if (GameObject.Find("DemonKing") == null)
        {
            VictoryMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;

            FindObjectOfType<AudioManager>().Stop("MainTheme");
            FindObjectOfType<AudioManager>().Stop("BossTheme");

            if (StartVictoryMusic == false)
            {
                FindObjectOfType<AudioManager>().Play("VictoryTheme");
                StartVictoryMusic = true;

            }
        }
    }
}
