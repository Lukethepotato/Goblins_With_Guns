using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandAnimationMan : MonoBehaviour
{
    public BulletFiring bulletFireScript;
    public AnimationManager animMan;
    public GameObject player;
    public bool charging = false;
    public bool chargePlayed = false;
    public float chargedAnimTime;
    // Start is called before the first frame update
    void Start()
    {
        animMan = gameObject.GetComponent<AnimationManager>();
        bulletFireScript = player.GetComponent<BulletFiring>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulletFireScript.spellOut)
        {
            charging = true;
            if (bulletFireScript.spellCharged == false)
            {
                animMan.ChangeAnimationState("WandCharge");
            }
            else if (chargePlayed== false)
            {
                StartCoroutine(Charged());
                chargePlayed = true;
            }
        }else if (bulletFireScript.spellOut == false && charging)
        {
            StartCoroutine(Fire());
            charging = false;
            chargePlayed = false;
        }
    }

    IEnumerator Fire()
    {
        animMan.ChangeAnimationState("WandFire");
        yield return new WaitForSeconds(.4f);
        animMan.ChangeAnimationState("WandIdle");
    }

    IEnumerator Charged()
    {
        animMan.ChangeAnimationState("WandCharged");
        yield return new WaitForSeconds(chargedAnimTime);
        animMan.ChangeAnimationState("WandMax");
    }
    
}
