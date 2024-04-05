using Photon.Pun.Demo.PunBasics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainSO_Manager : MonoBehaviour
{
    public MainSO mainSO;
    public PlayerInputManager playerManager;
    public GameObject playMan;
    private bool rockMulted = false;
    public float baseRockMult;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = playMan.GetComponent<PlayerInputManager>();
        mainSO.playersDead = 0;
        mainSO.winner = 0;
        mainSO.gameIsOver= false;
        mainSO.setUpOver = false;
        mainSO.playersReadiedUp = 0;
        mainSO.rematchSelected= false;
        mainSO.turretHealth = 150;
        mainSO.suddenDeathInitiated= false;
        mainSO.freezeAllPlayer = false;
        mainSO.turretHealth = mainSO.startingTurretHealth;
        mainSO.rockMulptChange = baseRockMult;
        mainSO.inSuddenDeath= false;
        mainSO.playerInLightning= false;
        mainSO.gamePaused = false;
        

        //mainSO.rockMulptChange /= playerManager.playerCount;
    }

    private void Awake()
    {
        mainSO.preGameSetUp = false;
        mainSO.map = 0;
        mainSO.inHalfTime = false;
        mainSO.displayHalfTimeInput= false;
        mainSO.chosenTrivia = null;
        mainSO.halfTimeCount= 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.setUpOver && rockMulted == false)
        {
            mainSO.rockMulptChange /= playerManager.playerCount;
            rockMulted = true;
        }
    }
}
