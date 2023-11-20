using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD1 : MonoBehaviour
{
    public enum InfoType { BossHealth, Health }
    // public enum InfoType { BossHp, Time, Health }
    public InfoType type;
    Text myText;
    Slider mySlider;
    Slider bossSlider;
    void Awake()
    {
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type) {
            case InfoType.BossHealth:
                float curbossHp = GameManager1.instance.bosshealth;
                float maxbossHp = GameManager1.instance.maxbosshealth;
                mySlider.value = curbossHp / maxbossHp;
                break;
            // case InfoType.Time:
            //     float remainTime = GameManager1.instance.maxGameTime - GameManager1.instance.gameTime;
            //     int min = Mathf.FloorToInt(remainTime / 60);
            //     int sec = Mathf.FloorToInt(remainTime  % 60);
            //     myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
            //     break;
            case InfoType.Health:
                float curHealth = GameManager1.instance.health;
                float maxHealth = GameManager1.instance.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;
        }
    }
}
