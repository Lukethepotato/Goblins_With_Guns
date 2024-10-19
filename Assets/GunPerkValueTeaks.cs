using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class GunPerkValueTeaks : MonoBehaviour
{
    //pneumonoultramicroscopicsilicovolcanoconiosis
    public Gun_Stats[] gunStats;
    public GameObject parent;
    PlayerInput playInput;
    Gun_Value_Setting OGvalueSetting;
    public Player_SO[] playSO;
    public MainSO mainSO;
    public GameObject[] guns;
    private int OGChamberSize;
    private float OGReloadTime;
    private float OGBulletSpeed;
    private float OGFireRate;
    private float OGDamage;

    public Gun_Stats bloodRage;
    public Gun_Stats gunAbstineceStat;
    private int superOGChamberSize;
    private float superOGReloadTime;
    private float superOGBulletSpeed;
    private float superOGFireRate;
    public bool[] gunsPerkified;

    public int BR_ChamberSize;
    public float BR_ReloadTime;
    public float BR_FireRate;
    public float BR_DamageMult;
    public float BR_FireForce;
    //BR = Blood Rage

    public int Ab_ChamberSize;
    public float Ab_ReloadTime;
    public float Ab_FireRate;
    public float Ab_DamageMult;
    public float Ab_FireForce;
    //Ab = abstenicse 

    // Start is called before the first frame update
    void Start()
    {
        playInput = parent.GetComponent<PlayerInput>();
        /*
        ApplyPerkGunStats(false);
        playSO[playInput.playerIndex].resetGunStats = true;
        playSO[playInput.playerIndex].resetGunStats = false;
        */

    }

    public void ApplyPerkGunStats(bool refresh)
    {
        int perkNum = playSO[playInput.playerIndex].perkOwned;
        OGvalueSetting = guns[playSO[playInput.playerIndex].gunChosen].GetComponent<Gun_Value_Setting>();
        if (refresh == false)
        {
            superOGChamberSize = OGvalueSetting.ChamberSize;
            superOGReloadTime = OGvalueSetting.ReloadTime;
            superOGBulletSpeed = OGvalueSetting.bulletSpeed;
            superOGFireRate = OGvalueSetting.timeInBetweenShots;

            if (playSO[playInput.playerIndex].perkOwned != 11)
            {
                OGChamberSize = OGvalueSetting.ChamberSize;
                OGReloadTime = OGvalueSetting.ReloadTime;
                OGBulletSpeed = OGvalueSetting.bulletSpeed;
                OGFireRate = OGvalueSetting.timeInBetweenShots;
                // SuperOG stats are gun stats before perk stuff applied\

                OGvalueSetting.ChamberSize *= gunStats[perkNum].chamberSizeMult;
                OGvalueSetting.ChamberSize += gunStats[perkNum].chamberSizeAdd;
                OGvalueSetting.ReloadTime *= gunStats[perkNum].reloadTimeMult;
                OGvalueSetting.bulletSpeed *= gunStats[perkNum].fireForceMult;
                OGvalueSetting.timeInBetweenShots *= gunStats[perkNum].fireRateMult;
                playSO[playInput.playerIndex].damageDealtMult = gunStats[perkNum].damageMult;


                // OG stats before after perk stuff applied

                playSO[playInput.playerIndex].bulletsInChamber = OGvalueSetting.ChamberSize;
            }
            else
            {
                BR_ChamberSize = OGvalueSetting.ChamberSize * bloodRage.chamberSizeMult;
                BR_ReloadTime = OGvalueSetting.ReloadTime * bloodRage.reloadTimeMult;
                BR_FireRate = OGvalueSetting.timeInBetweenShots * bloodRage.fireRateMult;
                BR_FireForce = OGvalueSetting.bulletSpeed * bloodRage.fireForceMult;

                Ab_ChamberSize = OGvalueSetting.ChamberSize / gunAbstineceStat.chamberSizeMult;
                Ab_ReloadTime = OGvalueSetting.ReloadTime * gunAbstineceStat.reloadTimeMult;
                Ab_FireRate = OGvalueSetting.timeInBetweenShots * gunAbstineceStat.fireRateMult;
                Ab_FireForce = OGvalueSetting.bulletSpeed * gunAbstineceStat.fireForceMult;

                if (playSO[playInput.playerIndex].bloodRaged == false)
                {
                    OGvalueSetting.ChamberSize = Ab_ChamberSize;
                    OGvalueSetting.bulletSpeed = Ab_FireForce;
                    OGvalueSetting.timeInBetweenShots = Ab_FireRate;
                    OGvalueSetting.ReloadTime = Ab_ReloadTime;
                    playSO[playInput.playerIndex].damageDealtMult = gunAbstineceStat.damageMult;
                    playSO[playInput.playerIndex].bulletsInChamber = Ab_ChamberSize;
                }
                else
                {
                    OGvalueSetting.ChamberSize = BR_ChamberSize;
                    OGvalueSetting.bulletSpeed = BR_FireForce;
                    OGvalueSetting.timeInBetweenShots = BR_FireRate;
                    OGvalueSetting.ReloadTime = BR_ReloadTime;
                    playSO[playInput.playerIndex].damageDealtMult = bloodRage.damageMult;
                    playSO[playInput.playerIndex].bulletsInChamber = BR_ChamberSize;
                }
            }

        }
        else
        {
            if (playSO[playInput.playerIndex].perkOwned != 11)
            {
                OGvalueSetting.ChamberSize = OGChamberSize;
                OGvalueSetting.bulletSpeed = OGBulletSpeed;
                OGvalueSetting.timeInBetweenShots = OGFireRate;
                OGvalueSetting.ReloadTime = OGReloadTime;
                playSO[playInput.playerIndex].damageDealtMult = gunStats[perkNum].damageMult;
                playSO[playInput.playerIndex].bulletsInChamber = OGvalueSetting.ChamberSize;
            }
            else
            {
                if (playSO[playInput.playerIndex].bloodRaged)
                {
                    playSO[playInput.playerIndex].bulletsInChamber = BR_ChamberSize;
                }
                else
                {
                    playSO[playInput.playerIndex].bulletsInChamber = Ab_ChamberSize;
                }
            }
        }
    }

    // use this class anytime before switching guns (so the perk stats can be applied to the base gun and not an already altered one)
    public void SetGunsBackToNormal()
    {
        OGvalueSetting.ChamberSize = superOGChamberSize;
        OGvalueSetting.ReloadTime = superOGReloadTime;
        OGvalueSetting.bulletSpeed = superOGBulletSpeed;
        OGvalueSetting.timeInBetweenShots = superOGFireRate;
    }

    void Update()
    {
        if (playSO[playInput.playerIndex].perkOwned == 11 && playSO[playInput.playerIndex].gunChosen != 6 && mainSO.setUpOver)
        {
            if (playSO[playInput.playerIndex].bloodRaged && playSO[playInput.playerIndex].health > 0  )
            {
                OGvalueSetting.ChamberSize = BR_ChamberSize;
                OGvalueSetting.bulletSpeed = BR_FireForce;
                if (playSO[playInput.playerIndex].gunChosen != 9)
                {
                    OGvalueSetting.timeInBetweenShots = BR_FireRate;
                }
                OGvalueSetting.ReloadTime = BR_ReloadTime;
                playSO[playInput.playerIndex].damageDealtMult = bloodRage.damageMult;
            }
            else if (playSO[playInput.playerIndex].health > 0)
            {
                OGvalueSetting.ChamberSize = Ab_ChamberSize;
                OGvalueSetting.bulletSpeed = Ab_FireForce;
                OGvalueSetting.timeInBetweenShots = Ab_FireRate;
                OGvalueSetting.ReloadTime = Ab_ReloadTime;
                playSO[playInput.playerIndex].damageDealtMult = gunAbstineceStat.damageMult;
            }
            else
            {
                OGvalueSetting.ChamberSize = superOGChamberSize;
                OGvalueSetting.bulletSpeed = superOGBulletSpeed;
                OGvalueSetting.timeInBetweenShots = superOGFireRate;
                OGvalueSetting.ReloadTime = superOGReloadTime;
                playSO[playInput.playerIndex].damageDealtMult = 1;
            }
        }
    }
}
