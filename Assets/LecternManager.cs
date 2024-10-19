using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LecternManager : MonoBehaviour
{
    AnimationManager animMan;
    public LightingHandsSR handsSR;
    public float animTime;
    public Collider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        animMan = gameObject.GetComponent<AnimationManager>();
        animMan.ChangeAnimationState("LecternIdle");
        coll= gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (handsSR.playerGoneWizard == false)
        {
            coll.enabled = true;
        }
        else
        {
            coll.enabled = false;
        }
    }

    public void lecternActivate()
    {
        StartCoroutine(LecternActivation());
    }

    IEnumerator LecternActivation()
    {
        //LightningAsecsion
        GameObject.Find("PlayerSFX").GetComponent<AudioManager>().Play("LightningAsecsion");
        animMan.ChangeAnimationState("LecternActivate");
        yield return new WaitForSeconds(animTime);
        animMan.ChangeAnimationState("LecternIdle");
    }
}
