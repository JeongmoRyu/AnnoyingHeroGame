using System.Collections;
using UnityEngine;

public class CameraShake5 : MonoBehaviour
{
    public static CameraShake5 Instance { get; private set; } // ΩÃ±€≈Ê ¿ŒΩ∫≈œΩ∫

    private Vector3 originalPos;

    private void Awake()
    {
        Instance = this; // ΩÃ±€≈Ê ¿ŒΩ∫≈œΩ∫
    }

    public void Shake(float duration, float amount)
    {
        originalPos = transform.localPosition;
        StartCoroutine(ShakeCoroutine(duration, amount));
    }

    private IEnumerator ShakeCoroutine(float duration, float amount)
    {
        float endTime = Time.time + duration;

        while (Time.time < endTime)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * amount;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
