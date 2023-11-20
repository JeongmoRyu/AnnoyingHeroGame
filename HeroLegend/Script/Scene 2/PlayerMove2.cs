using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    public float maxSpeed = 3.0f;
    public float moveSpeed = 3.0f; // 플레이어의 좌우 이동 속도
    public float jumpForce = 15.5f; // 점프할 때의 힘
    private bool isJumping = false; // 점프 중인지 아닌지 판단하기 위한 변수
    Animator anim; // 애니메이션 전환을 위한 

    private Rigidbody2D rb; // 플레이어의 Rigidbody2D 컴포넌트
    private RectTransform rectTransform; // 플레이어 회전 컴포넌트 

    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody2D 컴포넌트를 가져옵니다.
        rb = GetComponent<Rigidbody2D>();
        rectTransform = GetComponent<RectTransform>();

        Transform playerTransform = this.transform;
        anim = playerTransform.Find("UnitRoot").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        // Player Move
        float h = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        // 최대 속도 제한
        if (rb.velocity.x > maxSpeed) // Right Max Speed
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        else if (rb.velocity.x < maxSpeed * (-1)) // Left
            rb.velocity = new Vector2(maxSpeed * (-1), rb.velocity.y);

        // Speed 멈추기
        if (Input.GetButtonUp("Horizontal"))
        {
            rb.velocity = new Vector2(rb.velocity.normalized.x * 0.5f, rb.velocity.y);
        }

        // 이동방향에 따라 Player 뒤집기
        if (Input.GetButton("Horizontal"))
        {
            if (rb.velocity.normalized.x > 0)
            {
                rectTransform.localRotation = Quaternion.Euler(0, 180, 0);
            } else if (rb.velocity.normalized.x < 0)
            {
                rectTransform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (Mathf.Abs(rb.velocity.x) > 0.3)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);
    }

    void Jump()
    {
        // 점프
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }

        // 착지
        if (rb.velocity.y < 0)
        {
            Debug.DrawRay(rb.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector3.down, 1, LayerMask.GetMask("PlatForm"));
            if (hit.collider != null)
            {
                if (hit.distance < 0.5f)
                {
                    isJumping = false;
                }
            }
        }
    }
}
