using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 1f; 
    }


    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);  
    }
}
