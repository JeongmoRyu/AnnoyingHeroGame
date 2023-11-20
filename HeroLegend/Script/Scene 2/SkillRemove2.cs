using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRemove2 : MonoBehaviour
{
    private Rigidbody2D rb; // 스킬의 Rigidbody2D 컴포넌트
    public GameObject effect;
    public GameObject deActiveEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector3.zero;
            Hit(deActiveEffect);
        } 
    }

    // 스킬 맞췄을 때
    public void Hit(GameObject e)
    {
        Remove();
        GameObject Effect = Instantiate(e, transform.position, transform.rotation);
    }

    // 보스는 스킬 무효화
    public void DeActive()
    {
        Hit(deActiveEffect);
    }

    // 스킬 맞았을 때
    public void Active()
    {
        Hit(effect);
    }

    public void Remove()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
