using UnityEngine;

public class RandomDropEvent5 : MonoBehaviour
{
    public ObjectPooler5 pizzaPooler;
    public ObjectPooler5 donut1Pooler;
    public ObjectPooler5 donut2Pooler;
    public ObjectPooler5 donut3Pooler;
    public ObjectPooler5 watermelonPooler;

    //public float spawnRate = 1f; // 초당 스폰률
    public float spawnRate; // 초당 스폰률
    public FallingObject5 fallingObject;
    public GameManager5 gameManager; // GameManager5 인스턴스

    private float timer = 0; // 타이머

    //void Start()
    //{
    //    InvokeRepeating("Spawn", 0, spawnRate);
    //}

    void Update()
    {
        // GameManager5의 isDialogueEnded가 true일 경우에만 작동
        if (gameManager.isDialogueEnded)
        {
            timer += Time.deltaTime; // 타이머 업데이트

            // 타이머가 spawnRate보다 크거나 같으면 Spawn 메서드 호출
            if (timer >= spawnRate)
            {
                Spawn();
                timer = 0; // 타이머 초기화
            }
        }
    }

    void Spawn()
    {
        // 랜덤한 위치에 객체 생성
        float spawnPointX = Random.Range(-7f, 7f); // 좌우 범위
        Vector2 spawnPos = new Vector2(spawnPointX, 7); // 객체 생성 높이

        // 랜덤한 객체 선택.
        int rand = Random.Range(0, 4);
        GameObject spawnedObject = null;
        switch (rand)
        {
            case 0:
                spawnedObject = pizzaPooler.GetPooledObject();
                break;
            case 1:
                spawnedObject = donut1Pooler.GetPooledObject();
                break;
            case 2:
                spawnedObject = donut2Pooler.GetPooledObject();
                break;
            case 3:
                spawnedObject = donut3Pooler.GetPooledObject();
                break;
            case 4:
                spawnedObject = watermelonPooler.GetPooledObject();
                break;
        }

        if (spawnedObject != null)
        {
            // 객체 활성화 --> 필요한 위치로 이동
            spawnedObject.transform.position = spawnPos;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);

            // FallingObject5 스크립트의 speed 값 변경
            var fallingObject = spawnedObject.GetComponent<FallingObject5>();
            if (fallingObject != null)
            {
                fallingObject.speed = new Vector2(0, -2);  // 원하는 속도로 변경
            }
        }
    }
}
