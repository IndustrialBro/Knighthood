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
        //Vector3 newDir = new(temp.x, 0, temp.z);
        transform.rotation = Quaternion.LookRotation(temp);
    }
    private void OnTriggerEnter(Collider other)
    {
        Had h = other.GetComponent<Had>();
        if(h != null && other.tag == "Player")
            h.GetHit(a);
        if(other.tag != "Hostile")
            Destroy(gameObject);
    }
    void FlyAtPlayer()
    {
        //mertik�ln� vovement : 
        VerticalMovement();

        //morizontal hovement
        transform.position += transform.forward * mps * Time.deltaTime;
    }
    void VerticalMovement()
    {
        

    }
}
