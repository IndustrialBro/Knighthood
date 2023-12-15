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
                Debug.Log("Interactor is interacting");
                try
                {
                    hit.collider.gameObject.GetComponent<IInteractable>().Interact(gameObject);
                }
                catch
                {
                    hit.collider.gameObject.GetComponentInParent<IInteractable>().Interact(gameObject);
                }
                finally
                {
                    Debug.Log("Cannot interact.");
                }
            }
        }
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward);
    }
}
