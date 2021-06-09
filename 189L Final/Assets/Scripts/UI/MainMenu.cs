using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {
        AudioManager.instance.Stop("BossTheme");
        AudioManager.instance.Stop("VictoryTheme");
        AudioManager.instance.Stop("LoseTheme");
        if (!AudioManager.instance.IsPlaying("MainTheme"))
            AudioManager.instance.Play("MainTheme");
    }

    // Start is called before the first frame update
    public void PlayGame()
    {
        Debug.Log("Loading next scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
