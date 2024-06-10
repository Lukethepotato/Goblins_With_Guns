using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public Gun_Stats bloodRage;
    private int OGChamberSize;
    private float OGReloadTime;
    private float OGBulletSpeed;
    private float OGFireRate;
    private float OGDamage;

    private int superOGChamberSize;
    private float superOGReloadTime;
    private float superOGBulletSpeed;
    private float superOGFireRate;
    public bool[] gunsPerkified;

    // Start is called before the first frame update
    void Start()
    {
        playInput = parent.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyPerkGunStats(bool refresh)
    {
        int perkNum = playSO[playInput.playerIndex].perkOwned;
        OGvalueSetting = guns[playSO[playInput.playerIndex].gunChosen].GetComponent<Gun_Value_Setting>();
        if (refresh == false)
        {
            gunsPerkified[playSO[playInput.playerIndex].gunChosen] = true;
            superOGChamberSize = OGvalueSetting.ChamberSize;
            superOGReloadTime = OGvalueSetting.ReloadTime;
            superOGBulletSpeed = OGvalueSetting.bulletSpeed;
            superOGFireRate = OGvalueSetting.timeInBetweenShots;

            // SuperOG stats are gun stats before perk stuff applied

            OGvalueSetting.ChamberSize *= gunStats[perkNum].chamberSizeMult;
            OGvalueSetting.ChamberSize += gunStats[perkNum].chamberSizeAdd;
            OGvalueSetting.ReloadTime *= gunStats[perkNum].reloadTimeMult;
            OGvalueSetting.bulletSpeed *= gunStats[perkNum].fireForceMult;
            OGvalueSetting.timeInBetweenShots *= gunStats[perkNum].fireRateMult;
            playSO[playInput.playerIndex].damageDealtMult = gunStats[perkNum].damageMult;

            OGChamberSize = OGvalueSetting.ChamberSize;
            OGReloadTime = OGvalueSetting.ReloadTime;
            OGBulletSpeed = OGvalueSetting.bulletSpeed;
            OGFireRate = OGvalueSetting.timeInBetweenShots;

            // OG stats before after perk stuff applied

            playSO[playInput.playerIndex].bulletsInChamber = OGvalueSetting.ChamberSize;
        }
        else
        {
            if (playSO[playInput.playerIndex].bloodRaged == false)
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
                OGvalueSetting.ChamberSize = superOGChamberSize * bloodRage.chamberSizeMult;
                //OGvalueSetting.ChamberSize += bloodRage.chamberSizeAdd;
                OGvalueSetting.ReloadTime = superOGReloadTime * bloodRage.reloadTimeMult;
                OGvalueSetting.bulletSpeed = superOGBulletSpeed * bloodRage.fireForceMult;
                OGvalueSetting.timeInBetweenShots = superOGFireRate * bloodRage.fireRateMult;

                playSO[playInput.playerIndex].bulletsInChamber = OGvalueSetting.ChamberSize;
                playSO[playInput.playerIndex].damageDealtMult = bloodRage.damageMult;
                print("BloodRageStats");
            }
        }
    }
}
