using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterFrame4 : MonoBehaviour
{
    AudioSource myAudio;
    NoteManager4 theNote;
    ScoreManager4 theScore;
    EffectManager4 theEffect;
    bool musicStart = false;

    Result4 theResult;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
        theNote = FindObjectOfType<NoteManager4>();
        theScore = FindObjectOfType<ScoreManager4>();
        theEffect = FindObjectOfType<EffectManager4>();
        theResult = FindObjectOfType<Result4>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!musicStart)
        {
            if (collision.CompareTag("Note"))
            {
                myAudio.Play();
                musicStart = true;
            }
        } 
        else if (!myAudio.isPlaying) { // 게임을 시작했고, 음악이 끝났으면 게임 종료
            PlayerController4.s_canPresskey = false;
            theNote.RemoveNote();
            // theResult.ShowResult();
            
            if (theScore.DoesWin())
            {
                theEffect.LegBossBigHitEffect();
            }

            Invoke("InvokeShowResult", 2f);
        }
    }

    private void Update()
    {
        if (musicStart && Input.GetKeyDown(KeyCode.Escape))
        {
            if (myAudio.isPlaying)
            {
                myAudio.Pause();
            }
            else
            {
                myAudio.UnPause();
            }
        }
    }

    private void InvokeShowResult()
    {
        theResult.ShowResult();
    }
}
