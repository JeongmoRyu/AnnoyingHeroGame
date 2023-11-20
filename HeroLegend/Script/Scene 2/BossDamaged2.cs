using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamaged2 : MonoBehaviour
{
    public GameManager2 gameManager;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "PlayerSkill" || LayerMask.LayerToName(collision.gameObject.layer) == "Item")
        {
            // SFX
            AudioManager2.instance.PlaySfx(AudioManager2.Sfx.BossShield);

            SkillRemove2 skillRemove = collision.gameObject.GetComponent<SkillRemove2>();
            skillRemove.DeActive();
        } else if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity != Vector2.zero)
            {
                // SFX
                AudioManager2.instance.PlaySfx(AudioManager2.Sfx.BossHit);

                collision.gameObject.GetComponent<SkillRemove2>().Active();
                anim.SetTrigger("hit");
                gameManager.BossHealthDown();
            }
            else
            {
                collision.gameObject.GetComponent<SkillRemove2>().DeActive();
            }
        }
    }
}
