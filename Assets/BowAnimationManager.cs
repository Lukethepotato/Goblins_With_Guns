using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAnimationManager : MonoBehaviour
{
    AnimationManager animMan;
    public BulletFiring bulletFiring;
    // Start is called before the first frame update
    void Start()
    {
        bulletFiring = GetComponentInParent<BulletFiring>();
        animMan= gameObject.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletFiring.chargingBow)
        {
            animMan.ChangeAnimationState("Bow_Charge");
        }else if (bulletFiring.firingBullet)
        {
            animMan.ChangeAnimationState("Bow_Fire");
        }
        else
        {
            animMan.ChangeAnimationState("Bow_Idle");
        }

    }
}
