using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    // public float health;
    // public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target;
    bool isLive;
    Rigidbody2D rigid;
    Collider2D coll;
    Animator anim;
    // SpriteRenderer spriter;
    WaitForFixedUpdate wait;
    private Animator animator;
    Player1 player1;
    private bool OgreSound = false;

    
    

    // public bossPatterns[];

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        // spriter = GetComponent<SpriteRenderer>();
        wait = new WaitForFixedUpdate();
        player1 = GameManager1.instance.player.GetComponent<Player1>();
        animator = GetComponent<Animator>();
        

    }


    void FixedUpdate()
    {
        // if (!GameManager.instance.isLive)
        //     return;
        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")) 
            return;
    

    }

    void LateUpdate()
    {
        // if (!GameManager.instance.isLive)
        //     return;
        // float bosshealth = GameManager1.instance.bosshealth;
        // float bossmaxhealth = GameManager1.instance.maxbosshealth;

        if (!isLive) 
            return;
    
    }

    void OnEnable()
    {
        target = GameManager1.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        coll.enabled = true;
        rigid.simulated = true;
        // spriter.sortingOrder = 2;
        anim.SetBool("death", false);
        // bosshealth = bossmaxhealth;
    }
    
    // public void Init(SpawnData data)
    // {
    //     anim.runtimeAnimatorController = animCon[data.spriteType];
    //     maxHealth = data.health;
    //     health = data.health;
    // }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag("Noise") || !isLive)
            return;
        GameManager1.instance.bosshealth -= collision.GetComponent<Noise1>().damage;
        animator.SetTrigger("hit_1");

        // int damage = player1.Mike.activeSelf ? collision.GetComponent<PoolManager1>().prefabs[1].Damage : collision.GetComponent<PoolManager1>().prefabs[0].damage;
        // health -= damage;
        // if (player1.Mike.activeSelf == true)
        // {
        //     health -= collision.GetComponent<Noise1>().prefabId[0].damage;
        // }
        // else
        // {
        //     health -= collision.GetComponent<Noise1>().prefabId[0].damage;
        // }

        // StartCoroutine(KnockBack());
        

        if (GameManager1.instance.bosshealth > 0) {
            if (!OgreSound && (GameManager1.instance.bosshealth <= 60)) {
            AudioManager1.instance.PlaySfx(AudioManager1.Sfx.OgreHurt);
            OgreSound = true; 
            }
        }
        else {
            Dead();
        }

    }

    // public void Init(SpawnData data)
    // {
    //     // anim.runtimeAnimatorController = animCon[data.spriteType];
    //     maxHealth = data.health;
    //     health = data.health;
    // }


    // IEnumerator KnockBack()
    // {
    //     yield return wait;
    //     Vector3 playerPos = GameManager.instance.player.transform.position;        
    //     Vector3 dirVec = transform.position - playerPos;
    //     rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
    // }
    void Dead()
    {
        Debug.Log("dead");
        gameObject.SetActive(false);

    }

}
