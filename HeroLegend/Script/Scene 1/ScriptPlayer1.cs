using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayer1 : MonoBehaviour
{

    public GameManager1_1 gameManager;


    void Update()
    {
        if (Input.GetButtonDown("Jump"))
            gameManager.Action();
    }

}