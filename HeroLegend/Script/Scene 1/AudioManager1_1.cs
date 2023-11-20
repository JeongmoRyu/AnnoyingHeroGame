using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager1_1 : MonoBehaviour
{
    public static AudioManager1_1 instance;

    [Header("#BGM")]
    public AudioClip bgmClip;
        
    public float bgmVolume;
    AudioSource bgmPlayer;
    AudioHighPassFilter bgmEffect;
    void Awake()
    {
        instance = this;
        Init();
    }
void Init()
    {
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform;
        bgmPlayer = bgmObject.AddComponent<AudioSource>();
        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;
        bgmEffect = Camera.main.GetComponent<AudioHighPassFilter>();

    }
    public void PlayBgm(bool isPlay)
    {
        if (isPlay) {
            bgmPlayer.Play();
        } else {
            bgmPlayer.Stop();
        }
    }
    public void EffectBgm(bool isPlay)
    {
        bgmEffect.enabled = isPlay;
    }

}
