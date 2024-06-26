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

    //Animace �tok�
    //[SerializeField]
    //protected int maxAttSpree;
    //protected int attSpree = 0;
    [SerializeField]
    protected float resetSpreeTimer;
    int isHeavyHash = Animator.StringToHash("IsHeavy"), strikeHash = Animator.StringToHash("Strike");

    //Blokov�n�
    protected Had dude;
    [SerializeField]
    float blockCost;
    bool parried = false;
    BoxCollider blockTrigger;

    //�t�t
    SecondaryWeapon sw;

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
        Unblock();
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
        //attSpree++;
        anim.SetBool(isHeavyHash, !attack.light);
        anim.SetTrigger(strikeHash);
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
        if(blockTrigger != null)
        {
            blockTrigger.enabled = false;
            anim.SetBool("Blocking", false);
        }
    }
    //protected void SetUpAnimator()
    //{
    //    anim = GetComponentInParent<Animator>();
    //    anim.runtimeAnimatorController = animCon;
    //}
    public void EmptyQueue()
    {
        attackQueue.Clear();
        //attSpree = 0;
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
            if (sw != null)
                sw.GetReadyToStrike(currAtt, addDmg);
        }
        else
        {
            for (int i = 0; i < triggers.Length; i++)
            {
                triggers[i].enabled = false;
            }
            if(sw != null)
                sw.StopStriking();
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
    public void SetSecondaryWeapon(SecondaryWeapon sw)
    {
        this.sw = sw;
    }
}