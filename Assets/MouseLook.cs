using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensX = 100f;
    public float sensY = 100f;


    Vector2 rot;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        rot.y += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        rot.x += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(-rot.x, rot.y, 0f);

    }
}
