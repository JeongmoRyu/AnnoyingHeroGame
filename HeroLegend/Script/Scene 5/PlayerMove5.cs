using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove5 : MonoBehaviour
{
    public float Speed;
    public GameObject explosionPrefab; // 폭발 게임 오브젝트 프리팹
    public Dictionary<string, Sprite[]> explosionSprites; // 각 객체 이름에 대응하는 스프라이트 배열
    public Sprite Donut1_1, Donut1_2, Donut2_1, Donut2_2, Donut3_1, Donut3_2, Pizza1, Pizza2, Watermelon1, Watermelon2;
    public GameManager5 manager;
    public bool isDead = false;
    public AudioSource scoreUpSound;

    Rigidbody2D rigid;
    Animator anim;
    float h;
    float v;
    bool isHorizonMove; // 수평으로 이동하고 있는가?
    bool isAttackReady = false; // 공격 가능 상태
    Vector3 dirVec;
    GameObject scanObject;


    public AudioSource backgroundMusic;
    void Start()
    {
        backgroundMusic.loop = true;  // 음악이 끝나면 다시 처음부터 재생
        backgroundMusic.Play();  // 배경음악 재생 시작
    }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();

        explosionSprites = new Dictionary<string, Sprite[]>
        {
            { "Donut1(Clone)", new Sprite[] { Donut1_1, Donut1_2 } },
            { "Donut2(Clone)", new Sprite[] { Donut2_1, Donut2_2 } },
            { "Donut3(Clone)", new Sprite[] { Donut3_1, Donut3_2 } },
            { "Pizza(Clone)", new Sprite[] { Pizza1, Pizza2 } },
            { "Watermelon(Clone)", new Sprite[] { Watermelon1, Watermelon2 } },
        };
    }

    void Update()
    {
        if (isDead)  // 캐릭터가 사망한 상태라면
        {
            return;
        }

            h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        if (h != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Jump") && manager.isDialogueEnded)
        {
            anim.SetBool("isSkilled", true);
            isAttackReady = true; // 공격 가능 상태를 true로 설정
        }
        else if (anim.GetBool("isSkilled") == true && manager.isDialogueEnded)
        {
            anim.SetBool("isSkilled", false);
            Invoke("ResetAttackReady", 0.5f); // 0.5초 후에 공격 가능 상태를 false로 설정
        }

        if (h > 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (h < 0)
            transform.localScale = new Vector3(1, 1, 1);

        // Direction
        //if (vDown && v == 1) // Up Key
        //    dirVec = Vector3.up;
        else if (vDown && v == -1) // Down Key
            dirVec = Vector3.down;
        else if (hDown && h == -1) // Left Key
            dirVec = Vector3.left;
        else if (hDown && h == 1) // Right Key
            dirVec = Vector3.right;

        if (Input.GetButtonDown("Jump") && !manager.isDialogueEnded) // 대화가 끝나지 않았을 때만 Action 실행
            manager.Action();
    }

    void FixedUpdate()
    {
        // 수평 이동이라면 vs 수평 이동이 아니라면
        //Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        //rigid.velocity = moveVec * Speed;
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);

        // 위쪽 이동을 막는 조건 추가
        if (v > 0)
        {
            moveVec.y = 0f;
        }

        rigid.velocity = moveVec * Speed;

        // Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
            scanObject = rayHit.collider.gameObject;
        else
            scanObject = null;
    }

    public void CharacterKilled()
    {
        anim.SetTrigger("isDead");
        GameObject.FindObjectOfType<PlayerMove5>().isDead = true;  // 캐릭터 사망 상태 설정
        StartCoroutine(LoadSceneAfterDelay("Ending 1", 5f));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    void ResetAttackReady()
    {
        isAttackReady = false; // 공격 가능 상태를 false로 설정
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("PerfectFood"))
    //    {
    //        if (isAttackReady) // 공격 가능 상태가 true일 때
    //        {
    //            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    //        }
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PerfectFood"))
        {
            if (isAttackReady) // 공격 가능 상태가 true일 때
            {
                Debug.Log("비대칭 커팅 완료");
                scoreUpSound.Play();
                ScoreCounter5.Instance.Score += 5;

                string objectName = other.gameObject.name;

                // 충돌한 오브젝트 비활성
                other.gameObject.SetActive(false);

                //// 폭발 게임 오브젝트를 생성, 스프라이트 설정
                //GameObject explosion = Instantiate(explosionPrefab, other.gameObject.transform.position, Quaternion.identity);
                //Sprite[] sprites = explosionSprites[objectName];
                //explosion.GetComponent<SpriteRenderer>().sprite = sprites[0];
                //explosion.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[1];

                //// 기존 객체처럼 화면 밖으로 떨어지도록 Rigidbody2D 속도 변경
                //Rigidbody2D explosionRigidbody = explosion.GetComponent<Rigidbody2D>();
                //explosionRigidbody.gravityScale = 1f;
                //explosionRigidbody.velocity = new Vector2(Random.Range(-2f, 2f), -5f);

                //explosion.transform.localScale = new Vector3(0.5f, 0.5f, 1f);

                if (explosionSprites.ContainsKey(objectName)) // 사전에 키가 있는지 확인
                {
                    //GameObject explosion = Instantiate(explosionPrefab, other.gameObject.transform.position, Quaternion.identity);
                    GameObject explosion = Instantiate(explosionPrefab, other.gameObject.transform.position, Quaternion.Euler(0, 0, 90));
                    explosion.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    Sprite[] sprites = explosionSprites[objectName];

                    // 첫 번째 스프라이트
                    GameObject sprite1 = new GameObject("Sprite1");
                    sprite1.transform.position = explosion.transform.position;
                    sprite1.AddComponent<SpriteRenderer>().sprite = sprites[0];
                    Rigidbody2D sprite1Rigidbody = sprite1.AddComponent<Rigidbody2D>();
                    sprite1Rigidbody.gravityScale = 1f;
                    sprite1Rigidbody.velocity = new Vector2(Random.Range(-2f, 0f), 5f); // 위로 솟아오르는 속도
                    sprite1Rigidbody.angularVelocity = Random.Range(-360f, 360f); // 회전 속도
                    sprite1.transform.localScale = new Vector3(0.3f, 0.3f, 1f); // 조각 크기

                    // 두 번째 스프라이트
                    GameObject sprite2 = new GameObject("Sprite2");
                    sprite2.transform.position = explosion.transform.position;
                    sprite2.AddComponent<SpriteRenderer>().sprite = sprites[1];
                    Rigidbody2D sprite2Rigidbody = sprite2.AddComponent<Rigidbody2D>();
                    sprite2Rigidbody.gravityScale = 1f;
                    sprite2Rigidbody.velocity = new Vector2(Random.Range(0f, 2f), 5f);
                    sprite2Rigidbody.angularVelocity = Random.Range(-360f, 360f);
                    sprite2.transform.localScale = new Vector3(0.3f, 0.3f, 1f);

                    // 폭발 게임 오브젝트 삭제
                    Destroy(explosion, 0.5f); // 폭발 후 0.5초 뒤 삭제
                }
            }
        }
    }
}