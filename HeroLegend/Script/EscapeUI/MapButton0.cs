using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] EscapeUIManager0 escapeUIManager;

    void Start()
    {
        Button mapButton = GetComponent<Button>();
        mapButton.onClick.AddListener(escapeUIManager.GoMap);
    }
}
