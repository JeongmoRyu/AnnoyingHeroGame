using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScriptCamera1 : MonoBehaviour

{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void MoveCameraOne()
    {
        animator.SetTrigger("Camera1Move");
    }
    public void MoveCameraBoss()
    {
        animator.SetTrigger("Camera1Boss");
    }
}
