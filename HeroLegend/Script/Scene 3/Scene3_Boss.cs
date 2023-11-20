using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3_Boss : MonoBehaviour
{
    public GameManager3 gameManager;
    Rigidbody2D rigid;
    Animator animator;
    BossSounder3 sound;
    public GameObject[] objects;
    private int nextAnim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sound = GetComponent<BossSounder3>();

        Think();

        Invoke("Think", 5);
    }


    public void Think()
    {
        if (!GameManager3.isLive)
            return;

        nextAnim = Random.Range(1, 4);
        ChangeAnim(nextAnim);

        switch (nextAnim)
        {
            case 1:
                // 1. Cleave
                Invoke("ChangeToIdle", 1);
                Invoke("ChangeActive", 1);
                break;
            case 2:
                // 2. Breath
                Invoke("ChangeToIdle", 1);
                Invoke("ChangeActive", 1);
                break;
            case 3:
                // 3. Smash
                Invoke("ChangeToIdle", 1);
                Invoke("ChangeActive", 1);
                break;
            default:
                break;
        }

        int turn = Random.Range(2, 4);
        Invoke("Think", turn);
    }

     void ChangeAnim(int state)
    {
        animator.SetInteger("State", state);
    }

    void ChangeToIdle()
    {
        animator.SetInteger("State", 0);
    }
    void ChangeActive()
    {
        if (nextAnim == 1)
        {
            objects[nextAnim - 1].gameObject.SetActive(true);
            sound.PlaySound(BossSounder3.BossSfx.Cleave);
        }
        else
        {
            objects[nextAnim - 1].gameObject.SetActive(true);
            for (int index = 0; index < 4; index++)
            {
                objects[nextAnim - 1].transform.GetChild(index).gameObject.SetActive(true);
            }

            if (nextAnim == 2)
                sound.PlaySound(BossSounder3.BossSfx.Breath);
            else
                sound.PlaySound(BossSounder3.BossSfx.Smash);
        }
    }

}

