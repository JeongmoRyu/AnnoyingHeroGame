using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounder3 : MonoBehaviour
{
    public enum Sfx { Jump, Land, Hit, Start, Item, Death}
    public AudioClip[] clips;
    AudioSource audios;


    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    public void PlaySound(Sfx sfx)
    {
        audios.clip = clips[(int)sfx];
        audios.Play();
    }
}
