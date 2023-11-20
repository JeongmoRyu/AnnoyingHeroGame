using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera1 : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x + 2, target.position.y + 2, -10f);
    }
}
