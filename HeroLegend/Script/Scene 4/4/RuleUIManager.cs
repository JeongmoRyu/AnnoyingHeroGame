using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleUIManager : MonoBehaviour
{
    GameObject ruleUI;

    private void Awake()
    {
        ruleUI = transform.GetChild(0).gameObject;
    }

    public void ActivateRuleUI()
    {
        ruleUI.SetActive(true);
    }

    public void DeactivateRuleUI()
    {
        ruleUI.SetActive(false);
    }
}
