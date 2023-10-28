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
    protected bool attReady = true;
    protected string targetTag;

    //Animace �tok�
    [SerializeField]
    protected int maxAttSpree;
    protected int attSpree = 0;
    [SerializeField]
    protected float resetSpreeTimer;
    Coroutine AttSpreeResetCoroutine = null;

    //Blokov�n�
    protected Character dude;
    [SerializeField]
    float blockCost;

    protected void Start()
    {
        CreateAttacks();
        dude = GetComponentInParent<Character>();
        dude.blockCost = blockCost;
        anim = GetComponentInParent<Animator>();
        anim.runtimeAnimatorController = animCon;
        SetTargetTag();
    }

    protected void Update()
    {
        ProcessInputs();
        MoveThroughQueue();
    }

    protected abstract void CreateAttacks(); //Ka�d� zbra� si to ud�l� sama
    protected abstract void ProcessInputs(); //Za��d� t��dy PlayerWeapon a HostileWeapon nebo jak je pojmenuju
    protected void MoveThroughQueue()
    {
        if(attackQueue.Count > 0 && attReady)
        {
            Debug.Log($"Attacks in queue: {attackQueue.Count}");
            ExecuteAttacks(attackQueue.Dequeue());
        }
    }
    protected void ExecuteAttacks(Attack Att)
    {
        attReady = false;
        attacking = true;
        currAtt = Att;
        AnimateAttacks(Att);
        StartCoroutine(ResetAttReady());
        StartCoroutine(ResetAttacking());
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
        anim.SetBool("AAIQ", true); //AAIQ == Are (there) Attacks In Queue (p�vodn� m�l fungovat jinak, ale to ned�lalo co jsem cht�l [ne �e by tohle d�lalo])

        if (attSpree == maxAttSpree)
            attSpree = 0;
        else
            AttSpreeResetCoroutine = StartCoroutine(ResetAttSpree());
        Debug.Log($"Current state: {anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")}");
    }
    protected IEnumerator ResetAttReady()
    {
        //float temp = anim.GetCurrentAnimatorStateInfo(0).length;
        //Debug.Log($"temp == {temp}");
        float temp = 1;
        yield return new WaitForSeconds(temp);
        attReady = true;
        anim.SetBool("AAIQ", false);
    }
    protected IEnumerator ResetAttacking() 
    {
        //float temp = anim.GetCurrentAnimatorStateInfo(0).length;
        float temp = 1;
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
    }
}