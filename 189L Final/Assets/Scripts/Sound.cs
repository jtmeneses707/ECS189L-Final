using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string Name;
    public AudioClip Clip;

    [Range(0.0f, 10.0f)]
    public float Volume;
    [Range(0.1f, 10.0f)]
    public float Pitch;
    public bool Loop;
    [HideInInspector]
    public AudioSource source;
}
