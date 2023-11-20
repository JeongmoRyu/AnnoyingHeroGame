using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayer5_0 : MonoBehaviour
{
    public GameManager5_0 gameManager;

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            gameManager.Action();
    }
}
