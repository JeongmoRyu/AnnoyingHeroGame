using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager4 : MonoBehaviour
{
    AudioSource bgmSource;

    private void Awake()
    {
        bgmSource = GetComponent<AudioSource>();
        
    }

    public void StartBgm()
    {
        bgmSource.Play();
    }

    public void StopBgm()
    {
        bgmSource.Stop();
    }
}
