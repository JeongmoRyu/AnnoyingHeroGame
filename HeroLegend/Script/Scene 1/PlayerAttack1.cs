using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack1 : MonoBehaviour
{
    public GameObject noise;
    public Transform pos;
    public float cooltime;
    private float curtime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curtime <= 0)
        {

            if (Input.GetKey(KeyCode.LeftControl))
            {
                Instantiate(noise, pos.position, transform.rotation);
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
        
    }
}
