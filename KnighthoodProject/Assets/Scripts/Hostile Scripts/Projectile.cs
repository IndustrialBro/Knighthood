using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float mps, arcHeight;
    [SerializeField]
    Attack a;

    void Start()
    {
        TurnToPlayer();

    }

    void Update()
    {
        FlyAtPlayer();
    }
    void TurnToPlayer()
    {
        Vector3 targetDir = GameManager.instance.playerTransform.position - transform.position;
        Vector3 temp = Vector3.RotateTowards(transform.forward, targetDir, 3.14f, 0);
        Vector3 newDir = new(temp.x, 0, temp.z);
        transform.rotation = Quaternion.LookRotation(newDir);
    }
    private void OnTriggerEnter(Collider other)
    {
        Ihad h = other.GetComponent<Ihad>();
        if(h != null)
            h.GetHit(a);
        Destroy(gameObject);
    }
    void FlyAtPlayer()
    {
        //mertikální vovement : 
        VerticalMovement();

        //morizontal hovement
        transform.position += transform.forward * mps * Time.deltaTime;
    }
    void VerticalMovement()
    {
        

    }
}
