using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) // Ensure that there is always an audio manager
        {
            instance = this;
        }
        else // Get rid of more than one audiomanager
        {
            Destroy(gameObject);
        }

        // Prevent audio from being cut when changing scenes
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = this.gameObject.AddComponent<AudioSource>();
            s.source.clip = s.Clip;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
            s.source.loop = s.Loop;
        }
    }

    void Start()
    {
        // Play the audio clip named within the Audio Manager
        Play("MainTheme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);

        if(s == null)
        {
            Debug.LogWarning("Wrong Audio Name: " + name);
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);

        if (s == null)
        {
            Debug.LogWarning("Wrong Audio Name: " + name);
            return;
        }

        s.source.Stop();
    }

    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);

        if (s != null)
        {
            if (s.source.isPlaying)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public void ChangeBGM()
    {
        // If we are already playing the theme just stop the function
        if (IsPlaying("BossTheme"))
        {
            return;
        }

        Stop("MainTheme");
        Play("BossTheme");
    }

}
