using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{

    public AudioManager AM;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            AM.ChangeBGM();
        }
    } 
}
