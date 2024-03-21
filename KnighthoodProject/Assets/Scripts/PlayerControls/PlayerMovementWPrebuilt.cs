using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementWPrebuilt : MonoBehaviour
{
    //nezapomeò pøidat skákání
    CharacterController cc;
    [SerializeField]
    float speed;
    float verMove, horMove, yMovement, addSpeed = 0;
    
    [Header("Running")]

    [SerializeField]
    float runningSpeed;
    public float currStamina { get; private set; }

    [SerializeField]
    float maxRunningCooldown, maxStamina, staminaRecMod;
    float currRunningCooldown = 0;

    [SerializeField]
    PlayerUI ui;

    [Header("Jumping")]
    [SerializeField]
    float maxJumpTime;
    [SerializeField]
    float maxJumpHeight;
    float jumpVel, grav;
    bool isJumping;


    private void Awake()
    {
        cc = GetComponent<CharacterController>();
        SetUpJumpVars();
    }

    // Update is called once per frame
    void Update()
    {
        MoveAround();
    }

    void MoveAround()
    {
        verMove = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        horMove = Input.GetAxisRaw("Horizontal") * Time.deltaTime;

        ProcessRunning();

        Vector3 localMove = new Vector3(horMove, yMovement, verMove);
        Vector3 globalMove = transform.TransformDirection(localMove).normalized;

        cc.Move(globalMove * (speed + addSpeed));
        HandleGravity();
        HandleJump();
    }

    void ProcessRunning()
    {
        if (currRunningCooldown < 0)
        {
            if (currStamina > 0 && cc.isGrounded)
            {
                //Stamina expension
                if (Input.GetButton("Run"))
                {
                    verMove *= runningSpeed;
                    DepleteStamina(1, true);
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
        if (currStamina < maxStamina && !Input.GetButton("Run"))
        {
            DepleteStamina(-staminaRecMod, true);
        }
    }
    public void DepleteStamina(float howMuch, bool overTime)
    {
        if (overTime)
        {
            currStamina -= howMuch * Time.deltaTime;
        }
        else
        {
            currStamina -= howMuch;
        }
        ui.UpdateStamina(currStamina, maxStamina);
    }
    public void SetAdditionalSpeed(float s)
    {
        addSpeed = s;
        Debug.Log($"Additional speed changed to {addSpeed}");
    }
    void HandleGravity()
    {
        if(cc.isGrounded)
        {
            yMovement = -0.5f;
        }
        else 
        { 
            yMovement -= grav * Time.deltaTime;
        }
    }

    void SetUpJumpVars()
    {
        float timeToApex = maxJumpTime / 2;
        grav = (2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        jumpVel = (2 * maxJumpHeight) / timeToApex;
    }
    void HandleJump()
    {
        if (cc.isGrounded)
        {
            if (!isJumping && Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                yMovement = jumpVel;
            }
            else if (isJumping)
            {
                isJumping = false;
            }
        }
    }
}
