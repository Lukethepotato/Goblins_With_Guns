using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSO_Manager : MonoBehaviour
{
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        mainSO.playersDead = 0;
        mainSO.winner = 0;
        mainSO.gameIsOver= false;
        mainSO.setUpOver = false;
        mainSO.playersReadiedUp = 0;
        mainSO.rematchSelected= false;
        mainSO.turretHealth = 150;
        mainSO.suddenDeathInitiated= false;
        mainSO.freezeAllPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
