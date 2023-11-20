using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAnim1 : MonoBehaviour
{
    private Animator animator;
    public float damage;
    private string[] attacks = { "skill_1", "skill_2", "skill_3", "evade_1", "jump"};
    float timer;
    float attackInterval = 5.0f;
    private Follow1 followScript;
    public GameObject[] bulletPrefabs;
    public float bulletSpeed = 30f;
    Player1 player1;
    float[] angles = { 0f, 15f, 45f, 75f, 90f, 105f, 135f, 165f, 180f, 195f, 225f, 255f, 270f, 285f, 315f, 345f};

    


    void Start()
    {
        animator = this.GetComponent<Animator> ();
        followScript = GetComponent<Follow1>();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("BossAttack"), LayerMask.NameToLayer("BossAttack"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("BossAttack"), LayerMask.NameToLayer("Enemy"), true);

    }

    // Update is called once per frame
    void Update()
    {
       timer += Time.deltaTime;
        // level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 100f), spawnData.Length - 1);
        if (timer >= attackInterval)
        {
            int randomAttackIndex = Random.Range(0, attacks.Length);

            // followScript.moveSpeed = 8;
            Attack(randomAttackIndex);
            // followScript.moveSpeed = 17;
            timer = 0;
        }
        // if (this.health < maxhealth){} 
    }
    IEnumerator AttackCoroutine(int randomAttackIndex)
    {
        // 공격하기 전에 속도 감소
        followScript.moveSpeed = 8;
        if (attacks[randomAttackIndex] == "evade_1")
        {
            yield return new WaitForSeconds(1.0f);
            for (int i = 0; i < 2; i++)
            {
                animator.SetTrigger($"{attacks[randomAttackIndex]}");

                Vector3 playerPos = GameManager1.instance.player.transform.position;        
                float xDirection = playerPos.x - transform.position.x;
                Vector2 dir = new Vector2(xDirection, 0f).normalized;

                GameObject bullet = Instantiate(bulletPrefabs[1], transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.Euler(0f, 0f, 270f));
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.velocity = dir * bulletSpeed;

                yield return new WaitForSeconds(0.5f);
            }


        }
        if (attacks[randomAttackIndex] == "jump")
        {
            yield return new WaitForSeconds(1.0f);
            animator.SetTrigger($"{attacks[randomAttackIndex]}");
            Vector3 playerPos = GameManager1.instance.player.transform.position;        
            float xDirection = playerPos.x - transform.position.x;
            Vector2 dir = new Vector2(xDirection, 0f).normalized;

            GameObject bullet = Instantiate(bulletPrefabs[1], transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.Euler(0f, 0f, 270f));
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = dir * bulletSpeed;
        
        }
        if (attacks[randomAttackIndex] == "skill_3")
        {
            yield return new WaitForSeconds(1.0f);
            animator.SetTrigger($"{attacks[randomAttackIndex]}");
            foreach (float angle in angles)
            {
                // 각도를 라디안으로 변환
                float radianAngle = Mathf.Deg2Rad * angle;

                // 각도에 따른 방향 계산
                Vector2 dir = new Vector2(Mathf.Cos(radianAngle), Mathf.Sin(radianAngle));

                // 총알 생성 및 발사
                GameObject bullet = Instantiate(bulletPrefabs[0], transform.position, Quaternion.identity);
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.velocity = dir * bulletSpeed;
            }
        
        }
        else
        {
            yield return new WaitForSeconds(1.0f);
            animator.SetTrigger($"{attacks[randomAttackIndex]}");
            Vector3 playerPos = GameManager1.instance.player.transform.position;        
            Vector3 dirVec = playerPos - transform.position;
            Vector2 dir = (dirVec).normalized;
            GameObject bullet = Instantiate(bulletPrefabs[0], transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = dir * bulletSpeed;
        }
        // animator.SetTrigger($"{attacks[randomAttackIndex]}");
        followScript.moveSpeed = 17;
    }
    
    void Attack(int randomAttackIndex)
    {
        // int randomAttackIndex = Random.Range(0, attacks.Length);
        if (attacks[randomAttackIndex] == "skill_1")
        {
            StartCoroutine(AttackCoroutine(randomAttackIndex));


            // animator.SetTrigger("skill_1");
        }
        if (attacks[randomAttackIndex] == "jump")
        {
            StartCoroutine(AttackCoroutine(randomAttackIndex));
            // StartCoroutine(Skill1());
            // animator.SetTrigger("jump_up");
            // animator.SetTrigger("skill_3");
            // animator.SetTrigger("jump_down");
        }
        if (attacks[randomAttackIndex] == "skill_2")
        {
            StartCoroutine(AttackCoroutine(randomAttackIndex));

            // StartCoroutine(Skill2());
            // animator.SetTrigger("skill_2");
        }
        if (attacks[randomAttackIndex] == "skill_3")
        {
            StartCoroutine(AttackCoroutine(randomAttackIndex));

            // StartCoroutine(Skill3());
            // animator.SetTrigger("skill_3");
        }
        if (attacks[randomAttackIndex] == "evade_1")
        {
            StartCoroutine(AttackCoroutine(randomAttackIndex));
            // StartCoroutine(Evade1());
            // animator.SetTrigger("evade_1");
        }
    
    }

    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (!collision.CompareTag("Area"))
    //         return;

    //     gameObject.SetActive(false);
    // }

}
