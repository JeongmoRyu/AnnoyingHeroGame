using UnityEngine;

public class PlayerAction03 : MonoBehaviour
{
    public GameManager03 manager;

    public float moveSpeed;
    private int spacebarCount = 0;

    private bool spacebarActivated = false;
    private float rightMoveDuration = 2.9f; // 이동 시간 (right)
    private float rightMoveTimer = 0.0f;

    private float downMoveDuration = 1.0f; // 이동 시간 (down)
    private float downMoveTimer = 0.0f;

    Rigidbody2D rigid;
    Vector3 dirVec;
    GameObject scanObject;

    Animator anim;
    float h;
    float v;
    bool isHorizonMove; // 수평으로 이동하고 있는가?

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Scan Object
        if (Input.GetButtonDown("Jump"))
            manager.Action(scanObject);

        if (spacebarActivated) // 3번째 스크립트 미클릭!
        {
            rightMoveTimer += Time.deltaTime;

            /********************* 우향 이동 [S] *********************/
            if (rightMoveTimer >= rightMoveDuration)
            {
                rightMoveTimer = 4.0f;

                /********************* 하향 이동 [S] *********************/

                downMoveTimer += Time.deltaTime;

                if (downMoveTimer >= downMoveDuration)
                {
                    spacebarActivated = false;
                    spacebarCount = 0;
                    downMoveTimer = 4.0f;
                }
                else
                {
                    if (anim.GetInteger("vAxisRaw") != -1)
                    {
                        anim.SetBool("isChanged", true);
                        anim.SetInteger("vAxisRaw", -1);
                    }
                    else
                        anim.SetBool("isChanged", false);

                    transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
                }
                /********************* 하향 이동 [S] *********************/
            }
            else
            {
                // 스페이스바 효과 진행 중
                if (anim.GetInteger("hAxisRaw") != 1)
                {
                    anim.SetBool("isChanged", true);
                    anim.SetInteger("hAxisRaw", 1);
                }
                else
                    anim.SetBool("isChanged", false);

                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            /********************* 우향 이동 [E] *********************/
        }
        else // 3번째 스크립트 클릭하면 주인공 횡단보도로 이동 시작
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spacebarCount++;

                if (spacebarCount >= 4)
                {
                    spacebarActivated = true;
                }
            }

            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            bool hDown = Input.GetButtonDown("Horizontal");
            bool vDown = Input.GetButtonDown("Vertical");
            bool hUp = Input.GetButtonUp("Horizontal");
            bool vUp = Input.GetButtonUp("Vertical");

            if (hDown) // 좌 또는 우 방향키를 눌렀다면
                isHorizonMove = true; // 수평 이동 True
            else if (vDown) // 상 또는 하 방향키를 눌렀다면
                isHorizonMove = false; // 수평 이동 True    
            else if (hUp || vUp)
                isHorizonMove = h != 0;

            if (anim.GetInteger("hAxisRaw") != h)
            {
                anim.SetBool("isChanged", true);
                anim.SetInteger("hAxisRaw", (int)h);
            }
            else if (anim.GetInteger("vAxisRaw") != v)
            {
                anim.SetBool("isChanged", true);
                anim.SetInteger("vAxisRaw", (int)v);
            }
            else
                anim.SetBool("isChanged", false);

            // Direction
            if (vDown && v == 1) // Up Key
                dirVec = Vector3.up;
            else if (vDown && v == -1) // Down Key
                dirVec = Vector3.down;
            else if (hDown && h == -1) // Left Key
                dirVec = Vector3.left;
            else if (hDown && h == 1) // Right Key
                dirVec = Vector3.right;
        }
    }

    void FixedUpdate()
    {
        // Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
            scanObject = rayHit.collider.gameObject;
        else
            scanObject = null;
    }
}
