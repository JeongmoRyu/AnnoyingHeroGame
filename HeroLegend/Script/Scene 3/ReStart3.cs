using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReStart3 : MonoBehaviour
{
    private Vector3 initialVector;
    public Vector3 initialPosition;

    void Awake()
    {
        //initialVector = transform.position;
        initialPosition = transform.position;
        GameManager3.restartObj++;
        GameManager3.tempRestartObj++;
    }
    void FixedUpdate()
    {
        if (GameManager3.isRestart)
        {
            if (GameManager3.tempRestartObj != 0)
            {
                //transform.position = initialVector;
                transform.position = initialPosition;
                GameManager3.tempRestartObj--;
                if (transform.name == "Health Group")
                {
                    for (int i = 0; i < transform.childCount; i++)
                    {
                        transform.GetChild(i).gameObject.SetActive(true);
                    }
                }
            }
            else
            {
                GameManager3.isRestart = false;
                GameManager3.tempRestartObj = GameManager3.restartObj;
            }
        }
    }
}
