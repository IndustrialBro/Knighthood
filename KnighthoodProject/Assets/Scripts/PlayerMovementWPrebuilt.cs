using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementWPrebuilt : MonoBehaviour
{
    // PØIDEJ GRAVITACI PODLE IHEARTGAMEDEV A ZAPIŠ, ŽES TO DOSTAL VOD NÌJ DO DOKUMENTACE!!! jo a nezapomeò pøidat skákání
    CharacterController cc;
    [SerializeField]
    float speed;
    float verMove;
    float horMove;
    float yMovement;
    [SerializeField]
    float jumpVel;
    bool isJumping = false;
    [Header("Running")]

    [SerializeField]
    float runningSpeed;
    float currStamina;

    [SerializeField]
    float maxRunningCooldown, maxStamina, staminaRecMod;
    float currRunningCooldown = 0;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
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
        Vector3 globalMove = transform.TransformDirection(localMove);
        Debug.Log($"{globalMove.y} {cc.isGrounded}");
        cc.Move(Vector3.ClampMagnitude(globalMove, 1) * speed);
        HandleGravity();
        JumpAround();
    }

    void ProcessRunning()
    {
        if (currRunningCooldown <= 0)
        {
            if (currStamina > 0)
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
        if (currStamina < maxStamina && !Input.GetButton("Run"))
        {
            currStamina += Time.deltaTime * staminaRecMod;
        }
    }
    void HandleGravity()
    {
        if(cc.isGrounded)
        {
            yMovement = -0.5f;
            isJumping = false;
        }
        else if(isJumping)
        {
            yMovement -= 0.5f * Time.deltaTime;
        }
        else 
        { 
            yMovement -= 9.8f;
        }
    }
    void JumpAround()
    {
        if(Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            isJumping = true;
            yMovement = jumpVel;
        }
    }
}
