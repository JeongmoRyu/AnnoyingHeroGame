using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript99 : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;

    void Start()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        Color alpha = Panel.color;
        Panel.gameObject.SetActive(true);
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
