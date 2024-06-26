using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    Transform cameraTransform;
    LayerMask mask;
    void Start()
    {
        cameraTransform = Camera.main.transform;
        mask = LayerMask.GetMask("Interactable");
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, 2.5f, mask))
            {
                Debug.Log("Interactor is atempting to interact");

                IInteractable temp = hit.collider.gameObject.GetComponent<IInteractable>();
                if (temp != null)
                {
                    temp.Interact(gameObject);
                }
            }
        }
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward);
    }
}
