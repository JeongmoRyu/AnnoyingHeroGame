using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove1 : MonoBehaviour
{
    public float maxSpeed = 3.0f;
    public float moveSpeed = 3.0f; 
    public float jumpForce = 15.5f; 
    private bool isJumping = false; 
    Animator anim; 

    private Rigidbody2D rb; 
    private RectTransform rectTransform; 

    // Start is called before the first frame update
    void Start()
    {
        
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
        float h = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rb.velocity.x > maxSpeed) 
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        else if (rb.velocity.x < maxSpeed * (-1)) 
            rb.velocity = new Vector2(maxSpeed * (-1), rb.velocity.y);

        if (Input.GetButtonUp("Horizontal"))
        {
            rb.velocity = new Vector2(rb.velocity.normalized.x * 0.5f, rb.velocity.y);
        }

     
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
 
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }


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
