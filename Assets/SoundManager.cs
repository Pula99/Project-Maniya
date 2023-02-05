using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }
    public AudioSource BgSound { get => bgSound; set => bgSound = value; }
    public AudioSource Source { get => source; set => source = value; }

    private AudioSource source;
    [SerializeField] private AudioSource bgSound;

    private void Awake()
    {
     
        Source = GetComponent<AudioSource>();

        //keep this object even all the time(next levels)
        if( instance == null)
        {
            instance = this;
        } 
    }

    public void PlaySound(AudioClip sound)
    {
        Source.PlayOneShot(sound);
    }
}
