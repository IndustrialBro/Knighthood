using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAround : MonoBehaviour
{
    Vector2 rot;
    [SerializeField]
    Transform pivot;
    [SerializeField]
    float sensitivity;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        LookAround();
    }

    void LookAround()
    {
        rot.x += Input.GetAxisRaw("Mouse X") * sensitivity;
        rot.y += Input.GetAxisRaw("Mouse Y") * sensitivity;

        if (rot.y > 90)
            rot.y = 90;
        if (rot.y < -90)
            rot.y = -90;

        pivot.localRotation = Quaternion.Euler(-rot.y, 0, 0);
        transform.rotation = Quaternion.Euler(0, rot.x, 0);
    }
}
