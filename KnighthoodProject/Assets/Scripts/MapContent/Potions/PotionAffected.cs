using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionAffected : MonoBehaviour
{
    Effect effect;
    [SerializeField]
    float maxInterval;
    float currInterval;
    // Start is called before the first frame update
    void Start()
    {
        currInterval = maxInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if(effect != null)
        {
            if (effect.ttl > 0)
            {
                if (currInterval < 0)
                {
                    effect.DoYourThing();
                    effect.ttl--;
                    currInterval = maxInterval;
                }
                else
                    currInterval -= Time.deltaTime;
            }
        }
    }
    public void ChangeEffect(Effect effect)
    {
        this.effect = Instantiate(effect);
        this.effect.StartEffect(gameObject);
    }
}
