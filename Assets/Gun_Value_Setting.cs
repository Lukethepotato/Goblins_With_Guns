using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun_Value_Setting : MonoBehaviour
{
    public Player_SO[] playSO;
    public PlayerInput playInput;

    public float bulletSpeed;
    public float OGTimeBetweenShots;
    public float ReloadTime;
    public int ChamberSize;
    public float timeInBetweenShots;
    public bool recoil;
    public float superRecoilPower;
    public float recoilPower;
    public MainSO mainSO;
    private bool turretGate = false;
    public Gun_Stats gunStats;
    public bool baseGun = false;
    public Vector2 bulletSpreadMinMax;
    private bool StatsSet = false;
    private int oldGun;
    public float revupTime;
    private bool gate = false;
    private bool startSetting = false;
    private bool valueSetting = false;
    public bool remoSpeedDe = false;
    public bool contstantFireSpeedUpdate = false;
    private bool nonOriganalGun = false;
    public bool isTurret = false;
    public GunPerkValueTeaks perkValTweaks;
    public bool parentAnimControl = true;
    public bool automaticAnim = false;
    public bool casinoWeapon = false;

    private void Awake()
    {
        OGTimeBetweenShots = timeInBetweenShots;
    }
    // Start is called before the first frame update
    void Start()
    {
        playInput = GetComponentInParent<PlayerInput>();
        oldGun = playSO[playInput.playerIndex].gunChosen;
        gate = false;
        startSetting = false; 
        valueSetting = false;
        perkValTweaks = GetComponentInParent<GunPerkValueTeaks>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.setUpOver)
        {
            if (startSetting == false)
            {
                playSO[playInput.playerIndex].orinagalChamberSize = ChamberSize;
                playSO[playInput.playerIndex].orinagalReloadSpeed = ReloadTime;
                /*
                if (playSO[playInput.playerIndex].perkOwned == 8)
                {
                    ChamberSize *= mainSO.megaBulletsToAdd;
                    ReloadTime *= mainSO.megaBulletsReloadAdd;
                    playSO[playInput.playerIndex].bulletsInChamber = ChamberSize;
                }
                else if (playSO[playInput.playerIndex].perkOwned == 1)
                {
                    bulletSpeed *= .5f;
                }else if (playSO[playInput.playerIndex].perkOwned == 11)
                {
                    
                }
                */

                startSetting = true;

                perkValTweaks.ApplyPerkGunStats(false);
            }

            playSO[playInput.playerIndex].timeBetweenShots = timeInBetweenShots;

                playSO[playInput.playerIndex].fireForece = bulletSpeed;
                playSO[playInput.playerIndex].bulletReloadTime = ReloadTime;
                playSO[playInput.playerIndex].magazineSize = ChamberSize;
                playSO[playInput.playerIndex].BulletSpread = bulletSpreadMinMax;
                playSO[playInput.playerIndex].recoilGun = recoil;
                playSO[playInput.playerIndex].revUpTime = revupTime;

                if (playSO[playInput.playerIndex].perkOwned == 6)
                {
                    playSO[playInput.playerIndex].recoilPower = (superRecoilPower / 1.5f);
                }
                else
                {
                    playSO[playInput.playerIndex].recoilPower = recoilPower;
                }

                valueSetting = true;

                playSO[playInput.playerIndex].fireForece = bulletSpeed;


        }
        else
        {
            playSO[playInput.playerIndex].bulletsInChamber = ChamberSize;
        }

        if (playSO[playInput.playerIndex].gunChosen != oldGun || mainSO.suddenDeathInitiated || playSO[playInput.playerIndex].respawning || playSO[playInput.playerIndex].resetGunStats)
        {
            oldGun = playSO[playInput.playerIndex].gunChosen;
            playSO[playInput.playerIndex].bulletsInChamber = ChamberSize;
            playSO[playInput.playerIndex].resetGunStats= false;
            valueSetting = false;
        }
    }
}
