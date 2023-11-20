using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCameraVillage : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void MoveCameraMap()
    {
        animator.SetTrigger("CameraVillageMove");
    }
    public void MoveCameraBasic()
    {
        animator.SetTrigger("CameraVillageBasic");
    }
}

