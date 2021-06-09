using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicTrigger : MonoBehaviour
{

    private AudioManager AM;

    void Awake()
    {
        if (AM == null) // Ensure that there is always an audio manager
        {
            AM = FindObjectOfType<AudioManager>(); 
        }
        else // Get rid of more than one audiomanager
        {
            Destroy(gameObject);
        }

    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            AM.ChangeBGM();
        }
    } 
}
