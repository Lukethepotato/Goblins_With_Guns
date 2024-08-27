using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasManager : MonoBehaviour
{
    public GameObject[] players;
    public PlayerInputManager playerManager;
    public MainSO mainSo;
    public GameObject suddenDeathEmpty;
    // Start is called before the first frame update
    void Start()
    {
        suddenDeathEmpty.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I < playerManager.playerCount; I++) 
        {
            players[I].SetActive(true);
        }

        if ((playerManager.playerCount - mainSo.playersDead == 1) && playerManager.playerCount != 1)
        {
            mainSo.gameIsOver = true;

            //mainSo.gamesPlayed++;
        }
    }
}
