using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton0 : MonoBehaviour
{
    [SerializeField] EscapeUIManager0 escapeUIManager;

    void Start()
    {
        Button quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(escapeUIManager.QuitGame);
    }
}
