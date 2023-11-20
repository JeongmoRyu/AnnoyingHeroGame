using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager5_0 : MonoBehaviour
{
    public Camera[] cameras;
    public Canvas canvas;

    public void ChangeCamera(int pre, int post)
    {
        cameras[pre].enabled = false;
        canvas.GetComponent<Canvas>().worldCamera = cameras[post];
        cameras[post].enabled = true;
    }
}
