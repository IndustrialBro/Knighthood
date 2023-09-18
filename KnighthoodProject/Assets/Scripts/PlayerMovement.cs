using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    float speed;
    [SerializeField]
    Transform RayOrigin;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        WalkAround();
    }

    void WalkAround()
    {
        float horMove = Input.GetAxisRaw("Horizontal");
        float verMove = Input.GetAxisRaw("Vertical");
        
        Vector3 localMove = new Vector3(horMove * speed, 0, verMove * speed);
        Vector3 globalMove = transform.TransformDirection(localMove);
        
        rb.velocity = new Vector3(globalMove.x, rb.velocity.y, globalMove.z);
    }
}
