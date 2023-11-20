using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSounder3 : MonoBehaviour
{
    public enum BossSfx { Cleave, Breath, Smash }
    public AudioClip[] clips;
    AudioSource audios;

    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    public void PlaySound(BossSfx sfx)
    {
        audios.clip = clips[(int)sfx];
        audios.Play();
    }
}
