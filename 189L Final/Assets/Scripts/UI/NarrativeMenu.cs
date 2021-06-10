using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeMenu : MonoBehaviour
{
    public GameObject NarrativeUI;
    public void CloseNarrative()
    {
        NarrativeUI.SetActive(false);
    }
}
