using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBoss : Enemy
{
    [SerializeField]
    List<ArenaMarker> arenas = new List<ArenaMarker>();
    ArenaMarker currArena;
    public void TeleportAlone()
    {
        Transform trnsfrm = currArena.GetRandomMarker();
        Vector3 temp = trnsfrm.position;

        transform.position = temp;
    }
    public void SwitchArena()
    {
        int i = Random.Range(0, arenas.Count);
        ArenaMarker newArena = arenas[i];
        Vector3 temp = newArena.transform.position;
        
        transform.position = temp;

        float x = Random.Range(-3, 3);
        float z = Random.Range(-3, 3);
        
        GameManager.instance.playerTransform.position = new(temp.x + x, temp.y, temp.z + z);

        currArena = newArena;
    }
}