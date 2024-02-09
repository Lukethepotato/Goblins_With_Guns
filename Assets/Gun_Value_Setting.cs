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
    private bool gate2 = false;
    private bool gate3 = false;
    public bool remoSpeedDe = false;
    public bool contstantFireSpeedUpdate = false;
    private bool nonOriganalGun = false;
    public bool isTurret = false;
    // Start is called before the first frame update
    void Start()
    {
        playInput = GetComponentInParent<PlayerInput>();
        oldGun = playSO[playInput.playerIndex].gunChosen;
        gate = false;
        gate2 = false; 
        gate3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.setUpOver)
        {
            if (gate2 == false)
            {
                playSO[playInput.playerIndex].orinagalChamberSize = ChamberSize;
                playSO[playInput.playerIndex].orinagalReloadSpeed = ReloadTime;
                gate2 = true;
            }


            if (playSO[playInput.playerIndex].perkOwned == 8 && gate == false)
            {
                ChamberSize *= mainSO.megaBulletsToAdd;
                ReloadTime *= mainSO.megaBulletsReloadAdd;
                playSO[playInput.playerIndex].bulletsInChamber = ChamberSize;
                gate = true;
            } else if (playSO[playInput.playerIndex].perkOwned == 1 && gate == false)
            {
                bulletSpeed *= .5f;
                gate = true;
            }

            playSO[playInput.playerIndex].timeBetweenShots = timeInBetweenShots;
            if (gate3 == false)
            {
                playSO[playInput.playerIndex].fireForece = bulletSpeed;
                playSO[playInput.playerIndex].bulletReloadTime = ReloadTime;
                playSO[playInput.playerIndex].magazineSize = ChamberSize;
                playSO[playInput.playerIndex].BulletSpread = bulletSpreadMinMax;
                playSO[playInput.playerIndex].recoilGun = recoil;
                playSO[playInput.playerIndex].revUpTime = revupTime;

                if (playSO[playInput.playerIndex].perkOwned == 6)
                {
                    playSO[playInput.playerIndex].recoilPower = superRecoilPower;
                }
                else
                {
                    playSO[playInput.playerIndex].recoilPower = recoilPower;
                }
                gate3 = true;
            }

            if (contstantFireSpeedUpdate)
            {
                playSO[playInput.playerIndex].fireForece = bulletSpeed;
            }


            //StatsSet= true;
            if (playSO[playInput.playerIndex].gunChosen == playSO[playInput.playerIndex].oringalGunChosen && playSO[playInput.playerIndex].fireForece != bulletSpeed)
            {
                gate = false;
                gate2= false;
                gate3= false;
            }

        }
        else
        {
            playSO[playInput.playerIndex].bulletsInChamber = ChamberSize;
        }

        if (playSO[playInput.playerIndex].gunChosen != oldGun)
        {
            oldGun = playSO[playInput.playerIndex].gunChosen;
            playSO[playInput.playerIndex].bulletsInChamber = ChamberSize;
            gate = false;
            gate2 = false;
            gate3 = false;
        }
    }
}
