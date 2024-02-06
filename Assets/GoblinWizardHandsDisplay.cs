using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinWizardHandsDisplay : MonoBehaviour
{
    public GameObject pannel;
    public AnimationManager animMan;
    public LightingHandsSR handsSR;
    public MainSO mainSO;
    private bool startUpAnimationPlayed;
    public float startUpTime;
    public float fireTime;
    // Start is called before the first frame update
    void Start()
    {
        animMan = pannel.GetComponent<AnimationManager>();
        pannel.SetActive(false);
        handsSR.LightingFireIntiated = false;
        handsSR.playerGoneWizard = false;
        handsSR.startUpAnimationPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.rematchSelected)
        {
            handsSR.startUpAnimationPlayed = false;
        }

        if (handsSR.playerGoneWizard && handsSR.LightingFireIntiated == false && handsSR.startUpAnimationPlayed == false)
        {
            handsSR.startUpAnimationPlayed = true;
            pannel.SetActive(true);
            StartCoroutine(handsStartUp());
        }
        else if (handsSR.LightingFireIntiated)
        {
            StartCoroutine(handsFire());
        }
        else if (handsSR.playerGoneWizard == false)
        {
            pannel.SetActive(false);
        }
    }

    IEnumerator handsStartUp()
    {
        animMan.ChangeAnimationState("HandsStartUp");
        yield return new WaitForSeconds(startUpTime);
        animMan.ChangeAnimationState("HandsIdle");
    }

    IEnumerator handsFire()
    {
        animMan.ChangeAnimationState("HandsFire");
        yield return new WaitForSeconds(fireTime);
        animMan.ChangeAnimationState("HandsIdle");
    }
}
