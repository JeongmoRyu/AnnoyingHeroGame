using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score3 : MonoBehaviour
{

    Text uiText;

    void Start()
    {
        uiText = GetComponent<Text>();

    }

    void LateUpdate()
    {
        if (!GameManager3.isLive)
            return;

        uiText.text = GameManager3.score.ToString("F0");
    }
}
