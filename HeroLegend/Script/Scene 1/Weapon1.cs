using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon1 : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;
    Player1 player;
    private Transform noise;

    float timer;

    void Awake()
    {
        player = GetComponentInParent<Player1>();
        // player = GameManager.instance.player;
    }

    private bool isButtonPressed = false;

    void Update()
    {
        // if (!GameManager.instance.isLive)
        //     return;
        switch (id) {
            case 0:
                timer +=  Time.deltaTime;
                if (timer > speed) {
                    timer = 0f;
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        if (!isButtonPressed)
                        {
                            Fire();
                            // AudioManager1.instance.PlayBgm(false);
                            AudioManager1.instance.PlaySfx(AudioManager1.Sfx.Fire);
                            // player.rectTransform.rotation.y = dir
                            isButtonPressed = true;
                        }
                    }
                    else
                    {
                        isButtonPressed = false;
                    }
                }
    
                // if (Input.GetKey(KeyCode.LeftControl)) {
                //     Fire();
                // }
                
                break;
            default:
                // if (Input.GetKey(KeyCode.LeftControl))
                // {
                    
                // }
                break;
        }


    }

    // public void LevelUp(float damage, int count)
    // {
    //     this.damage = damage;
    //     this.count += count;

    //     if (id == 0)
    //         Batch();

    //     // player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver);
    // }

    public void Init()
    {
        // ItemData data
        // name = "Weapon." + data.itemId;
        // transform.parent = player.transform;
        // transform.localPosition = Vector3.zero;

        // id = data.itemId;
        // damage = data.baseDamage * Character.Damage;
        // count = data.baseCount + Character.Count;

        // for (int index=0; index < GameManager.instance.pool.prefabs.Length; index++) {
        //     if (data.projectile == GameManager.instance.pool.prefabs[index]) {
        //         prefabId = index;
        //         break;
        //     }
        // }

        switch (id) {
            case 0:
                // speed = 150 * Character.WeaponSpeed;
                speed = 0.3f;
                // Batch();
                break;
            default:

                // speed = 0.5f * Character.WeaponRate;
                break;
        }
        // Hand hand = player.hands[(int)data.itemType];
        // hand.spriter.sprite = data.hand;
        // hand.gameObject.SetActive(true);


        // player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver);
    }

    

    void Fire() 
    {
        if (!player.scanner.nearestTarget)
            return;

        Vector3 targetPos = player.scanner.nearestTarget.position;
        targetPos[1] = 1f;

        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;
        if (dir[0] > 0)
        {
            player.rectTransform.localEulerAngles = new Vector3(player.rectTransform.localEulerAngles.x, -180, player.rectTransform.localEulerAngles.z);
            // player.rectTransform.localEulerAngles = new Vector3(0, -180, 0);
        }
        if (dir[0] < 0)
        {
            player.rectTransform.localEulerAngles = new Vector3(player.rectTransform.localEulerAngles.x, 0, player.rectTransform.localEulerAngles.z);
            // player.rectTransform.localEulerAngles = new Vector3(0, 0, 0);
        }
        // Transform noise = GameManager.instance.pool.Get(prefabId).transform;
        // noise.position = transform.position;
        // noise.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        // noise.GetComponent<Noise>().Init(damage, dir);



        // if (transform.GetChild(1).gameObject.SetActive == true)
        // {
        //     Transform noise = GameManager.instance.pool.Get(0).transform;
        // }
        // if (transform.GetChild(1).gameObject.SetActive == false)
        // {
        //     Transform noise = GameManager.instance.pool.Get(1).transform;
        // }

        // noise.position = transform.position;
        // noise.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        // noise.GetComponent<Noise>().Init(damage, dir);

        if (!player.transform.GetChild(1).gameObject.activeSelf)
        {
            noise = GameManager1.instance.pool.Get(0).transform;
        }
        else
        {
            noise = GameManager1.instance.pool.Get(1).transform;
        }

        noise.position = transform.position;
        noise.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        noise.GetComponent<Noise1>().Init(damage, dir);

    }
}
