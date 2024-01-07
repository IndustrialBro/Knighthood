using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "ScriptableObjects/States/IdleState")]
public class HostileIdleState : HostileState
{
    [SerializeField]
    float maxBoredom;
    float MaxBoredom;
    float boredom = 0;

    int idle2hash = Animator.StringToHash("Base Layer.Idle2");
    public override void SetUpState(GameObject gameObject)
    {
        base.SetUpState(gameObject);
        MaxBoredom = maxBoredom + Random.Range(0, 6);
    }
    public override void EnterState()
    {

    }
    public override void Update()
    {
        if(boredom >= MaxBoredom)
        {
            boredom = 0;
            anim.Play(idle2hash);
        }
        else
        {
            boredom += Time.deltaTime;
        }
    }
}
