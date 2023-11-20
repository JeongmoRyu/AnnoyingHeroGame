using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager2 : MonoBehaviour
{
    public static AudioManager2 instance;
    [Header("#BGM")]
    public AudioClip[] bgmClips;
    public float bgmVolume;
    AudioSource bgmPlayer;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;

    public enum Sfx {Walk, Scan,PlayerSkill, Hit, EnemyAttack, EnemyHit, BossAttack, BossTeleport, BossHit, BossShield, EnemyAppear, Die, Clear, PlayerAttack, PlayerEat}

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
        bgmPlayer.clip = bgmClips[0];

        GameObject sfxObject = new GameObject("bgmPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];

        for (int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].bypassListenerEffects = true;
            sfxPlayers[index].volume = sfxVolume;
        }
    }
    public void PlayBgm(bool isPlay)
    {
        if (isPlay)
        {
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }

    public void PlaySfx(Sfx sfx)
    {
        for (int index = 1; index < sfxPlayers.Length; index++)
        {
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;
            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            if ((int) sfx == 6)
            {
                sfxPlayers[loopIndex].volume = 0.3f;
            } else
            {
                sfxPlayers[loopIndex].volume = sfxVolume;
            }

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }

    public void PlayWalk()
    {
        if (!sfxPlayers[0].isPlaying) {
            sfxPlayers[0].clip = sfxClips[(int) Sfx.Walk];
            sfxPlayers[0].Play();
        }
    }

    public void ChangeBgm(int index)
    {
        bgmPlayer.clip = bgmClips[index];
        PlayBgm(true);
    }
}
