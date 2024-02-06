using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelBasedPlayerUI : MonoBehaviour
{
    public PlayerInputManager playerManager;
    public GameObject playerMan;
    public GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = playerMan.GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I < playerManager.playerCount; I++)
        {
            players[I].SetActive(true);
        }
    }
}
