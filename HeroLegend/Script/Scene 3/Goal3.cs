using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal3 : MonoBehaviour
{
    public GameObject uiStatusBar;
    private RectTransform rectTran;
    private int initX;

    void Start()
    {
        rectTran = uiStatusBar.gameObject.GetComponent<RectTransform>();
        initX = (int)transform.position.x;
    }

    void Update()
    {
        rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (initX - transform.position.x)/initX * 100);
    }
}
