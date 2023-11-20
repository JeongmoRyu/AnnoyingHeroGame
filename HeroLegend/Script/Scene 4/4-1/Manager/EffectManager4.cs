using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager4 : MonoBehaviour
{
    [SerializeField] Animator noteHitAnimator = null;
    string hit = "Hit";

    [SerializeField] Animator judgementAnimator = null;
    [SerializeField] UnityEngine.UI.Image judgementImage = null;
    [SerializeField] Sprite[] judgementSprite = null;

    [SerializeField] Animator spaceButtonDownAnimator = null;

    [SerializeField] Animator legShakeAnimator = null;

    [SerializeField] Animator legBossAnimator = null;

    [SerializeField] AudioClip[] effectAudioClips = null;
    AudioSource effectAudio;

    private void Awake()
    {
        effectAudio = GetComponent<AudioSource>();
    }

    public void JudgementEffect(int p_num)
    {
        judgementImage.sprite = judgementSprite[p_num];
        judgementAnimator.SetTrigger(hit);
    }

    public void NoteHitEffect()
    {
        noteHitAnimator.SetTrigger(hit);
        legBossAnimator.SetTrigger("LegBossHit");

        effectAudio.volume = 0.25f;
        effectAudio.clip = effectAudioClips[0];
        effectAudio.Play();
    }

    public void SpaceButtonDownEffect()
    {
        spaceButtonDownAnimator.SetTrigger("SpaceButtonDown");
        legShakeAnimator.SetTrigger("LegShake");
    }

    public void LegBossAttackEffect()
    {
        legBossAnimator.SetTrigger("LegBossAttack");
        legShakeAnimator.SetTrigger("LegHit");

        effectAudio.volume = 0.25f;
        effectAudio.clip = effectAudioClips[1];
        effectAudio.Play();
    }

    public void LegBossBigHitEffect()
    {
        legBossAnimator.SetTrigger("LegBossBigHit");
    }
}
