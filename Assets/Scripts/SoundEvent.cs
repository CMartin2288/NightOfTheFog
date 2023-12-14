using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SoundEvent : MonoBehaviour
{
    public AudioSource audioData;

    void Start()
    {
        //audioData.Play(0);
    }

    public void PlaySound()
    {
        audioData.Play(0);
    }
}