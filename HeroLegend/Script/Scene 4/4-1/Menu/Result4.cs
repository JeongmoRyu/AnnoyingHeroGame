using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Result4 : MonoBehaviour
{
    // 평소에는 비활성화 해놓고, 필요할 때 활성화시킬거
    [SerializeField] GameObject goUI = null;

    [SerializeField] TextMeshProUGUI[] txtCount = null;
    [SerializeField] TextMeshProUGUI txtScore = null;
    [SerializeField] TextMeshProUGUI txtMaxCombo = null;
    [SerializeField] TextMeshProUGUI txtResult = null;

    [SerializeField] AudioClip[] resultAudioClips = null;

    public int clearPoint = 1000;

    ScoreManager4 theScore;
    ComboManager4 theCombo;
    TimingManager4 theTiming;
    AudioSource resultAudio;

    TimeManager timeManager;

    string nickname;

    private void Start()
    {
        theScore = FindObjectOfType<ScoreManager4>();
        theCombo = FindObjectOfType<ComboManager4>();
        theTiming = FindObjectOfType<TimingManager4>();
        resultAudio = GetComponent<AudioSource>();

        // 닉네임을 제대로 바꿔주자
        nickname = PlayerPrefs.GetString("nickname", "defaultNickname");
        DBManager.Instance.StartGame(4, nickname);
        timeManager = FindObjectOfType<TimeManager>();
        // timeManager.setTime(data.getPlayTime());
        timeManager.setTime(0);
    }

    public void ShowResult()
    {
        goUI.SetActive(true);
        Time.timeScale = 0f;

        int[] t_judgement = theTiming.GetJudgementRecord();
        int t_currentScore = theScore.GetCurrentScore();
        int t_maxCombo = theCombo.GetMaxCombo();

        for (int i = 0; i < txtCount.Length; i++)
        {
            txtCount[i].text = string.Format("{0:#,##0}", t_judgement[i]);
                
        }

        txtScore.text = string.Format("{0:#,##0}", t_currentScore);
        txtMaxCombo.text = string.Format("{0:#,##0}", t_maxCombo);


        if (t_currentScore < clearPoint) 
        {
            // 실패 시
            txtResult.text = "<#FF0000>Fail..</color>";

            resultAudio.clip = resultAudioClips[1];
            resultAudio.Play();
        }
        else
        {
            // 성공 시
            txtResult.text = "<#00FF00>Clear!</color>";

            resultAudio.clip = resultAudioClips[0];
            resultAudio.Play();
        }
    }

    public void ReturnToTopDownWorld()
    {
        int t_currentScore = theScore.GetCurrentScore();

        // 전달할 데이터 저장
        PlayerPrefs.SetInt("isReturnToTopDownWorld", 1);

        if (t_currentScore < clearPoint)
        {
            // 실패했을 때
            PlayerPrefs.SetInt("isClear4", 0);
        }
        else
        {
            // 승리했을 때
            PlayerPrefs.SetInt("isClear4", 1);

            // 스코어는 임시로 0
            int score4 = (int)(t_currentScore * 100 / 3000);
            DBManager.Instance.EndGame(4, nickname, score4, timeManager.getTime());
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene("Scene 4");
    }
}
