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
    }

    void WalkAround()
    {
        JumpAround();

        horMove = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
        verMove = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

        ProcessRunning();

        transform.Translate(horMove, 0, verMove);
    }
    void JumpAround()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if (isGrounded())
            {
                rb.AddForce(Vector3.up * jumpForce);
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
                if (Input.GetButton("Run"))
                {
                    verMove *= runningSpeed;
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
        if(currStamina < maxStamina && !Input.GetButton("Run"))
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
        Physics.Raycast(RayOrigin.position, Vector3.down, out RaycastHit hit, 0.1f);
        if (hit.collider != null)
        {
            return true;
        }
        else return false;
    }
}
