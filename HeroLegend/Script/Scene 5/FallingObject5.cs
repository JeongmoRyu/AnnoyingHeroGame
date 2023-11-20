using System.Runtime.CompilerServices;
using UnityEngine;

public class FallingObject5 : MonoBehaviour
{
    public Vector2 speed;

    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        GetComponent<Rigidbody2D>().velocity = speed;
    }

    void Update()
    {
        // 화면 밖으로 벗어났는가?
        if (transform.position.y < -10)
        {
            // 화면 밖으로 벗어났다면, 오브젝트를 비활성화 --> 오브젝트 풀로 반환
            gameObject.SetActive(false);
        }
    }
}
