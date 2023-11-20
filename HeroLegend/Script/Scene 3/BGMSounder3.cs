using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMSounder3 : MonoBehaviour
{
    public enum BGMSfx { Intro, End, Trouble, Stage, Boss }
    public AudioClip[] clips;
    AudioSource audios;

    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    public void PlaySound(BGMSfx sfx)
    {
        audios.clip = clips[(int)sfx];
        audios.Play();
    }
}
