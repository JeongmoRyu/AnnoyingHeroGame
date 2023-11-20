using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControllerVillage : MonoBehaviour   
{
    public Vector2 inputVec;
    public float speed = 8f;
    public Rigidbody2D rigid;
    // public GameManager4 gameManager;
    // public DialogManager4 dialogManager;

    // -----------------------------------------------------------------------------------------
    // private members
    private Vector2 movement;
    bool isHorizonMove;

    // Animator anim;
    Vector3 dirVec;
    GameObject scanObject;

    void Update()
    {   
        Move();
    }

    void Move()
    {

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


    }
    bool Direction()
    {
        return rigid.velocity.normalized.x > 0;
    }


    // -----------------------------------------------------------------------------------------
    // awake method to initialisation
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        // anim = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            Map();
        }
    }
    public void Map()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Scenes/Map");
    }
}
