using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDamaged2 : MonoBehaviour
{
    public GameManager2 gameManager;
    SpriteRenderer spriteRenderer;
    Animator anim;
    Rigidbody2D rigid;
    bool isStunned;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Transform playerTransform = this.transform;
        anim = playerTransform.Find("UnitRoot").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            // enemy skill 피격 효과
            if (collision.gameObject.CompareTag("EnemySkill")) collision.gameObject.GetComponent<FireballRemove2>().Hit();

            if (!isStunned) OnDamaged(collision.transform.position); // 무적 상태 아닐시 피격 
        }
    }

    public void OnDie()
    {
        anim.SetBool("isDead", true);
    }
    public void OnDamaged(Vector2 targetPos)
    {
        // 피격 SFX
        AudioManager2.instance.PlaySfx(AudioManager2.Sfx.Hit);

        // 체력 감소
        gameManager.HealthDown();

        // 피격 후 빨간색 
        ChangeColor(new Color(1, 0, 0, 1));

        // 무적
        isStunned = true;

        // 피격 시 반동
        int dirc = ((transform.position.x - targetPos.x) > 0) ? 1 : -1;
        rigid.AddForce(new Vector2(dirc, 1) * 7, ForceMode2D.Impulse);

        // 2초후 무적 및 피격 상태 해제 
        Invoke("OffDamaged", 2);
    }


    public void OffDamaged()
    {
        gameObject.layer = 0;
        ChangeColor(new Color(1, 1, 1, 1));
        isStunned = false;
    }

    void ChangeColor(Color newColor)
    {
        // 모든 SpriteRenderer 컴포넌트 찾기
        SpriteRenderer[] children = GetComponentsInChildren<SpriteRenderer>(); 
        foreach (SpriteRenderer sr in children)
        {
            sr.color = newColor; // 각 SpriteRenderer 색상 변경
        }
    }
}
