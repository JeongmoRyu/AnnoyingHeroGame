using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox1 : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    bool isLive;
    Rigidbody2D rigid;
    Collider2D coll;
    Animator anim;
    // SpriteRenderer spriter;
    WaitForFixedUpdate wait;
    public Transform player;
    // public GameObject[] itemPrefabs;
    public int id;
    public SpawnedItem1 spawnedItemScript;
    private Transform boxTransform;



    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        spawnedItemScript = GetComponent<SpawnedItem1>();
        // spawnedItemScript = GetComponent<Spawn
        // spriter = GetComponent<SpriteRenderer>();
        wait = new WaitForFixedUpdate();
        boxTransform = transform;

    }
    void LateUpdate()
    {
        if (!GameManager1.instance.isLive)
            return;
        if (!isLive) 
            return;
    
    }
    // void LateUpdate()
    // {
    //     if (isLive)
    //         return;
    //     // Vector3 distance_box = player.position - transform.position;
    //     // if (!isLive && distance_box[0] > 18)
    //     // {   
    //     //     isLive = true;
    //     //     // transform.gameObject.SetActive(true);
    //     // }
        
    //     // Debug.Log(distance_box);


    //     // if (!GameManager.instance.isLive)
    //     //     return;
    //     if (!isLive)
    //     {
    //         Vector3 distance_box = player.position - transform.position;
            
    //         if (!isLive && distance_box[0] > )
    //         {   
    //         isLive = true;
    //         transform.gameObject.SetActive(true);
    //         }
    //     } 
    //         return;
        
    // }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        maxHealth = data.health;
        health = data.health;
    }

    void OnEnable()
    {
        isLive = true;
        coll.enabled = true;
        rigid.simulated = true;
        // spriter.sortingOrder = 2;
        anim.SetBool("Dead", false);
        health = maxHealth;
    }

    void Dead()
    {

        if (spawnedItemScript != null)
        {
            spawnedItemScript.DropItem(boxTransform.position); 

            // spawnedItemScript.DropItem();
        }
        gameObject.SetActive(false);
        // StartCoroutine(DropItem());

    }
    // IEnumerator DropItem()
    // {
    //     yield return new WaitForSeconds(0.5f);
    //     int randomItemIndex = Random.Range(0, itemPrefabs.Length);
    //     GameObject spawnedItem = Instantiate(itemPrefabs[randomItemIndex], transform.position, Quaternion.identity);
        
    // }
// if (spawnedItem.CompareTag("Player"))
//         {
//             spawnedItem.gameObject.SetActive(false);
//         }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Noise") || !isLive)
            return;
        
        health -= collision.GetComponent<Noise1>().damage;
        // StartCoroutine(KnockBack());

        if (health > 0) {

        }
        else
        {
            isLive = false;
            coll.enabled = false;
            rigid.simulated = false;
            // spriter.sortingOrder = 1;
            anim.SetBool("Dead", true);
            AudioManager1.instance.PlaySfx(AudioManager1.Sfx.BoxOpen);
            // Dead();
        }

 


    }
    

}

