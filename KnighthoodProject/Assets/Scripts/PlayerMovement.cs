using System;
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
    float horMove;
    float verMove;

    [Header("Running")]
    [SerializeField]
    float runningSpeed;
    [SerializeField]
    float maxStamina;
    float currStamina;
    [SerializeField]
    float maxRunningCooldown;
    float currRunningCooldown = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currStamina = maxStamina;
    }

    
    void Update()
    {
        WalkAround();
    }

    void WalkAround()
    {
        horMove = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        verMove = Input.GetAxisRaw("Vertical") * Time.deltaTime;

        ProcessRunning();
        
        Vector3 localMove = new Vector3(horMove * speed, 0, verMove * speed);
        Vector3 globalMove = transform.TransformDirection(localMove);
        
        rb.velocity = new Vector3(globalMove.x, rb.velocity.y, globalMove.z);
    }

    void ProcessRunning()
    {
        if(currRunningCooldown <= 0)
        {
            if(currStamina > 0)
            {
                if (isRunning())
                {
                    verMove = verMove * runningSpeed;
                    currStamina -= Time.deltaTime;
                }
            }
            else
            {
                currRunningCooldown = maxRunningCooldown;
            }
        }
        else
        {
            currRunningCooldown -= Time.deltaTime;
            currStamina += Time.deltaTime;
            Debug.Log(currRunningCooldown);
        }
    }

    private bool isRunning()
    {
        return Input.GetAxisRaw("Run") > 0;
    }
}
