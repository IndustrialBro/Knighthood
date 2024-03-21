using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float mps, trackingCool;
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
        transform.rotation = Quaternion.LookRotation(temp);
    }
    private void OnTriggerEnter(Collider other)
    {
        Had h = other.GetComponent<Had>();
        if(h != null && other.tag == "Player")
            h.GetHit(a, 0);
        if(other.tag != "Hostile")
            Destroy(gameObject);
    }
    void FlyAtPlayer()
    {
        if(trackingCool > 0)
        {
            TurnToPlayer();
            trackingCool -= Time.deltaTime;
        }
        transform.position += transform.forward * mps * Time.deltaTime;
    }
}
