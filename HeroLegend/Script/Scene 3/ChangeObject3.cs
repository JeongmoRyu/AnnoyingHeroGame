using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObject3 : MonoBehaviour
{
    public GameObject[] objects;

    public void Change()
    {
        int ran = Random.Range(0, objects.Length);

        for (int index = 0; index < objects.Length; index++)
        {
            transform.GetChild(index).gameObject.SetActive(ran == index);
        }
    }
}
