using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerBoss3 : MonoBehaviour
{
    public enum State { Stand, Jump, Hit, Death }
    public float startJumpPower;
    public float jumpPower;
    private float reducedJumpPower;
    public bool isGround;
    public bool isJumpKey;
    public UnityEvent onHit;
    public GameManager3 gameManager;

    Rigidbody2D rigid;
    Animator animator;
    Sounder3 sound;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sound = GetComponent<Sounder3>();
    }

    void Start()
    {
        sound.PlaySound(Sounder3.Sfx.Start);
    }

    void Update()
    {
        if (!GameManager3.isLive)
            return;

        // 1-1. 숏 점프 (기본 점프)
        if (Input.GetButtonDown("Jump") && isGround) // 누른 첫 상태
        {
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
        }

        // Input이 FixedUpdate에 들어있을 경우, 가끔 씹히는 경우가 있음 -> 변수 선언
        isJumpKey = Input.GetButton("Jump");
    }

    void FixedUpdate()
    {
        if (!GameManager3.isLive)
            return;

        // 1-2. 롱 점프
        if (isJumpKey && !isGround) // 누른 상태 지속
        {
            reducedJumpPower = Mathf.Lerp(reducedJumpPower, 0, 0.1f); // jumpPower -> 0
            rigid.AddForce(Vector2.up * reducedJumpPower, ForceMode2D.Impulse);
        }
    }

    // 2. 착지 (물리 충돌 이벤트)
    void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGround && GameManager3.isLive)
        {
            ChangeAnim(State.Stand);
            sound.PlaySound(Sounder3.Sfx.Land);
            reducedJumpPower = jumpPower; // 점프 상태에서 0이 되었다가, 착지했을 때 다시 1로
        }
        isGround = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Land")
        {
            ChangeAnim(State.Jump);
            sound.PlaySound(Sounder3.Sfx.Jump);
            isGround = false;
        }
    }

    // 3. 장애물 터치 (트리거 충돌 이벤트)
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            OnDamaged(collision.transform.position);
            Fire3 fire = collision.gameObject.GetComponent<Fire3>();
            fire.FireTouch();
        }
        else if (collision.gameObject.tag == "Item")
        {
            gameManager.health += 1;
            sound.PlaySound(Sounder3.Sfx.Item);
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Finish")
        {
            // 장면 전환
            gameManager.NextStage();
        }
    }


    void OnDamaged(Vector2 targetPos)
    {
        // Health Down
        gameManager.HealthDown();

        if (GameManager3.isLive)
        {
            ChangeAnim(State.Hit);
            sound.PlaySound(Sounder3.Sfx.Hit);
            gameObject.layer = 9;
            Invoke("OffDamaged", 1);
        }
    }

    void OffDamaged()
    {
        if (GameManager3.isLive)
        {
            ChangeAnim(State.Stand);
            gameObject.layer = 8;
        }
    }

    public void OnDie()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        sound.PlaySound(Sounder3.Sfx.Death);
        ChangeAnim(State.Death);
    }

    // 4. 애니메이션
    public void ChangeAnim(State state)
    {
        animator.SetInteger("State", (int)state);
    }
}
