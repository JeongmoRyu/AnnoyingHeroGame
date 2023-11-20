using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballRemove2 : MonoBehaviour
{
    private Rigidbody2D rb; // 스킬의 Rigidbody2D 컴포넌트
    public GameObject effect;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x <= -10 || transform.position.x > 10)
        {
            gameObject.SetActive(false); // 이 게임 오브젝트를 파괴
            Destroy(gameObject);
        }
    }

    // 스킬 맞췄을 때
    public void Hit()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("hit");
        Invoke("Remove", 1);
        
    }

    public void Remove()
    {

        gameObject.SetActive(false) ;
        Destroy(gameObject);
    }
}
