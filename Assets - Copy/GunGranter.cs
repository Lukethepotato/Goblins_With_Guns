using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGranter : MonoBehaviour
{
    AnimationManager animManager;
    public bool disabled = false;
    public float timeToActivateAgain;
    private bool gate = false;
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        animManager = gameObject.GetComponent<AnimationManager>();
        animManager.ChangeAnimationState("GunGranter_Gunss");
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled && gate == false)
        {
            animManager.ChangeAnimationState("GunGranter_ShutOfff");
            print("GunGranterDisabled");
            gate = true;
            StartCoroutine(timeTillDisabled());
        } else if (disabled == false)
        {
            gate = false;
        }

        if (mainSO.rematchSelected)
        {
            disabled = false;
            animManager.ChangeAnimationState("GunGranter_Gunss");
        }
    }

    IEnumerator timeTillDisabled()
    {
        yield return new WaitForSeconds(timeToActivateAgain);
        animManager.ChangeAnimationState("GunGranter_Gunss");
        disabled = false;
    }
}
