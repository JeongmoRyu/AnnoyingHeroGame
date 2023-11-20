using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossMove2 : MonoBehaviour
{
    public GameManager2 gameManager;
    public bool isStopped = false;
    public bool StartComplete = false;

    public GameObject Fireball;
    public GameObject aura;
    public GameObject aura2;
    public GameObject MiniDragon;

    Animator anim;
    Rigidbody2D rb;
    SpriteRenderer sr;
    CapsuleCollider2D capCol;

    Queue<string> queue;
    List<string> list;
    List<float[]> locationList;

    float endPosition;
    public float liftAmount = 1.0f;  // 오브젝트가 올라갈 총 높이
    public float liftDuration = 1.0f;  // 올라가는 데 걸리는 총 시간
    float launchSpeed; // 스킬 나가는 속도
    float waitTime; // Stay 유지 시간
    float forceLevel; // 이동할때 가할 힘
    float range; // 파이어볼 각도

    void Start()
    {
        // SFX
        AudioManager2.instance.PlaySfx(AudioManager2.Sfx.EnemyAppear);

        CreateAura(aura, 0.7f);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        capCol = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Lift");
        StartCoroutine(Lift());

        // 명령어 리스트 초기화 
        list = new List<string>();
        list.Add("Fly");
        list.Add("Spit");
        list.Add("Teleport");
        list.Add("Spit");
        list.Add("Summons");


        // 명령 큐 초기화
        queue = new Queue<string>();
        for (int i = 0; i < list.Count; i++)
        {
            queue.Enqueue(list[i]);
            queue.Enqueue("Stay");
        }

        // 소환할 미니드래곤 위치 리스트 초기화
        locationList = new List<float[]> {
            new float[] { -0.5f, 0.7f },
            new float[] { 5f, -3.3f },
            new float[] { -2.4f, -1.3f }
        };
    }

    void Update()
    {
        // 공격, 이동, 대기 속도 설정 
        if (gameManager.bossHealth > 9)
        {
            range = 5;
            waitTime = 1.5f;
            launchSpeed = 2.0f;
            forceLevel = 2000;
        } else if (gameManager.bossHealth > 6)
        {
            range = 7;
            sr.color = new Color(255, 100, 0, 255);
            waitTime = 1;
            launchSpeed = 5.0f;
            forceLevel = 4000;
        } else
        {
            range = 9;
            sr.color = new Color(255, 0, 0, 255);
            waitTime = 0.5f;
            launchSpeed = 7.0f;
            forceLevel = 6000;
        }

        if (!anim.GetBool("isDead") && StartComplete && anim.GetBool("isLifted") && !isStopped)
        {
            if (!anim.GetBool("isFlying") && anim.GetBool("isLifted"))
            {
                // 큐에서 다음 패턴 꺼내 사용 
                string pattern = queue.Dequeue();
                if (pattern.Equals("Fly"))
                {
                    Fly();
                    
                } else if (pattern.Equals("Teleport"))
                {
                    anim.SetTrigger("Teleport");
                    Invoke("Teleport", 0.5f);
                } else if (pattern.Equals("Stay"))
                {
                    StartCoroutine(Stay());
                } else if (pattern.Equals("Spit"))
                {
                    Spit();
                } else if (pattern.Equals("Summons"))
                {
                    Summons();
                }
                if (!pattern.Equals("Stay")) queue.Enqueue(pattern); // 다시 큐에 넣음 
                queue.Enqueue("Stay");

            }
            else if (anim.GetBool("isFlying")) // 이동 중
            {
                if (endPosition < 0)
                {
                    if (transform.position.x <= endPosition)
                    {
                        rb.velocity = Vector2.zero;
                        anim.SetBool("isFlying", false);
                        turn();
                    }
                }
                else
                {
                    if (transform.position.x >= endPosition)
                    {
                        rb.velocity = Vector2.zero;
                        anim.SetBool("isFlying", false);
                        turn();
                    }
                }
            }
        }
    }

    // 파이어볼 
    void Spit()
    {
        anim.SetTrigger("Spit");
        Invoke("CreateProjectile", 1f);
    }

    // 발사체 생성
    void CreateProjectile()
    {
        float angleStep = 120 / range; // 각도 간격

        for (int i = 1; i < 10; i++)
        {
            // 프로젝타일의 시작 위치를 플레이어 앞으로 조금 옮김
            Vector3 startPosition;
            GameObject projectile;
            Rigidbody2D rb;
            float angle;
            float angleDegrees;
            Vector2 direction;

            // 프로젝타일 발사
            if (sr.flipX) // 왼쪽
            {
                angleDegrees = -120f - (angleStep * i);
                angle = Mathf.Deg2Rad * (angleDegrees); // 각도를 라디안으로 변환

                startPosition = transform.position - transform.right * 1.7f + transform.up * 0.8f;
                Quaternion rotation = Quaternion.Euler(0f, 0f, angleDegrees);
                projectile = Instantiate(Fireball, startPosition, rotation);

                rb = projectile.GetComponent<Rigidbody2D>();
                direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)); // 방향 벡터 계산
                
            }
            else // 오른쪽
            {
                angleDegrees = -60f + (angleStep * i);
                angle = Mathf.Deg2Rad * (angleDegrees); // 각도를 라디안으로 변환

                startPosition = transform.position + transform.right * 1.7f + transform.up * 0.8f;
                Quaternion rotation = Quaternion.Euler(0f, 0f, angleDegrees);
                projectile = Instantiate(Fireball, startPosition, rotation);

                rb = projectile.GetComponent<Rigidbody2D>();
                direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)); // 방향 벡터 계산
                
            }
            rb.AddForce(direction * launchSpeed, ForceMode2D.Impulse);

            // SFX
            AudioManager2.instance.PlaySfx(AudioManager2.Sfx.BossAttack);
        }
    }

    // 드래곤 이동 
    void Fly()
    {

        anim.SetBool("isFlying", true);
        endPosition = transform.position.x > 0 ? -6 : 6;
        Vector2 force;
        if (transform.position.x > 0)
        {
            force = -transform.right * forceLevel;
        } else
        {
            force = transform.right * forceLevel;
        }
       
        rb.AddForce(force, ForceMode2D.Impulse);
    }

    
    // 드래곤 순간이동 
    void Teleport()
    {
        // SFX
        AudioManager2.instance.PlaySfx(AudioManager2.Sfx.BossTeleport);

        transform.position = new Vector3(-transform.position.x, -transform.position.y, 0);
        turn();
    }

    IEnumerator Stay()
    {
        isStopped = true;
        yield return new WaitForSeconds(waitTime);
        isStopped = false;
    }

    // 드래곤 스프라이트 뒤집기 
    void turn()
    {
        if (sr.flipX)
        {
            sr.flipX = false;
        } else
        {
            sr.flipX = true;
        }
    }

    // 드래곤 사망 
    public void OnDie()
    {
        isStopped = true;
        rb.velocity = Vector3.zero;
        anim.SetBool("isDead", true);
        capCol.isTrigger = false;
        rb.gravityScale = 1;
    }

    void Up()
    {
        anim.SetBool("isLifted", true);
    }

    IEnumerator Lift()
    {
        // 애니메이션을 재생
        Invoke("Up", 0.2f);

        // 1초 대기
        yield return new WaitForSeconds(1f);

        // 오브젝트 이동
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + new Vector3(0, liftAmount, 0);

        float elapsedTime = 0;
        while (elapsedTime < liftDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / liftDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 마지막으로 정확한 위치를 설정
        transform.position = targetPosition;
        yield return new WaitForSeconds(1f);
        StartComplete = true;

    }

    // 미니 드래곤 소환 
    void Summons()
    {
        // SFX
        AudioManager2.instance.PlaySfx(AudioManager2.Sfx.EnemyAppear);

        CreateAura(aura, 0.7f);
        CreateAura(aura2, 1.3f);
        foreach (float[] location in locationList)
        {
            Vector3 loc = new Vector3(location[0], location[1]);
            Instantiate(MiniDragon, loc, transform.rotation);
        }
    }

    IEnumerator FadeOutSprite(GameObject objectToFade)
    {
        SpriteRenderer spriteRenderer = objectToFade.GetComponent<SpriteRenderer>();
        Color fadeColor = spriteRenderer.color;

        // 1초 동안 서서히 사라지게 함
        for (float i = 2; i >= 0; i -= Time.deltaTime)
        {
            // 새 알파 값 설정
            fadeColor.a = i;
            spriteRenderer.color = fadeColor;
            yield return null;
        }

        Destroy(objectToFade);
    }

    // 아우라 생성 및 사라지게 하는 함수
    void CreateAura(GameObject Aura, float location)
    {
        GameObject aura1 = Instantiate(Aura, transform.position + Vector3.up * location, transform.rotation);
        StartCoroutine(FadeOutSprite(aura1));
    }
}
