using Photon.Pun.Demo.Asteroids;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Http.Headers;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class BulletFiring : MonoBehaviour
{
    public GameObject[] bulletPrephab;
    public Transform[] firePoint;
    //public Rigidbody2D[] firePointRBs; 
    public Transform[] shotgunFirePoints;
    public Transform[] SMGFirePoints;
    public Player_SO[] playerSO;
    public PlayerInput playInput;
    public bool isFiringContinously;
    private bool canShoot = true;
    private float randomBulletSpread;
    Reloading reloadingScript;
    public bool firingBullet;
    public int boobs;
    InputActions inputActions = null;
    public bool chargingBow = false;
    public GameObject plunger;
    public Gun_Value_Setting plungerValueSetting;
    public float bowChargeSpeed;
    public float baseBowSpeed;
    public MainSO mainSO;
    public float shootMoveSpeed;
    public Gun_Value_Setting turretValueSetting;
    public Gun_Value_Setting smgValueSetting;
    public GameObject turret;
    public GameObject smg;
    public bool chargingTurret;
    public float baseSMGBulletSpead;
    public float SMGBulletChargeSpead;
    public float smgBulletTweenDamp;
    public float turretChargeSpeed;
    public float baseTurretBulletSpeed;
    public float turretBulletSpeedCharge;
    public float turretBulletSizeCharge;
    private float turretBulletSize;
    public bool charging = false;
    public float baseSmgSpeed;
    public float wandDamageChargeSpeed;
    public float wandExplosionSizeChargeSpeed;
    public bool spellOut = false;
    public GameObject spellBullet;
    public TurretAnimationManager turAnimMan;
    private bool ableShootCharge = false;
    public bool spellCharged = false;
    public float maxSpellDamage;
    public float pillTimeToExplode;
    private float startingPillToExplode;
    private bool startedCharging = false;
    public float recoilTime;
    public bool recoiling = false;
    public Rigidbody2D playerBody;
    public GameObject playerObject;
    private float revTimeLeft = 0;
    private float revAmount;
    public float minigunRevSpeed;
    private bool minigunBust = false;
    public int minTurretCharge = 37;

    // Start is called before the first frame update
    void Start()
    {
        playInput = GetComponentInParent<PlayerInput>();
        reloadingScript = gameObject.GetComponent<Reloading>();
        inputActions = new InputActions();
        plungerValueSetting = plunger.GetComponent<Gun_Value_Setting>();
        turretValueSetting = turret.GetComponent<Gun_Value_Setting> ();
        smgValueSetting = smg.GetComponent<Gun_Value_Setting>();
        turAnimMan = turret.GetComponent<TurretAnimationManager>();
        playerBody = GetComponentInParent<Rigidbody2D>();
        //firePointRBs = GetComponents<Rigidbody2D>();

        startingPillToExplode = pillTimeToExplode;
    }

    private void Update()
    {
        //randomBulletSpread = Random.Range(1 , 10);

        if (canShoot && playerSO[playInput.playerIndex].bulletsInChamber > 0 && playerSO[playInput.playerIndex].isReloading == false && playerSO[playInput.playerIndex].rolling == false && isFiringContinously && playerSO[playInput.playerIndex].gunChosen != 4)
        {
            StartCoroutine(Fire());
        }

        Charge();

        if (playerSO[playInput.playerIndex].isTurret == false)
        {
            turretValueSetting.bulletSpeed = baseTurretBulletSpeed;
            turretBulletSize = 0;
        }

        if (playerSO[playInput.playerIndex].gunChosen != 6)
        {
            plungerValueSetting.bulletSpeed = 15;
        }

        if (playerSO[playInput.playerIndex].gunChosen == 9 && charging && playerSO[playInput.playerIndex].bulletsInChamber > 0)
        {
            smgValueSetting.timeInBetweenShots -= (Time.deltaTime * smgBulletTweenDamp);
            smgValueSetting.bulletSpeed += (Time.deltaTime * SMGBulletChargeSpead);
            if (smgValueSetting.timeInBetweenShots < 0)
            {
                smgValueSetting.timeInBetweenShots = 0;
                
            }
        }
        else
        {
            smgValueSetting.timeInBetweenShots = baseSmgSpeed;
            smgValueSetting.bulletSpeed = baseSMGBulletSpead;
        }

        if (playerSO[playInput.playerIndex].gunChosen == 8 && charging && playerSO[playInput.playerIndex].bulletsInChamber >= 0)
        {
            spellOut = true;
            if (spellBullet != null && spellBullet.GetComponent<BulletExplosionMan>().exploDamage <= maxSpellDamage && spellCharged == false)
            {
                spellBullet.GetComponent<BulletExplosionMan>().exploDamage += wandDamageChargeSpeed * Time.deltaTime;
                spellBullet.GetComponent<BulletExplosionMan>().size.x += wandExplosionSizeChargeSpeed * Time.deltaTime;
                spellBullet.GetComponent<BulletExplosionMan>().size.y += wandExplosionSizeChargeSpeed * Time.deltaTime;
            }
            else if (spellBullet != null)
            {
                spellCharged = true;
            }
        }

        if (recoiling)
        {
            playerBody.AddForce(-firePoint[playerSO[playInput.playerIndex].gunChosen].transform.up.normalized * playerSO[playInput.playerIndex].recoilPower * Time.deltaTime, ForceMode2D.Force);
        }

        if (spellOut && charging == false)
        {
            if (spellBullet != null)
            {
                spellBullet.GetComponent<BulletExplosionMan>().Explode();
                spellBullet.GetComponent<Rigidbody2D>().drag = 100000;
                print("called");
            }
            spellBullet = null;
            spellCharged= false;
            spellOut = false;
        }

        if (spellOut && spellBullet == null)
        {
            spellOut = false;
            spellCharged= false;
        }

        if (isFiringContinously)
        {
            revTimeLeft -= Time.deltaTime;
        }
        else if (playerSO[playInput.playerIndex].gunChosen != 4)
        {
            revTimeLeft = playerSO[playInput.playerIndex].revUpTime;
        }

        if (isFiringContinously && playerSO[playInput.playerIndex].gunChosen == 4 && playerSO[playInput.playerIndex].rolling == false && playerSO[playInput.playerIndex].bulletsInChamber > 0)
        {
            revAmount += Time.deltaTime * minigunRevSpeed;
        }
        else if (playerSO[playInput.playerIndex].rolling == false && playerSO[playInput.playerIndex].gunChosen == 4 && playerSO[playInput.playerIndex].bulletsInChamber > 0 && revAmount > 0 && revTimeLeft < 0)
        {
            StartCoroutine(Fire());
            revAmount -= Time.deltaTime * minigunRevSpeed;
        }
        else
        {
            revAmount = 0;
            revTimeLeft = playerSO[playInput.playerIndex].revUpTime;
        }
    }

    public void FireBullet()
    {
        if (playerSO[playInput.playerIndex].gunChosen != 10)
        {
            GameObject bullet = Instantiate(bulletPrephab[playerSO[playInput.playerIndex].gunChosen], firePoint[playerSO[playInput.playerIndex].gunChosen].position, firePoint[playerSO[playInput.playerIndex].gunChosen].rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint[playerSO[playInput.playerIndex].gunChosen].up * playerSO[playInput.playerIndex].fireForece * playerSO[playInput.playerIndex].magicRockMult, ForceMode2D.Impulse);
            if (bullet.GetComponent<BulletData>() != null)
            {
                bullet.GetComponent<BulletData>().Asignment(playInput.playerIndex, playerSO[playInput.playerIndex].perkOwned, playerSO[playInput.playerIndex].magicRockMult);
            }


            if (playerSO[playInput.playerIndex].gunChosen == 8)
            {
                spellBullet = bullet;
            }
            playerSO[playInput.playerIndex].firing = firingBullet;
            playerSO[playInput.playerIndex].firing = true;
        }
    }

    public void ShotgunFire()
    {
        GameObject bullet1 = Instantiate(bulletPrephab[1], shotgunFirePoints[0].position, shotgunFirePoints[0].rotation);
        bullet1.GetComponent<Rigidbody2D>().AddForce(shotgunFirePoints[0].up * playerSO[playInput.playerIndex].fireForece * playerSO[playInput.playerIndex].magicRockMult, ForceMode2D.Impulse);
        bullet1.GetComponent<BulletData>().Asignment(playInput.playerIndex, playerSO[playInput.playerIndex].perkOwned, playerSO[playInput.playerIndex].magicRockMult);

        GameObject bullet2 = Instantiate(bulletPrephab[1], shotgunFirePoints[1].position, shotgunFirePoints[1].rotation);
        bullet2.GetComponent<Rigidbody2D>().AddForce(shotgunFirePoints[1].up * playerSO[playInput.playerIndex].fireForece * playerSO[playInput.playerIndex].magicRockMult, ForceMode2D.Impulse);
        bullet2.GetComponent<BulletData>().Asignment(playInput.playerIndex, playerSO[playInput.playerIndex].perkOwned, playerSO[playInput.playerIndex].magicRockMult);

        GameObject bullet3 = Instantiate(bulletPrephab[1], shotgunFirePoints[2].position, shotgunFirePoints[2].rotation);
        bullet3.GetComponent<Rigidbody2D>().AddForce(shotgunFirePoints[2].up * playerSO[playInput.playerIndex].fireForece * playerSO[playInput.playerIndex].magicRockMult, ForceMode2D.Impulse);
        bullet3.GetComponent<BulletData>().Asignment(playInput.playerIndex, playerSO[playInput.playerIndex].perkOwned, playerSO[playInput.playerIndex].magicRockMult);

        GameObject bullet4 = Instantiate(bulletPrephab[1], shotgunFirePoints[3].position, shotgunFirePoints[3].rotation);
        bullet4.GetComponent<Rigidbody2D>().AddForce(shotgunFirePoints[3].up * playerSO[playInput.playerIndex].fireForece * playerSO[playInput.playerIndex].magicRockMult, ForceMode2D.Impulse);
        bullet4.GetComponent<BulletData>().Asignment(playInput.playerIndex, playerSO[playInput.playerIndex].perkOwned, playerSO[playInput.playerIndex].magicRockMult);
        playerSO[playInput.playerIndex].firing = true;
    }

    public void TurretFire(InputAction.CallbackContext ctx)
    {
        
        if (playerSO[playInput.playerIndex].isTurret)
        {
            if (ctx.started && playerSO[playInput.playerIndex].rolling == false && turAnimMan.firing == false)
            {
                turAnimMan.startUp();
                chargingTurret = true;
            }

            if (ctx.canceled && playerSO[playInput.playerIndex].rolling == false && turretValueSetting.bulletSpeed > minTurretCharge && turAnimMan.startingUp == false)
            {
                StartCoroutine(Fire());
                if (chargingTurret)
                {
                    turAnimMan.fire();  
                    chargingTurret = false;
                }
                print("charingStoped");
                firingBullet = true;
            }
            else if (ctx.canceled && firingBullet == false)
            {
                playerSO[playInput.playerIndex].movementSpeed = mainSO.baseMoveSpeed;
                chargingTurret = false;

                turAnimMan.Idle();
            }

            print("turretFire");
        }
    }

    // Update is called once per frame

    public void Charge(InputAction.CallbackContext ctx)
    {
        if (ctx.started && playerSO[playInput.playerIndex].rolling == false)
        {
            charging = true;
        }
        if (ctx.canceled && playerSO[playInput.playerIndex].rolling == false)
        {
            charging = false;
        }
        else if (ctx.canceled && firingBullet == false)
        {
            playerSO[playInput.playerIndex].movementSpeed = mainSO.baseMoveSpeed;
            charging = false;
        }
    }

    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (playInput != null && playerSO != null && reloadingScript != null && playerSO[playInput.playerIndex].isTurret == false)
        {
            if (playerSO[playInput.playerIndex].state == 0 && playerSO[playInput.playerIndex].gunChosen != 10)
            {
                isFiringContinously = ctx.ReadValueAsButton();

                if (canShoot && playerSO[playInput.playerIndex].bulletsInChamber > 0 && playerSO[playInput.playerIndex].isReloading == false && playerSO[playInput.playerIndex].rolling == false && playerSO[playInput.playerIndex].gunChosen != 6 && playerSO[playInput.playerIndex].lightingGoblin == false && playerSO[playInput.playerIndex].gunChosen != 4)
                {
                    StartCoroutine(Fire());
                    firingBullet = true;
                    playerSO[playInput.playerIndex].firing = true;
                }
                else if (canShoot && playerSO[playInput.playerIndex].bulletsInChamber == 0 && playerSO[playInput.playerIndex].rolling == false && playerSO[playInput.playerIndex].gunChosen != 6 && playerSO[playInput.playerIndex].lightingGoblin == false)
                {
                    if (playerSO[playInput.playerIndex].gunChosen != 8)
                    {
                        reloadingScript.OnReload();
                    }else if (spellOut == false)
                    {
                        reloadingScript.OnReload();
                    }
                    
                }
            }
        }
    }

    public void PlungerFire(InputAction.CallbackContext ctx)
    {
        if (playerSO[playInput.playerIndex].gunChosen == 6 && playerSO[playInput.playerIndex].state == 0 && playerSO[playInput.playerIndex].isTurret == false)
        {
            if (ctx.started && playerSO[playInput.playerIndex].rolling == false)
            {
                chargingBow = true;
            }


            if (ctx.canceled && playerSO[playInput.playerIndex].rolling == false && plungerValueSetting.bulletSpeed > 20)
            {
                StartCoroutine(Fire());
                chargingBow = false;
                firingBullet = true;
            }
            else if (ctx.canceled)
            {
                playerSO[playInput.playerIndex].movementSpeed = mainSO.baseMoveSpeed;
                chargingBow = false;
            }
        }
    }

    void Charge()
    {
        if (chargingBow)
        {
            playerSO[playInput.playerIndex].movementSpeed = shootMoveSpeed;
            plungerValueSetting.bulletSpeed += bowChargeSpeed * Time.deltaTime;
            
        }
        else
        {
            plungerValueSetting.bulletSpeed = baseBowSpeed;
        }

        if (chargingTurret)
        {
            turretValueSetting.bulletSpeed += turretBulletSpeedCharge * Time.deltaTime;
            turretBulletSize += turretBulletSizeCharge * Time.deltaTime;

        }
        else
        {
            turretValueSetting.bulletSpeed = baseTurretBulletSpeed;
            turretBulletSize = 0;
        }

        if (playerSO[playInput.playerIndex].gunChosen == 10)
        {

            if (charging && playerSO[playInput.playerIndex].bulletsInChamber > 0)
            {
                startedCharging = true;
                pillTimeToExplode -= Time.deltaTime;

                if (pillTimeToExplode < 0)
                {
                    charging= false;
                }

            }else if (charging == false && startedCharging)
            {
                startedCharging = false;
                if (playerSO[playInput.playerIndex].bulletsInChamber > 0 && pillTimeToExplode < startingPillToExplode -.03f)
                {
                    StartCoroutine(Fire());
                }
            }

            if (charging && playerSO[playInput.playerIndex].bulletsInChamber <= 0)
            {
                reloadingScript.OnReload();
                charging = false;
                spellCharged = false;
            }
        }
    }
    IEnumerator Fire()
    {
        if (playerSO[playInput.playerIndex].state == 0 && revTimeLeft <= 0 && canShoot && playerSO[playInput.playerIndex].health > 0)
        {
            playerSO[playInput.playerIndex].firing = true;
            //playerSO[playInput.playerIndex].movementSpeed = shootMoveSpeed;
            if (playerSO[playInput.playerIndex].isTurret)
            {
                GameObject bullet1;
                bullet1 = Instantiate(bulletPrephab[3], firePoint[3].position, firePoint[3].rotation);
                bullet1.GetComponent<Rigidbody2D>().AddForce(firePoint[3].up * playerSO[playInput.playerIndex].fireForece, ForceMode2D.Impulse);
                bullet1.GetComponent<TurretBulletScript>().owner = playInput.playerIndex;
                bullet1.transform.localScale = new Vector3(turretBulletSize, turretBulletSize, turretBulletSize);
            }
            else if (playerSO[playInput.playerIndex].gunChosen == 1)
            {
                ShotgunFire();
            }
            else if (playerSO[playInput.playerIndex].gunChosen == 9)
            {
                GameObject bullet1 = Instantiate(bulletPrephab[9], SMGFirePoints[0].position, SMGFirePoints[0].rotation);
                bullet1.GetComponent<Rigidbody2D>().AddForce(SMGFirePoints[0].up * playerSO[playInput.playerIndex].fireForece, ForceMode2D.Impulse);
                bullet1.GetComponent<BulletData>().Asignment(playInput.playerIndex, playerSO[playInput.playerIndex].perkOwned, playerSO[playInput.playerIndex].magicRockMult);
            }
            else if (playerSO[playInput.playerIndex].gunChosen == 10)
            {
                GameObject bullet1 = Instantiate(bulletPrephab[10], firePoint[10].position, firePoint[10].rotation);
                bullet1.GetComponent<Rigidbody2D>().AddForce(firePoint[10].up * playerSO[playInput.playerIndex].fireForece, ForceMode2D.Impulse);
                bullet1.GetComponent<BulletData>().Asignment(playInput.playerIndex, playerSO[playInput.playerIndex].perkOwned, playerSO[playInput.playerIndex].magicRockMult);
                bullet1.GetComponent<GrenadeBulletMan>().TimeBeforeExpodeAssigment(pillTimeToExplode, playerObject);
                pillTimeToExplode = startingPillToExplode;
            }
            else
            {
                if (spellOut == false && playerSO[playInput.playerIndex].gunChosen != 10)
                {
                    FireBullet();
                }
            }

            if (playerSO[playInput.playerIndex].recoilPower > 0)
            {
                StartCoroutine(Recoil());
            }

            playerSO[playInput.playerIndex].bulletsInChamber--;
            canShoot = false;
            yield return new WaitForSeconds(playerSO[playInput.playerIndex].timeBetweenShots);
            canShoot = true;
            firingBullet = false;
            //playerSO[playInput.playerIndex].movementSpeed = mainSO.baseMoveSpeed;
        }

    }

    IEnumerator Recoil()
    {
        recoiling = true;
        yield return new WaitForSeconds(recoilTime);
        recoiling = false;
    }
}
