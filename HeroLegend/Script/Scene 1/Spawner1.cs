using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{

    // void Update()
    // {
    //     if (Input.GetKey(KeyCode.J))
    //     {
    //         Debug.Log(GameManager.instance.pool.Get(2));
    //         GameManager.instance.pool.Get(0);
    //     }    
    // }
    Player1 player;
    public Rigidbody2D rigid;
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;
    // public RectTransform rect;
    // int level;
    float timer;
    float spawnInterval = 3.0f;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    void Update()
    {
        // if (!GameManager.instance.isLive)
        //     return;
        timer += Time.deltaTime;
        // level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 100f), spawnData.Length - 1);
        if (timer >= spawnInterval)
        {
            // if (player.dir_plus)
            // {
            //     Vector3 newPosition = new Vector3(20, rect.position.y, rect.position.z);
            //     rect.position = newPosition;
            // }
            // else
            // {
            //     Vector3 newPosition = new Vector3(-20, rect.position.y, rect.position.z);
            //     rect.position = newPosition;
            // }
            
            timer = 0;
            Spawn();
        }
    }
    void Spawn() 
    {
        GameObject itembox = GameManager1.instance.pool.Get(2);
        // Debug.Log(spawnPoint.position);
        itembox.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;       
    
        itembox.GetComponent<ItemBox1>().Init(spawnData[0]);
    }
}

[System.Serializable]
public class SpawnData
{
    public int spriteType;
    public float spawnTime;
    public int health;
}
