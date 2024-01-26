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
    
    public bool readyToStrike = true;
    protected string targetTag;
    Collider[] triggers;

    //Animace útokù
    [SerializeField]
    protected int maxAttSpree;
    protected int attSpree = 0;
    [SerializeField]
    protected float resetSpreeTimer;
    Coroutine AttSpreeResetCoroutine = null;
    int isHeavyHash = Animator.StringToHash("IsHeavy"), attCountHash = Animator.StringToHash("AttCount"), strikeHash = Animator.StringToHash("Strike");

    //Blokování
    protected Had dude;
    [SerializeField]
    float blockCost;

    protected virtual void Start()
    {
        triggers = GetComponents<Collider>();
        dude = GetComponentInParent<Had>();
        dude.blockCost = blockCost;
        SetUpAnimator();
        SetTargetTag();
        SetAttacking(false);
        GetComponentInParent<Middleman>().SetNewWeaponComponent(this);
    }
    protected void MoveThroughQueue()
    {
        if(attackQueue.Count > 0 && readyToStrike)
        {
            ExecuteAttacks(attackQueue.Dequeue());
        }
    }
    protected void ExecuteAttacks(Attack Att)
    {
        currAtt = Att;
        SetReadyToStrike(false);
        AnimateAttacks(Att);
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag)
        {
            other.GetComponent<Had>().GetHit(currAtt);
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
        dude.isblocking = true;
        anim.SetBool("Blocking", true);
    }
    protected void Unblock()
    {
        dude.isblocking = false;
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
    public void SetReadyToStrike(bool b)
    {
        readyToStrike = b;
        //Debug.Log($"Ready: {readyToStrike}");
    }
    public void SetAttacking(bool b)
    {
        if(b)
        {
            for(int i = 0 ; i < triggers.Length ; i++)
            {
                triggers[i].enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < triggers.Length; i++)
            {
                triggers[i].enabled = false;
            }
        }
    }
}