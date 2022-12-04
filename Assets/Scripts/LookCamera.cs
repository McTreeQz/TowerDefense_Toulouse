using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    Camera m_camera;

    // Start is called before the first frame update
    private void Start()
    {
        m_camera = Camera.main;
    }
    private void LateUpdate()
    {
        transform.LookAt(transform.position + m_camera.transform.forward);
    }
}
