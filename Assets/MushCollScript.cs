using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MushCollScript : MonoBehaviour
{
    public float timeBeforeBouce;
    public float animTime;
    public AnimationManager animMan;
    // Start is called before the first frame update
    void Start()
    {
        animMan = gameObject.GetComponent<AnimationManager>();
        animMan.ChangeAnimationState("None");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBunce()
    {
        StartCoroutine(Bounce());
    }

    IEnumerator Bounce()
    {
        GameObject.Find("SFX").GetComponent<AudioManager>().Play("MushroomBounce");
        //yield return new WaitForSeconds(timeBeforeBouce);
        animMan.ChangeAnimationState("MushroomAnim");
        yield return new WaitForSeconds(animTime);
        animMan.ChangeAnimationState("None");
    }
}
