using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private void Update()
    {
        Transform camera = Camera.main.transform;

        transform.LookAt(camera.position);
    }
}
