using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialMonster4 : MonoBehaviour
{
    Animator specialMonsterAnim;
    SpriteRenderer specialMonsterSpriteRenderer;

    private void Awake()
    {
        specialMonsterAnim = GetComponent<Animator>();
        specialMonsterSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ActivateSpecialMonster()
    {
        specialMonsterAnim.SetTrigger("SpecialMonster4Activate");
    }

    public void SpecialMonsterDead()
    {
        specialMonsterAnim.SetTrigger("SpecialMonster4Dead");
    }
}
