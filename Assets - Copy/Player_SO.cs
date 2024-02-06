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
}
