using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire3 : MonoBehaviour
{
    private Vector3 initialVector;
    public int dir;

    void Awake()
    {
        initialVector = transform.position;
    }

    void Update()
    {
        if (!GameManager3.isLive)
            return;

        float totalSpeed = GameManager3.globalSpeed * 3 * Time.deltaTime * -1f;
        switch (dir)
        {
            case 0:
                transform.Translate(totalSpeed, 0, 0);
                break;
            case 1:
                transform.Translate(totalSpeed, -totalSpeed/2, 0);
                break;
            case 2:
                transform.Translate(totalSpeed, -totalSpeed, 0);
                break;
            case 3:
                transform.Translate(totalSpeed, -totalSpeed * 2, 0);
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Border")
        {
            transform.position = initialVector;
            gameObject.SetActive(false);
        }    
    }

    public void FireTouch()
    {
        transform.position = initialVector;
        gameObject.SetActive(false);
    }
}
