using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDead4 : MonoBehaviour
{
    Animator monsterDeadAnim;

    private void Awake()
    {
        monsterDeadAnim = GetComponent<Animator>();
    }

    public void MonsterDead()
    {
        monsterDeadAnim.SetTrigger("MonsterDead");
    }
}
