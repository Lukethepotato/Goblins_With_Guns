using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MainSO", menuName = "MainScriptableObject")]

public class MainSO : ScriptableObject
{
    public int playersDead;
    public bool gameIsOver = false;
    public int winner;
    public int playersReadiedUp;
    public bool setUpOver;
    public Vector2[] playersSpawnLocations;
    public Vector3[] playerBoxLocations;
    public Vector2[] playerSuddenDeathSpawnLocations;
    public bool rematchSelected;
    public int stock;
    public int turretHealth;
    public int map;
    public int healingDroneLivesToAdd;
    public int healingDroneSpawnChance;
    public float startingTimer;
    public float currentTimer;
    public bool suddenDeathInitiated;
    public float suddenDeathHealth;
    public int suddenDeathLives;
    public bool freezeAllPlayer;
    public float baseMoveSpeed;
}
