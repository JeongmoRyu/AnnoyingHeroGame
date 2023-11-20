using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAction04 : MonoBehaviour
{
    public float moveSpeed;
    public AudioSource AccidentSound;
    private int spacebarCount = 0;

    private bool spacebarActivated = false;
    private float rightMoveDuration = 0.4f; // 이동 시간 (right)
    private float rightMoveTimer = 0.0f;

    Animator anim;
    float h;
    float v;
    bool isHorizonMove; // 수평으로 이동하고 있는가?

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (spacebarActivated) // 마지막 스크립트 클릭!
        {
            rightMoveTimer += Time.deltaTime;

            /********************* 우향 이동 [S] *********************/
            if (rightMoveTimer < rightMoveDuration)
            {
                AccidentSound.Play();
                // 스페이스바 효과 진행 중
                if (anim.GetInteger("hAxisRaw") != 1)
                {
                    anim.SetBool("isChanged", true);
                    anim.SetInteger("hAxisRaw", 1);
                }
                else
                    anim.SetBool("isChanged", false);

                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
            else if (rightMoveTimer >= rightMoveDuration)
            {
                // 우향 이동이 끝났을 때 한 번만 실행
                SceneManager.LoadScene("Intro 04");
            }
            /********************* 우향 이동 [E] *********************/
        }
        else // 10번째 스크립트 클릭하면 주인공 횡단보도로 이동 시작
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spacebarCount++;

                if (spacebarCount >= 14)
                {
                    spacebarActivated = true;
                }
            }
        }
    }
}
