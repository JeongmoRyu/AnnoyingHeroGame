using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake5_0 : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeDuration = 0f;
    public float shakeMagnitude = 0.1f;
    public float dampingSpeed = 5.0f;

    Vector3 initialPosition;

    void Awake()
    {
        initialPosition = cameraTransform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            cameraTransform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            cameraTransform.localPosition = initialPosition;
        }
    }
}
