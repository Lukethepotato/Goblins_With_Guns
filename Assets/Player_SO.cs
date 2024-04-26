using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "PlayerScriptableObjects")]
public class Player_SO : ScriptableObject
{
    public float health = 100;

    public float fireForece;
    public float timeBetweenShots;
    public int magazineSize;
    public float bulletReloadTime;
    public int bulletsInChamber;
    public int letterIn;
    public Vector2 moveInput;
    public Vector2 Aim;
    public int livesLeft;
    public bool touchingSewage;
    public bool isTurret;
    public Color oringalColor;
    public bool turretDisabled;
    public bool burning;
    public float movementSpeed;
    public int magicBooksHeld;
    public bool canMove;
    public float fatigue;
    public bool telaporting;
    public bool buff;
    public int state;
    public int direction;
    public bool firing;
    public int money;
    public bool wheelActivate;
    public bool freeze;
    public bool joyStickDown;
    public bool inGame;

    public string playerName = "player1";
    public int playerIndex = 0;
    public int gunChosen;
    public int oringalGunChosen;
    public bool hasDied = false;
    public bool rolling;
    public bool invincble;
    public bool isReloading;
    public bool isGamePad;
    public bool rematchSetUpComplete;
    public bool lightingGoblin;
    public bool[] perks;
    public int perkOwned;
    public int rocksCollected;
    public float magicRockMult;
    public bool inRollState;
    public bool recoilGun;
    public float recoilPower;
    public float revUpTime;
    public Vector2 BulletSpread;
    public Vector2 ActiveMoveInput;
    public float damageDealtMult;
    public float damageTakeMult;
    public int orinagalChamberSize;
    public float orinagalReloadSpeed;
    public bool respawning;
    public bool resetGunStats;
    public bool perkButPressed;
    public bool bloodRaged;
    public float basePlayerSpeed;
}
