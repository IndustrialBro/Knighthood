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
    [SerializeField]
    float jumpForce;
    float horMove;
    float verMove;

    [Header("Running")]

    [SerializeField]
    float runningSpeed;
    float currStamina;

    [SerializeField]
    float maxRunningCooldown, maxStamina, staminaRecMod;
    float currRunningCooldown = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currStamina = maxStamina;
    }

    
    void Update()
    {
        WalkAround();
        JumpAround();
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
    void JumpAround()
    {
        if(Input.GetAxisRaw("Jump") > 0)
        {
            if (isGrounded())
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    void ProcessRunning()
    {
        if(currRunningCooldown <= 0)
        {
            if(currStamina > 0)
            {
                //Stamina expension
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
        }

        //Stamina recovery
        if(currStamina < maxStamina && !isRunning())
        {
            currStamina += Time.deltaTime * staminaRecMod;
        }
    }

    bool isRunning()
    {
        return Input.GetAxisRaw("Run") > 0;
    }
    bool isGrounded()
    {
        Physics.Raycast(RayOrigin.position, Vector3.down, out RaycastHit hit, 0.2f);
        if (hit.collider != null)
        {
            return true;
        }
        else return false;
    }
}
