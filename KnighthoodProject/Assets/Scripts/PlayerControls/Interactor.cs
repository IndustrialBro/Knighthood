using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    Transform cameraTransform;
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, 1))
        {
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("Interactor is atempting to interact");

                IInteractable temp = hit.collider.gameObject.GetComponent<IInteractable>();
                if (temp != null)
                {
                    try
                    {
                        temp.Interact(gameObject);
                    }
                    catch
                    {
                        Debug.LogError("Failed to interact");
                    }
                }
            }
        }
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward);
    }
}
