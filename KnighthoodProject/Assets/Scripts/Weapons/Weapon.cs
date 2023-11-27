using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Animator anim;

    protected Queue<Attack> attackQueue = new Queue<Attack>();
    [SerializeField]
    protected Attack lightAttack, heavyAttack;
    protected Attack currAtt;
    protected bool attacking = false;
    protected bool attReady = true;
    protected string targetTag;

    //Animace �tok�
    [SerializeField]
    protected int maxAttSpree;
    protected int attSpree = 0;
    [SerializeField]
    protected float resetSpreeTimer;
    Coroutine AttSpreeResetCoroutine = null;
    Coroutine ResetAttackingCoroutine = null;
    int isHeavyHash = Animator.StringToHash("IsHeavy"), attCountHash = Animator.StringToHash("AttCount"), strikeHash = Animator.StringToHash("Strike");

    //Blokov�n�
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
        if(attackQueue.Count > 0 && attReady)
        {
            ExecuteAttacks(attackQueue.Dequeue());
        }
    }
    protected void ExecuteAttacks(Attack Att)
    {
        if (ResetAttackingCoroutine != null)
            StopCoroutine(ResetAttackingCoroutine);
        
        attReady = false;
        attacking = true;
        currAtt = Att;
        AnimateAttacks(Att);
        StartCoroutine(ResetAttReady());

        ResetAttackingCoroutine = StartCoroutine(ResetAttacking());
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (attacking && other.tag == targetTag)
        {
            other.GetComponent<Ihad>().GetHit(currAtt);
        }
    }

    protected void AnimateAttacks(Attack attack)
    {
        if (AttSpreeResetCoroutine != null)
            StopCoroutine(AttSpreeResetCoroutine);

        attSpree++;
        anim.SetBool(isHeavyHash, !attack.light);
        anim.SetInteger(attCountHash, attSpree);
        anim.SetTrigger(strikeHash);

        if (attSpree == maxAttSpree)
            attSpree = 0;
        else
            AttSpreeResetCoroutine = StartCoroutine(ResetAttSpree());
    }
    protected IEnumerator ResetAttReady()
    {
        //float temp = anim.GetNextAnimatorStateInfo(0).length;
        //Debug.Log($"temp == {temp}");
        float temp = 0.8f;
        yield return new WaitForSeconds(temp);
        attReady = true;
        //anim.SetBool("AAIQ", false);
    }
    protected IEnumerator ResetAttacking() 
    {
        //float temp = anim.GetNextAnimatorStateInfo(0).length;
        float temp = 0.8f;
        yield return new WaitForSeconds(temp);
        attacking = false;
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
        attackQueue.Clear();
        dude.isBlocking = true;
        anim.SetBool("Blocking", true);
    }
    protected void Unblock()
    {
        dude.isBlocking = false;
        anim.SetBool("Blocking", false);
    }
    protected abstract void SetUpAnimator();
}