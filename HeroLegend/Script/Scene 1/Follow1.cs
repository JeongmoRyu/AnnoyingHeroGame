using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Follow1 : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 17;
    private bool isMoving = false; 
    public float startDelay = 3f;
    private Rigidbody2D enemy;
    private Vector2 movement;
    public int Speed;
    public bool isAttacking;
    // private GameObject dust;

    void Start()
    {
        enemy = this.GetComponent<Rigidbody2D>();
        StartCoroutine(StartMoving());
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Enemy"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Ground"), true);


        // StartCoroutine(MakeDust());
        // dust = enemy.GetComponentInChildren<GameObject>();
    }

    IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(startDelay); // 처음 3초 대기
        isMoving = true;
        
        
    }
    // IEnumerator MakeDust()
    // {
    //     yield return new WaitForSeconds(startDelay);
        
    //     // Dust 태그를 가진 모든 게임 오브젝트를 찾아서 배열로 받아옴
    //     GameObject.FindGameObjectWithTag("Dust").SetActive(true);
        

    // }
    void Update()
    {

        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan(direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;
                
        // enemy.SetDestination(GameManager.instance.player.transform.position);
    }
    void FixedUpdate()
    {
        if (isMoving)
        {
            moveCharacter(movement);
            Animator enemyAnimator = enemy.GetComponent<Animator>();
            enemyAnimator.SetTrigger("run");
        }

    }



    void moveCharacter(Vector2 direction)
    {
        enemy.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

}
