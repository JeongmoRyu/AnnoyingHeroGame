using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition1 : MonoBehaviour
{
    // void LateUpdate()
    // {
    //     if (transform.position.x > -15)
    //         return;
        
    //     transform.Translate(35, 0, 0, Space.Self);
    // }
    Collider2D coll;
    void Awake() 
    {
        coll = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager1.instance.player.transform.position;
        Vector3 myPos = transform.position;


        switch (transform.tag) {
            case "Ground":
                float diffX = playerPos.x - myPos.x;
                
                float dirX = diffX < 0 ? -1 : 1;
                diffX = Math.Abs(diffX);
                
                if (dirX == 1 && diffX > 20) {
                    transform.Translate(Vector3.right * dirX * 80);
                }
                if (dirX == -1 && diffX > 20) {
                    transform.Translate(Vector3.right * dirX * 80);

                }
                break;
            case "ItemBox":
                float boxdiffX = playerPos.x - myPos.x;
                
                float boxdirX = boxdiffX < 0 ? -1 : 1;
                boxdiffX = Math.Abs(boxdiffX);
                
                if (boxdirX == 1 && boxdiffX > 20) {
                    transform.Translate(Vector3.right * boxdirX * 80);
                }
                if (boxdirX == -1 && boxdiffX > 20) {
                    transform.Translate(Vector3.right * boxdirX * 80);

                }
                // ItemBox.health = maxHealth;
                // ItemBox.isLive = true;
                // SpawnData.item.setActive(false);
                break;

        }
    }
}