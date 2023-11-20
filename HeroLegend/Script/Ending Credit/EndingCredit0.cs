using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingCredit0 : MonoBehaviour
{
    Animator endingCreditAnim;

    private void Awake()
    {
        endingCreditAnim = GetComponent<Animator>();
        endingCreditAnim.SetTrigger("StartEndingCredit");
    }

    public void BackToBeginning()
    {
        // 닉네임 입력하는 맨 처음 씬으로 이동
        SceneManager.LoadScene("InputName");
    }
}
