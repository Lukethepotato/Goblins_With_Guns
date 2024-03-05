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
    // Start is called before the first frame update
    void Start()
    {
        playerInput = gameObject.GetComponent<PlayerInput>();
        unHoldDelay = healTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.setUpOver && mainSO.suddenDeathInitiated == false)
        {
            if (held)
            {
                runTimeHeal -= Time.deltaTime;
            }
            else
            {
                runTimeHeal = healTime;

            }

            if (runTimeHeal < 0)
            {
                playSO[playerInput.playerIndex].health += 50;
                playSO[playerInput.playerIndex].freeze = false;
                held = false;
            }

            if (playSO[playerInput.playerIndex].perkOwned == 4)
            {
                if (playSO[playerInput.playerIndex].perkButPressed && held == false)
                {
                    held = true;
                    playSO[playerInput.playerIndex].freeze = true;
                    print("start");
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
        yield return new WaitForSeconds(unHoldDelay);
        playSO[playerInput.playerIndex].freeze = false;
    }
}
