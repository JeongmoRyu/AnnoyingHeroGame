using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Barrier1 : MonoBehaviour

{
    Player1 player;

    // // Start is called before the first frame update
    void Awake()
    {
        player = GetComponentInParent<Player1>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Shield();
    }

    void Shield()
    {
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.gameObject.SetActive(true);
            // transform.GetChild(0).gameObject.SetActive(true);
            // player.CapsuleCollider2D = false;
            // Unbeatable();
            // Invoke("Unbeatable", 3);
        }
        else 
            transform.gameObject.SetActive(true);
        {
            transform.GetChild(0).gameObject.SetActive(false);
            // CapsuleCollider2D  = true;
        }
    }

}
