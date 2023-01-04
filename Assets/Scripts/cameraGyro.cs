using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraGyro : MonoBehaviour
{
    private bool gyroEnabled;
    private Gyroscope gyroscope;

    public GameObject cameraContainer;
    private Quaternion rot;
    private void Start()
    {
        
        
        transform.SetParent(cameraContainer.transform);

        gyroEnabled = enableGyro();
    }

    private bool enableGyro()
    {
        cameraContainer.transform.position = transform.position;

        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }
    void Update()
    {
       if (gyroEnabled)
        {
            transform.localRotation = gyroscope.attitude * rot;
        }
    }
}
