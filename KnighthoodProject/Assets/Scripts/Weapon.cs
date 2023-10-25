using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField]
    public AnimatorController animCon;
    Animator anim;

    protected Queue<Attack> attackQueue = new Queue<Attack>();
    protected Attack lightAttack;
    protected Attack heavyAttack;
    protected Attack currAtt;
    protected bool attacking = false;
    protected bool attReady = false;
    protected string targetTag;

    //Animace útokù
    [SerializeField]
    protected int maxAttSpree;
    protected int attSpree = 0;
    [SerializeField]
    protected float resetSpreeTimer;
    Coroutine AttSpreeResetCoroutine = null;
    Coroutine ResetAttackingCoroutine = null;

    //Blokování
    protected Character dude;

    private void Awake()
    {
        dude = GetComponentInParent<Character>();
    }

    protected void Start()
    {
        CreateAttacks();
        anim = GetComponentInParent<Animator>();
        anim.runtimeAnimatorController = animCon;
        SetTargetTag();
    }

    protected void Update()
    {
        ProcessInputs();
        MoveThroughQueue();
    }

    protected abstract void CreateAttacks(); //Každá zbraò si to udìlá sama
    protected abstract void ProcessInputs(); //Zaøídí tøídy PlayerWeapon a HostileWeapon nebo jak je pojmenuju
    protected void MoveThroughQueue()
    {
        if(attackQueue.Count > 0 && !attacking) 
        {
            Debug.Log(attackQueue.Count);
            ExecuteAttacks(attackQueue.Dequeue());
        }
    }
    protected void ExecuteAttacks(Attack Att)
    {
        attacking = true;
        currAtt = Att;
        AnimateAttacks(Att);
        ResetAttackingCoroutine = StartCoroutine(ResetAttacking());
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (attacking && other.tag == targetTag)
        {
            other.GetComponent<Character>().GetHit(currAtt);
        }
    }

    protected void AnimateAttacks(Attack attack)
    {
        if (AttSpreeResetCoroutine != null)
            StopCoroutine(AttSpreeResetCoroutine);
        
        attSpree++;
        anim.SetBool("IsHeavy", !attack.light);
        anim.SetInteger("AttCount", attSpree);
        anim.SetTrigger("Attack");
        
        if (attSpree == maxAttSpree)
            attSpree = 0;
        else
            AttSpreeResetCoroutine = StartCoroutine(ResetAttSpree());
    }
    protected IEnumerator ResetAttacking() 
    {
        //float temp = anim.GetCurrentAnimatorStateInfo(0).length;
        float temp = 1;
        Debug.Log(temp);
        yield return new WaitForSeconds(temp);
        attacking = false;
    }
    protected IEnumerator ResetAttSpree()
    {
        yield return new WaitForSeconds(resetSpreeTimer);
        attSpree = 0;
        Debug.Log("Spree reset");
    }
    protected abstract void SetTargetTag();
}