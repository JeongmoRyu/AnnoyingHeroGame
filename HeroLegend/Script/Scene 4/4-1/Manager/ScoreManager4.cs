using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager4 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txtScore = null;

    [SerializeField] int increaseScore = 10;
    int currentScore = 0;

    [SerializeField] float[] weight = null;
    [SerializeField] int comboBonusScore = 3;

    Animator myAnim;
    string animScoreUp = "ScoreUp";

    ComboManager4 theCombo;

    Result4 result;


    void Start()
    {
        theCombo = FindObjectOfType<ComboManager4>();
        myAnim = GetComponent<Animator>();
        result = FindObjectOfType<Result4>();
        currentScore = 0;
        txtScore.text = "0";
    }

    public void IncreaseScore(int p_JudgementState)
    {
        int t_increaseScore = increaseScore;

        // 가중치 계산
        t_increaseScore = (int)(t_increaseScore * weight[p_JudgementState]);

        if (t_increaseScore > 0)
        {
            // 콤보 증가
            theCombo.IncreaseCombo();

            myAnim.SetTrigger(animScoreUp);

            // 콤보 보너스 점수 계산
            int t_currentCombo = theCombo.GetCurrentCombo();
            int t_bonusComboScore = (t_currentCombo / 10) * comboBonusScore;

            t_increaseScore += t_bonusComboScore;
        }
        else
        {
            theCombo.ResetCombo();
        }

        currentScore += t_increaseScore;
        currentScore = Mathf.Max(0, currentScore);
        txtScore.text = string.Format("{0:#,##0}", currentScore);
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public bool DoesWin()
    {
        return result.clearPoint <= currentScore;
    }
}
