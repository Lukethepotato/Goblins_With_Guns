using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SettingsTweeks: MonoBehaviour
{
    public MainSO mainSO;
    public int baseHealingDroneSpawnChance;
    public int baseHealingDroneLivesToAdd;
    public int baseStock;
    public float baseGameLength;
    public float baseSuddenDeathHealth;
    // Start is called before the first frame update
    void Start()
    {
        mainSO.healingDroneSpawnChance = baseHealingDroneSpawnChance;
        mainSO.healingDroneLivesToAdd = baseHealingDroneLivesToAdd;
        mainSO.stock = baseStock;
        mainSO.startingTimer = baseGameLength;
        mainSO.suddenDeathHealth = baseSuddenDeathHealth;
        mainSO.suddenDeathInitiated = false;

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void HealDroneSpawnChance(int chance)
    {
        mainSO.healingDroneSpawnChance = chance;
    }
    public void HealDroneLivesGiven(int lives)
    {
        mainSO.healingDroneLivesToAdd = lives;
    }

    public void StockTweaking(int lives)
    {
        mainSO.stock = lives;
    }

    public void GameLength(float length)
    {
        mainSO.startingTimer = length;
    }

    public void PlayIntro(bool chosen)
    {
        mainSO.playStartUpMov = chosen;
    }
}
