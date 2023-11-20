using System.Collections;
using UnityEngine;

public class Dust1 : MonoBehaviour
{
    private Transform enemyTransform;
    private Vector3 initialPosition;
    public float moveDistance = 0.3f;
    public float moveSpeed = 1.0f;
    public float startDelay = 3f;


    // IEnumerator ActivateDust()
    // {
    //     yield return new WaitForSeconds(startDelay);
    // }

    void Start()
    {
        // StartCoroutine(ActivateDust());

        GameObject enemy = GameObject.Find("enemy");
        if (enemy != null)
        {
            enemyTransform = enemy.transform;
        }

        // Dust의 초기 위치를 저장
        initialPosition = transform.position;
    }


    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (!collision.CompareTag("Start"))
    //         return;

    //     gameObject.SetActive(true);
    // }
    void Update()
    {
        if (enemyTransform != null)
        {
            // 위아래로 움직이는 값을 계산
            float offsetY = Mathf.PingPong(Time.time * moveSpeed, moveDistance);

            // Dust의 위치를 업데이트
            Vector3 newPosition = initialPosition + Vector3.up * offsetY;
            transform.position = newPosition;

            // Dust를 enemyTransform에 따라 이동
            transform.position = new Vector3(enemyTransform.position.x, transform.position.y, transform.position.z);
        }
    }
}
