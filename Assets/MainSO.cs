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
    public float turretHealth;
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
    public int startingCash;
    public float startingTurretHealth;
    public int perksAllowed;
    public float startingVampireHealth;
    public float rockMulptChange;
    public bool inSuddenDeath;
    public float reloadMoveSpeed;
    public List<int> rankings;
    public bool playerInLightning;
    public int bulletPlayerLess;
    public int megaBulletsToAdd;
    public float megaBulletsReloadAdd;
    public float bounceyBulletsDamMult;
    public int bounceyBulletBounceIncrease;
    public bool preGameSetUp;
    public float scoutHealth;
    public int maxWidowMult;
    public TriviaSO chosenTrivia;
    public bool inHalfTime;
    public bool displayHalfTimeInput;
    public int halfTimeCount;
    public int maxHalfTimes;
    public bool halfTimeEnabled;
    public Vector2[] wayPoints;
    public Vector2[] possibleLocas;
    public bool playStartUpMov;
    public bool inStartUpMov;
    public bool gamePaused;
    public float bloodRagedSpeed;
    public float lightingFireingSpeed;
    public bool preMapLoadAnim;
    //public float sentryRollPower;
}
