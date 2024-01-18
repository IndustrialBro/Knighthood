using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Animator anim;
    [SerializeField]
    public RuntimeAnimatorController animCon;


    protected Queue<Attack> attackQueue = new Queue<Attack>();
    [SerializeField]
    protected Attack lightAttack, heavyAttack;
    protected Attack currAtt;
    bool IsAttacking() 
    {
        if (anim != null)
            return anim.GetCurrentAnimatorStateInfo(0).IsTag("Attacking");
        return false;
    }
    public bool ReadyToStrike()
    {
        if(anim != null)
            return !(IsAttacking() || anim.GetCurrentAnimatorStateInfo(0).IsTag("Preparing"));
        return false;
    }
    protected string targetTag;

    //Animace útokù
    [SerializeField]
    protected int maxAttSpree;
    protected int attSpree = 0;
    [SerializeField]
    protected float resetSpreeTimer;
    Coroutine AttSpreeResetCoroutine = null;
    int isHeavyHash = Animator.StringToHash("IsHeavy"), attCountHash = Animator.StringToHash("AttCount"), strikeHash = Animator.StringToHash("Strike");

    //Blokování
    protected Ihad dude;
    [SerializeField]
    float blockCost;

    protected virtual void Start()
    {
        dude = GetComponentInParent<Ihad>();
        dude.blockCost = blockCost;
        SetUpAnimator();
        SetTargetTag();
    }
    protected void MoveThroughQueue()
    {
        if(attackQueue.Count > 0 && ReadyToStrike())
        {
            ExecuteAttacks(attackQueue.Dequeue());
        }
    }
    protected void ExecuteAttacks(Attack Att)
    {
        currAtt = Att;
        AnimateAttacks(Att);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (IsAttacking() && other.tag == targetTag)
        {
            other.GetComponent<Ihad>().GetHit(currAtt);
        }
    }

    protected void AnimateAttacks(Attack attack)
    {
        if (AttSpreeResetCoroutine != null)
            StopCoroutine(AttSpreeResetCoroutine);

        attSpree++;
        Debug.Log($"Spree: {attSpree}");
        anim.SetBool(isHeavyHash, !attack.light);
        anim.SetInteger(attCountHash, attSpree);
        anim.SetTrigger(strikeHash);

        if (attSpree == maxAttSpree)
            attSpree = 0;
        else
            AttSpreeResetCoroutine = StartCoroutine(ResetAttSpree());
    }
    
    protected IEnumerator ResetAttSpree()
    {
        yield return new WaitForSeconds(resetSpreeTimer);
        attSpree = 0;
        //Debug.Log("Spree reset");
    }
    protected abstract void SetTargetTag();
    protected void Block()
    {
        EmptyQueue();
        dude.isBlocking = true;
        anim.SetBool("Blocking", true);
    }
    protected void Unblock()
    {
        dude.isBlocking = false;
        anim.SetBool("Blocking", false);
    }
    protected void SetUpAnimator()
    {
        anim = GetComponentInParent<Animator>();
        anim.runtimeAnimatorController = animCon;
    }
    public void EmptyQueue()
    {
        attackQueue.Clear();
        attSpree = 0;
    }
}