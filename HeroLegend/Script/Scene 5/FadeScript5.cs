using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript5 : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 0.5f;

    private int spaceCount = 0; // 스페이스바 카운트 변수 추가

    void Start()
    {
        Panel.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceCount++;
            if (spaceCount == 3) // 스페이스바를 3번 눌렀을 때
            {
                StartCoroutine(FadeFlow());
                spaceCount = 0; // 카운트 초기화
            }
        }
    }

    IEnumerator FadeFlow()
    {
        Color alpha = Panel.color;
        time = 0f;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0f;

        yield return new WaitForSeconds(1f);

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Panel.gameObject.SetActive(false);
        yield return null;
    }
}

//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;

//public class FadeScript5 : MonoBehaviour

//{
//    public Image Panel;
//    float time = 0f;
//    float F_time = 1f;

//    void Start()
//    {
//        StartCoroutine(FadeFlow());
//    }

//    IEnumerator FadeFlow()
//    {
//        Color alpha = Panel.color;
//        Panel.gameObject.SetActive(true);
//        time = 0f;
//        while (alpha.a < 1f)
//        {
//            time += Time.deltaTime / F_time;
//            alpha.a = Mathf.Lerp(0, 1, time);
//            Panel.color = alpha;
//            yield return null;
//        }
//        time = 0f;

//        yield return new WaitForSeconds(1f);

//        while (alpha.a > 0f)
//        {
//            time += Time.deltaTime / F_time;
//            alpha.a = Mathf.Lerp(1, 0, time);
//            Panel.color = alpha;
//            yield return null;
//        }
//        Panel.gameObject.SetActive(false);
//        yield return null;
//    }
//}
