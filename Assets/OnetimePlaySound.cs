using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnetimePlaySound : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    void OnEnable()
    {
        SoundManager.instance.PlaySound(clip);
    }

   
}
