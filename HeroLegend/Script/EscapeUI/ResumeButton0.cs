using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton0 : MonoBehaviour
{
    [SerializeField] EscapeUIManager0 escapeUIManager;

    void Start()
    {
        Button resumeButton = GetComponent<Button>();
        resumeButton.onClick.AddListener(escapeUIManager.ToggleEscapeUI);
    }
}
