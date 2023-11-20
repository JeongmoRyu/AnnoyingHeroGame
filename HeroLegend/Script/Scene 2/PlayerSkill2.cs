using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSkill2 : MonoBehaviour
{
    // 스킬 프리펩
    public GameObject water; 
    public GameObject fire;
    public GameObject effect;
    public GameManager2 gameManager;

    Animator anim;

    public float launchSpeed = 10.0f; // 스킬 나가는 속도 
    public float delay = 0.5f;     // 연타 딜레이 시간 (초)

    private bool isCooldown = false;

    private void Start()
    {
        Transform playerTransform = this.transform;
        anim = playerTransform.Find("UnitRoot").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !isCooldown)
        {
            // SFX
            AudioManager2.instance.PlaySfx(AudioManager2.Sfx.PlayerSkill);

            CreateProjectile(fire);
            StartCoroutine(Cooldown()); // 연타 딜레이 시작
            
        } else if(Input.GetKeyDown(KeyCode.X) && !isCooldown) {
            // SFX
            AudioManager2.instance.PlaySfx(AudioManager2.Sfx.PlayerSkill);

            CreateProjectile(water);
            StartCoroutine(Cooldown()); // 연타 딜레이 시작
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerAttack"))
        {
            // SFX
            AudioManager2.instance.PlaySfx(AudioManager2.Sfx.PlayerAttack);

            Quaternion rotation = Quaternion.Euler(0, 0, 90);
            GameObject effect1 = Instantiate(effect, collision.gameObject.transform.position, rotation);
            StartCoroutine(DeleteEffect(effect1));
            Rigidbody2D objectRb = collision.gameObject.GetComponent<Rigidbody2D>();
            objectRb.AddForce(-transform.right * launchSpeed, ForceMode2D.Impulse);
        } else if (collision.gameObject.CompareTag("Item"))
        {
            // SFX
            AudioManager2.instance.PlaySfx(AudioManager2.Sfx.PlayerEat);

            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
            gameManager.HealthUp();
        }
    }

    IEnumerator DeleteEffect(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    void CreateProjectile(GameObject projectilePrefab)
    {
        anim.SetTrigger("Skill");
        // 프로젝타일의 시작 위치를 플레이어 앞으로 조금 옮김
        Vector3 startPosition = transform.position - transform.right * 0.7f + transform.up * 0.5f;

        // 프리페브로부터 새로운 프로젝타일 오브젝트 생성
        GameObject projectile = Instantiate(projectilePrefab, startPosition, transform.rotation);

        // 프로젝타일로부터 리지드바디 2D 컴포넌트 가져옴
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // 프로젝타일 발사
        rb.AddForce(-transform.right * launchSpeed, ForceMode2D.Impulse);
    }

    IEnumerator Cooldown()
    {
        isCooldown = true; // 연타 방지를 위해 쿨다운 활성화
        yield return new WaitForSeconds(delay); // 쿨다운 시간 동안 대기 (0.5초로 설정)
        isCooldown = false; // 쿨다운 비활성화
    }
}
