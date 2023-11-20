using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEat1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("ItemEat"), true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("speakereat") || collision.CompareTag("bulleteat") || collision.CompareTag("boomeat") || collision.CompareTag("hearteat"))
        {

            collision.gameObject.SetActive(false);
            HandleItemCollection(collision.tag);
        }
    }

    void HandleItemCollection(string tag)
    {       
        switch (tag)
        {
            case "speakereat":
                GameManager1.instance.player.GetComponent<Player1>().transform.GetChild(1).gameObject.SetActive(true);
                // "speakereat" 아이템에 대한 처리
                break;
            case "bulleteat":
                // GameManager1.instance.player.GetComponent<Player1>().transform.damage += 1;
                // GameManager1.instance.player.GetComponent<Player1>().GetComponent<Noise1>.damage;
                // Noise1.characterdamage += 1;
                GameManager1.instance.characterdamage += 1;
                break;
            case "boomeat":
                break;
            case "hearteat":
                Debug.Log("20% up");
                if (GameManager1.instance.health < GameManager1.instance.maxHealth - 20)
                {
                    GameManager1.instance.health += 20;
                }
                break;
            // 추가적인 태그에 대한 처리를 필요에 따라 추가
        }
    }


}
