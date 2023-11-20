using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result1 : MonoBehaviour
{
    public GameObject[] titles;
    public void Lose()
    {
        titles[0].SetActive(true);
        titles[1].SetActive(false);
    }
    public void Win()
    {
        titles[0].SetActive(false);
        titles[1].SetActive(true);
    }

}
