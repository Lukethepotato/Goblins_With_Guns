using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Healing : MonoBehaviour
{
    public float healTime = 7.5f;
    public Player_SO[] playSO;
    public PlayerInput playerInput;
    public float runTimeHeal;
    public bool held = false;
    public float unHoldDelay;
    public MainSO mainSO;
    public float startUpTime;
    AnimationManager animMan;
    public GameObject effects;
    public AnimationManager effectAnimMan;
    public bool down = false;
    public float downTime;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = gameObject.GetComponent<PlayerInput>();
        unHoldDelay = healTime;
        animMan = gameObject.GetComponent<AnimationManager>();
        effectAnimMan = effects.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (mainSO.setUpOver && mainSO.suddenDeathInitiated == false)
        {
            if (held && down == false)
            {
                runTimeHeal -= Time.deltaTime;
            }
            else
            {
                runTimeHeal = healTime;

            }

            if (runTimeHeal < 0)
            {
                StartCoroutine(DownTime());
                playSO[playerInput.playerIndex].health += 50;
                playSO[playerInput.playerIndex].freeze = false;
                StartCoroutine(HealAnimation());
            }

            if (playSO[playerInput.playerIndex].perkOwned == 4 && down == false)
            {
                if (playSO[playerInput.playerIndex].perkButPressed && held == false)
                {
                    held = true;
                    playSO[playerInput.playerIndex].freeze = true;
                    print("start");
                    StartCoroutine(Animation());
                }
                if (playSO[playerInput.playerIndex].perkButPressed == false && held)
                {
                    held = false;
                    StartCoroutine(UnHold());
                    print("end");
                    playSO[playerInput.playerIndex].freeze = false;
                }
            }
        }
    }

    IEnumerator UnHold()
    {
        StartCoroutine(DownTime());
        StopCoroutine(Animation());
        yield return new WaitForSeconds(unHoldDelay);
    }

    IEnumerator Animation()
    {
        playSO[playerInput.playerIndex].moveAnimsPlayable = false;
        animMan.ChangeAnimationState("VampMuntStart");
        //MuntStartSFX
        GameObject.Find("PlayerSFX_" + playerInput.playerIndex.ToString()).GetComponent<AudioManager>().Play("MuntStartFX");
        yield return new WaitForSeconds(startUpTime);
        animMan.ChangeAnimationState("VampMuntAnim");
        GameObject.Find("PlayerSFX_" + playerInput.playerIndex.ToString()).GetComponent<AudioManager>().Play("MuntFX");
    }

    IEnumerator HealAnimation()
    {
        GameObject.Find("PlayerSFX").GetComponent<AudioManager>().PlayOneShot("HealSFX");
        effectAnimMan.ChangeAnimationState("Effects_Heal");
        yield return new WaitForSeconds(.59f);
        effectAnimMan.ChangeAnimationState("Effects_Idle");
    }

    
    IEnumerator DownTime()
    {
        GameObject.Find("PlayerSFX_" + playerInput.playerIndex.ToString()).GetComponent<AudioManager>().StopPlaying("MuntFX");
        GameObject.Find("PlayerSFX_" + playerInput.playerIndex.ToString()).GetComponent<AudioManager>().StopPlaying("MuntStartFX");
        playSO[playerInput.playerIndex].moveAnimsPlayable = true;
        down = true;
        yield return new WaitForSeconds(downTime);
        down = false;
    }
    
}
