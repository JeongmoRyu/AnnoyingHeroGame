using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayer3 : MonoBehaviour
{
    public GameManager3 gameManager;


    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            gameManager.Action();
    }
}
