using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player1 : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    public float jumpForce = 30f; 
    // public float maxHealth;
    // public float health;
    private bool isJumping = false; 
    public Scanner1 scanner;
    // public Barrier barrier;
    // public GameObject barrier;    // public Hand[] hands;
    public RuntimeAnimatorController[] animCon;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    public RectTransform rectTransform; 
    private CapsuleCollider2D playerCollider; 
    public bool isRespawnTime;
    public bool dir_plus;

    Animator anim;

    // public Barrier barrier;
    
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rectTransform = GetComponent<RectTransform>();
        spriter = GetComponent<SpriteRenderer>();
        Transform playerTransform = this.transform;


        anim = playerTransform.Find("UnitRoot").GetComponent<Animator>();
        scanner = GetComponent<Scanner1>();
        // barrier = GetComponentInChildren<Barrier1>();

        // hands = GetComponentsInChildren<Hand>(true);
    }
    private void Start()
    {
        playerCollider = GetComponent<CapsuleCollider2D>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            return;  
        if (Input.GetKey(KeyCode.A))
            return;      
        Move();
        Jump();
    }
    void FixedUpdate()
    {
        Shield();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            return;
        if (Input.GetKey(KeyCode.A))
            return;

        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > speed) 
            rigid.velocity = new Vector2(speed, rigid.velocity.y);
        else if (rigid.velocity.x < speed * (-1)) 
            rigid.velocity = new Vector2(speed * (-1), rigid.velocity.y);

        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

     
        if (Input.GetButton("Horizontal"))
        {
            if (rigid.velocity.normalized.x > 0)
            {
                rectTransform.localRotation = Quaternion.Euler(0, 180, 0);
            } else if (rigid.velocity.normalized.x < 0)
            {
                rectTransform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }


    }
    bool Direction()
    {
        return rigid.velocity.normalized.x > 0;
    }
    void Jump()
    {
        
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            // rigid.gravityScale = 0.5f;
            rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }


        if (rigid.velocity.y < 0.5)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D hit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Ground"));
            if (hit.collider != null)
            {
                if (hit.distance < 0.5f)
                {
                    isJumping = false;
                    // rigid.gravityScale = 0;
                    // rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -0.8f);
                }
            }
        }
    }
    void Shield()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Player"), true);

            // playerCollider.size = new Vector2(0.1f, 0.1f);
            // playerCollider.enabled = false;

            // Unbeatable();
            // Invoke("Unbeatable", 3);
        }
        else 
        {
            transform.GetChild(0).gameObject.SetActive(false);
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemy"), LayerMask.NameToLayer("Player"), false);

            // playerCollider.size = new Vector2(0.6f, 0.8f);
            // playerCollider.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {        
        if (!GameManager1.instance.isLive)
            return;
        // if (collision.gameObject)
        // Debug.Log("return");
        if (transform.GetChild(0).gameObject.activeSelf == true && collision.gameObject.CompareTag("BossAttack"))
        {
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }

        if (transform.GetChild(0).gameObject.activeSelf == true)

            return;
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("BossAttack"))
        {
            if (collision.gameObject.CompareTag("BossAttack"))
            {
                Debug.Log("ouch!!");
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject);
            }
            GameManager1.instance.health -= 10;
            AudioManager1.instance.PlaySfx(AudioManager1.Sfx.Hit);


            if (GameManager1.instance.health < 0) 
            {
                for (int index = 2; index < transform.childCount; index++) 
                {
                    transform.GetChild(index).gameObject.SetActive(false);
                }

                anim.SetTrigger("Dead");
                GameManager1.instance.GameOver();
            }
        }
    }

}



        // if (rigid.velocity.y < 0.5)
        //     {
        //         Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
        //         RaycastHit2D hit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Ground"));
        //         if (hit.collider != null)
        //         {
        //             if (hit.distance < 0.5f)
        //             {
        //                 isJumping = false;
        //                 rigid.gravityScale = 0;
        //                 rigid.velocity = Vector2.zero; // 중력을 끄고 현재 속도 초기화
        //                 rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -0.4f);
        //             }
        //         }
        //     }

    
    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Ground"))
    //     {
    //         rigid.gravityScale = 0;
    //         isJumping = false;
    //         Vector3 newPosition = transform.position;
    //         newPosition.y = -0.7f;
    //         transform.position = newPosition;
    //     }
    // }







    // void FixedUpdate()
    // {
    //     // rigid.AddForce(inputVec); 힘주기
    //     // rigid.velocity = inputVec; 가속
    //     // if (!GameManager.instance.isLive)
    //     //     return;
    //     Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
    //     rigid.MovePosition(rigid.position + nextVec);
    // }

    // void OnMove(InputValue value)
    // {
    //     inputVec = value.Get<Vector2>();
    //     Debug.Log("hi");

    // }

    // void LateUpdate()
    // {
    //     // if (!GameManager.instance.isLive)
    //     //     return;
    //     anim.SetFloat("Speed", inputVec.magnitude);

    //     if (inputVec.x != 0) {
    //         spriter.flipX = inputVec.x < 0;

    //     }
    // }


