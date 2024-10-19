using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandExplosionDamage : MonoBehaviour
{
    public AnimationManager animMan;
    public float damage;
    public float timeBeforeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
        animMan = gameObject.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Destroy()
    {
        GameObject.Find("SFX").GetComponent<AudioManager>().Play("MagicExplosion");
        animMan.ChangeAnimationState("WandExplosionStart");
        yield return new WaitForSeconds(.2f);
        animMan.ChangeAnimationState("WandExplosion");
        yield return new WaitForSeconds(timeBeforeDestroy - .6f);
        animMan.ChangeAnimationState("WandExplosionEnd");
        yield return new WaitForSeconds(.2f);
        Destroy(gameObject);
    }
}
