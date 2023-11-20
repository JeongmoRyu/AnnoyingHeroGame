using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragonMove2 : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    CapsuleCollider2D capsuleCollider;
    public GameObject chicken;
    public GameObject food;
    public GameObject fireBall;
    public GameObject aura;
    public GameManager2 gameManager;

    public int nextMove; // 다음 속도 
    public int launchSpeed; // 파이어볼 발사 속도 
    int fired; // 불 맞은 횟수
    int oiled; // 기름 맞은 횟수 
    bool dead;

    // Start is called before the first frame update
    void Awake()
    {
        CreateAura();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        fired = 0;
        oiled = 0;

        // 게임 매니저 찾기
        if (gameManager == null)
        {
            // Find the GameManager in the scene and assign it
            gameManager = FindObjectOfType<GameManager2>();
            if (gameManager == null)
            {
                Debug.LogError("GameManager not found in the scene.");
            }
        }

        Invoke("Think", 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dead)
        {
            // Move
            rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

            // Platform check
            Vector2 vec = new Vector2(rigid.position.x + rigid.velocity.normalized.x / 2, rigid.position.y - 0.5f);
            Vector2 direction = spriteRenderer.flipX ? Vector2.right : Vector2.left; // 캐릭터가 왼쪽을 바라보면 왼쪽으로, 오른쪽을 바라보면 오른쪽으로 레이캐스트
            RaycastHit2D rayhitForward = Physics2D.Raycast(vec, direction, 1, LayerMask.GetMask("PlatForm"));
            Debug.DrawLine(vec, vec + direction * 1, Color.red);

            if (rayhitForward.collider != null)
            {
                Turn();
            }

            if (rigid.velocity.normalized.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else if (rigid.velocity.normalized.x > 0)
            {
                spriteRenderer.flipX = false;
            }
        }
    }
    void CreateProjectile()
    {
        int v = (spriteRenderer.flipX) ? -1 : 1;

        // 프로젝타일의 시작 위치를 플레이어 앞으로 조금 옮김
        Vector3 startPosition = transform.position + v * transform.right * 0.7f + transform.up * 0.1f;

        // 프리페브로부터 새로운 프로젝타일 오브젝트 생성
        GameObject projectile = Instantiate(fireBall, startPosition, Quaternion.Euler(0, v == 1 ? 0 : 180, 0));

        // 프로젝타일로부터 리지드바디 2D 컴포넌트 가져옴
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // 프로젝타일 발사
        rb.AddForce(v * transform.right * launchSpeed, ForceMode2D.Impulse);

    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);
        // sorite animation
        if (nextMove == 0)
        {
            anim.SetBool("isFlying", false);
            StartCoroutine(ShootFireBall());
        } else
        {
            anim.SetBool("isFlying", true);
        }
        

        // 방향에 따라 뒤집기
        if (nextMove != 0)
        {
            spriteRenderer.flipX = nextMove < 0;
        }

        // 재귀
        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);
    }
    void Turn()
    {
        nextMove *= -1;
        spriteRenderer.flipX = nextMove == 1;

        CancelInvoke();
        Invoke("Think", 2);
    }

    void DeActive()
    {
        // 오브젝트 비활성화 및 삭제
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void OnDamaged(Color color)
    {
        // 오브젝트 색변경
        spriteRenderer.color = color;

        // 드래곤 사망 
        if (fired >= 2 || (oiled >= 1 && fired >= 1))
        {
            
            if (fired >= 1 && oiled >= 1)
            {
                TurnChicken();
            }
            else if (fired >= 2)
            {
                OnDie();
                Instantiate(food, transform.position - transform.up * 0.3f, transform.rotation);
            }
        }
    }

    void OnDie()
    {
        dead = true;
        anim.SetBool("isDead", true);
        capsuleCollider.enabled = false;
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
        rigid.gravityScale = 1;
        Invoke("DeActive", 2);
        if(gameManager.stageIndex < gameManager.Stages.Length - 1) gameManager.EnemyCountDown();
    }

    void TurnChicken()
    {
        dead = true;
        Instantiate(chicken, transform.position - transform.up * 0.3f, transform.rotation);
        DeActive();
        gameManager.EnemyCountDown();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "PlayerSkill")
        {
            if (collision.gameObject.CompareTag("PlayerSkillFire"))
            {
                // SFX
                AudioManager2.instance.PlaySfx(AudioManager2.Sfx.EnemyHit);

                fired++;
                OnDamaged(new Color(255, 0, 0, 255));
            }
            else if (collision.gameObject.CompareTag("PlayerSkillOil"))
            {
                oiled++;
                OnDamaged(new Color(255, 255, 0, 255));
            }
            SkillRemove2 skillRemove = collision.gameObject.GetComponent<SkillRemove2>();
            skillRemove.Active();
        } else if (LayerMask.LayerToName(collision.gameObject.layer) == "PlayerAttack" && collision.gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
        {
            // SFX
            AudioManager2.instance.PlaySfx(AudioManager2.Sfx.BossHit);

            OnDie();
            collision.gameObject.GetComponent<SkillRemove2>().Active();
        }
        
    }

    IEnumerator ShootFireBall()
    {
        yield return new WaitForSeconds(1);
        // SFX
        AudioManager2.instance.PlaySfx(AudioManager2.Sfx.EnemyAttack);

        anim.SetTrigger("isAttacking");
        Invoke("CreateProjectile", 0.8f);
        yield return new WaitForSeconds(1);         
    }

    // 아우라 생성 및 사라지게 하는 함수
    void CreateAura()
    {
        GameObject aura1 = Instantiate(aura, transform.position + Vector3.down * 0.2f, transform.rotation);
        Destroy(aura1);
    }
}
