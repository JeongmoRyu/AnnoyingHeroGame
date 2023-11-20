using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedItem1 : MonoBehaviour
{
    public int id;
    public GameObject[] itemPrefabs;
    Player1 player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DropItem(Vector3 spawnPosition)
    {
        StartCoroutine(DropItemCoroutine(spawnPosition));
        int randomItemIndex = Random.Range(0, itemPrefabs.Length);
        GameObject spawnedItem = Instantiate(itemPrefabs[randomItemIndex], spawnPosition, Quaternion.identity);
    }

    IEnumerator DropItemCoroutine(Vector3 spawnPosition)
    {
        yield return new WaitForSeconds(0.5f);        
    }

    void Update()
    {
    
    }
    // void OnTriggerExit2D(Collider2D collision)
    // {
    //     if (!collision.CompareTag("Area"))
    //         return;

    //     Vector3 playerPos = GameManager1.instance.player.transform.position;
    //     switch (transform.tag) {
    //         case "ItemBox":
    //             if (playerPos.x < transform.position.x)
    //             {
    //                 gameObject.SetActive(false);
    //             }
    //             break;

    //     }
    // }

}
