using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject VictoryMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("DemonKing") == null)
        {
            VictoryMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }
    }
}
