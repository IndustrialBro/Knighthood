using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    Rigidbody rb;
    bool isgrounded;
    [SerializeField]
    Transform RayOrigin;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        CheckIfGrounded();
        Jump();
        WalkAround();
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

    void Jump()
    {
        if(isgrounded)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(transform.up, ForceMode.Impulse);
            }
        }
    }

    void CheckIfGrounded()
    {
        Ray r = new Ray(RayOrigin.position, -transform.up);
        Physics.Raycast(r, out RaycastHit hit, 0.2f);
        if (hit.collider != null)
            isgrounded = true;
        else
            isgrounded= false;
    }
}
