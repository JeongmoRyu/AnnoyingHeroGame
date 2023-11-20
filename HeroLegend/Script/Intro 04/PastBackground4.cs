using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastBackground4 : MonoBehaviour
{
    Animator pastBackgroundAnim;
    public PlayerMovement4 player;

    public GameObject resultDelieverObject2;
    public GameObject mapObject;

    private void Awake()
    {
        pastBackgroundAnim = GetComponent<Animator>();
    }

    public void PastBackgroun4FadeIn()
    {
        pastBackgroundAnim.SetTrigger("FadeIn");
    }

    public void PastBackgroun4FadeOut()
    {
        pastBackgroundAnim.SetTrigger("FadeOut");
    }

    public void ActivateResultDelieverObject2()
    {
        player.ScanNorth();
        resultDelieverObject2.SetActive(true);
    }

    public void DeactivateResultDelieverObject2()
    {
        resultDelieverObject2.SetActive(false);
    }

    public void ActivateMapUI()
    {
        mapObject.SetActive(true);
    }

    public void DeactivateMapUI()
    {
        mapObject.SetActive(false);
    }
}
