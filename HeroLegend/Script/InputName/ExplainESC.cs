using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ESC : MonoBehaviour
{
    /* UI 구성요소 */
    public GameObject ESCView;

    void Awake()
    {
        ESCView.SetActive(false);
    }

    
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            ESCView.SetActive(true);
        }
        else
        {
            ESCView.SetActive(false);
        }
    }


}
