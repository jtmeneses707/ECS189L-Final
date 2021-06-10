using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    public GameObject VictoryMenuUI;
    public GameObject DefeatMenuUI;
    public GameObject ControlMenuUI;
    public GameObject NarrativeUI;

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        ControlMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Controls()
    {
        PauseMenuUI.SetActive(false);
        ControlMenuUI.SetActive(true);
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");
        Debug.Log("We are in LoadMenu()");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && VictoryMenuUI.activeInHierarchy != true && DefeatMenuUI.activeInHierarchy != true 
        && ControlMenuUI.activeInHierarchy != true && NarrativeUI.activeInHierarchy != true)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        }
    }
}
