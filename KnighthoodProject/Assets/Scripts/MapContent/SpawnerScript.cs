using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    float radius, maxSpawnCool;
    float currSpawnCool;
    
    [SerializeField]
    bool active = false;
    
    [SerializeField]
    List<GameObject> hostiles = new List<GameObject>();
    void Start()
    {
        currSpawnCool = maxSpawnCool;
    }

    void Update()
    {
        if (active)
        {
            if (currSpawnCool <= 0)
            {
                SpawnHostile();
                currSpawnCool = maxSpawnCool;
            }
            currSpawnCool -= Time.deltaTime;
        }
        
    }
    void SpawnHostile()
    {
        int i = Random.Range(0, hostiles.Count);
        float x = transform.position.x + Random.Range(0, radius);
        float z = transform.position.z + Random.Range(0, radius);
        GameObject g = hostiles[i];
        g.transform.position = new Vector3(x, transform.position.y, z);
        
        GameObject h = Instantiate(g);
        h.GetComponent<Enemy>().SwitchState(1);
    }
}
