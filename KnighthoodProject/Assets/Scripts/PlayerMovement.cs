using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 rot;
    [SerializeField]
    Transform pivot;
    [SerializeField]
    float sensitivity;
    [SerializeField]
    float speed;
    Rigidbody rb;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        LookAround();
        WalkAround();
    }

    void LookAround()
    {
        rot.x += Input.GetAxisRaw("Mouse X");
        rot.y += Input.GetAxisRaw("Mouse Y");
        pivot.localRotation = Quaternion.Euler(-rot.y * sensitivity, 0, 0);
        transform.rotation = Quaternion.Euler(0, rot.x * sensitivity, 0);
    }

    void WalkAround()
    {
        if (Input.GetKey(KeyCode.W))
            rb.velocity = transform.forward * speed;

        if (Input.GetKey(KeyCode.S))
            rb.velocity = -transform.forward * speed;

        if (Input.GetKey(KeyCode.A))
            rb.velocity = -transform.right * speed;

        if (Input.GetKey(KeyCode.D))
            rb.velocity = transform.right * speed;
    }
}
