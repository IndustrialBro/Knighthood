using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Animator anim;
    //[SerializeField]
    //public RuntimeAnimatorController animCon;


    protected Queue<Attack> attackQueue = new Queue<Attack>();
    [SerializeField]
    protected Attack lightAttack, heavyAttack;
    protected Attack currAtt;
    protected int addDmg = 0;
    
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
    bool parried = false;
    BoxCollider blockTrigger;

    protected virtual void Start()
    {
        triggers = GetComponents<Collider>();
        dude = GetComponentInParent<Had>();
        dude.blockCost = blockCost;
        //SetUpAnimator();
        anim = GetComponentInParent<Animator>();
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
            if(!parried)
            {
                other.GetComponent<Had>().GetHit(currAtt, addDmg);
            }
            else
            {
                other.GetComponent<Had>().KnockBack(currAtt, transform.position);
            }
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
        //dude.isblocking = true;
        blockTrigger.enabled = true;
        anim.SetBool("Blocking", true);
    }
    protected void Unblock()
    {
        //dude.isblocking = false;
        blockTrigger.enabled = false;
        anim.SetBool("Blocking", false);
    }
    //protected void SetUpAnimator()
    //{
    //    anim = GetComponentInParent<Animator>();
    //    anim.runtimeAnimatorController = animCon;
    //}
    public void EmptyQueue()
    {
        attackQueue.Clear();
        attSpree = 0;
    }
    public void SetReadyToStrike(bool b)
    {
        readyToStrike = b;
        //Debug.Log($"Ready: {readyToStrike}");

        if (readyToStrike)
            parried = false;
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
    public void SetAdditionalDamage(int dmg)
    {
        addDmg = dmg;
        Debug.Log($"Additional damage changed to {addDmg}");
    }
    public void Parry()
    {
        parried = true;
    }
    public void SetBlockTrigger(BoxCollider bt)
    {
        blockTrigger = bt;
    }
}