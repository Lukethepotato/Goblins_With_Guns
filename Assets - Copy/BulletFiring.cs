using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class BulletFiring : MonoBehaviour
{
    public GameObject[] bulletPrephab;
    public Transform[] firePoint;
    public Transform[] shotgunFirePoints;
    public Transform[] turretFirePoints;
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

    // Start is called before the first frame update
    void Start()
    {
        playInput = GetComponentInParent<PlayerInput>();
        reloadingScript = gameObject.GetComponent<Reloading>();
        inputActions = new InputActions();
        plungerValueSetting = plunger.GetComponent<Gun_Value_Setting>();
    }

    private void Update()
    {
        randomBulletSpread = Random.Range(1 , 10);

        if (canShoot && playerSO[playInput.playerIndex].bulletsInChamber > 0 && playerSO[playInput.playerIndex].isReloading == false && playerSO[playInput.playerIndex].rolling == false && isFiringContinously)
        {
            StartCoroutine(Fire());
        }

        BowCharge();
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrephab[playerSO[playInput.playerIndex].gunChosen], firePoint[playerSO[playInput.playerIndex].gunChosen].position, firePoint[playerSO[playInput.playerIndex].gunChosen].rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint[playerSO[playInput.playerIndex].gunChosen].up * playerSO[playInput.playerIndex].fireForece, ForceMode2D.Impulse);
    }

    public void shotgunFire()
    {
        GameObject bullet1 = Instantiate(bulletPrephab[1], shotgunFirePoints[0].position, shotgunFirePoints[0].rotation);
        bullet1.GetComponent<Rigidbody2D>().AddForce(shotgunFirePoints[0].up * playerSO[playInput.playerIndex].fireForece, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(bulletPrephab[1], shotgunFirePoints[1].position, shotgunFirePoints[1].rotation);
        bullet2.GetComponent<Rigidbody2D>().AddForce(shotgunFirePoints[1].up * playerSO[playInput.playerIndex].fireForece, ForceMode2D.Impulse);

        GameObject bullet3 = Instantiate(bulletPrephab[1], shotgunFirePoints[2].position, shotgunFirePoints[2].rotation);
        bullet3.GetComponent<Rigidbody2D>().AddForce(shotgunFirePoints[2].up * playerSO[playInput.playerIndex].fireForece, ForceMode2D.Impulse);

        GameObject bullet4 = Instantiate(bulletPrephab[1], shotgunFirePoints[3].position, shotgunFirePoints[3].rotation);
        bullet4.GetComponent<Rigidbody2D>().AddForce(shotgunFirePoints[3].up * playerSO[playInput.playerIndex].fireForece, ForceMode2D.Impulse);
    }

    private void TurretFire()
    {
        GameObject bullet1 = Instantiate(bulletPrephab[3], turretFirePoints[0].position, turretFirePoints[0].rotation);
        bullet1.GetComponent<Rigidbody2D>().AddForce(turretFirePoints[0].up * playerSO[playInput.playerIndex].fireForece, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(bulletPrephab[3], turretFirePoints[1].position, turretFirePoints[1].rotation);
        bullet2.GetComponent<Rigidbody2D>().AddForce(turretFirePoints[1].up * playerSO[playInput.playerIndex].fireForece, ForceMode2D.Impulse);
    }

    // Update is called once per frame

    public void OnFire(InputAction.CallbackContext ctx)
    {
        if (playerSO[playInput.playerIndex].state == 0)
        {
            isFiringContinously = ctx.ReadValueAsButton();

            if (canShoot && playerSO[playInput.playerIndex].bulletsInChamber > 0 && playerSO[playInput.playerIndex].isReloading == false && playerSO[playInput.playerIndex].rolling == false && playerSO[playInput.playerIndex].gunChosen != 6 && playerSO[playInput.playerIndex].lightingGoblin == false)
            {
                StartCoroutine(Fire());
                print("InputActed");
                firingBullet = true;
            }
        }
    }

    public void PlungerFire(InputAction.CallbackContext ctx)
    {
        if (playerSO[playInput.playerIndex].gunChosen == 6 && playerSO[playInput.playerIndex].state == 0)
        {
            if (ctx.started && playerSO[playInput.playerIndex].rolling == false)
            {
                chargingBow = true;
            }


            if (ctx.canceled && playerSO[playInput.playerIndex].rolling == false && canShoot)
            {
                StartCoroutine(Fire());
                chargingBow = false;
                print("charingStoped");
                firingBullet = true;
            }
            else if (ctx.canceled)
            {
                playerSO[playInput.playerIndex].movementSpeed = mainSO.baseMoveSpeed;
                chargingBow = false;
            }
        }

        print("plungFire");
    }

    void BowCharge()
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
    }
    IEnumerator Fire()
    {
        playerSO[playInput.playerIndex].movementSpeed = shootMoveSpeed;
        if (playerSO[playInput.playerIndex].isTurret)
        {
            TurretFire();
        }
        else if (playerSO[playInput.playerIndex].gunChosen == 1)
        {
            shotgunFire();
        }else
        {
            FireBullet();
        }
        playerSO[playInput.playerIndex].bulletsInChamber--;
        canShoot = false;
        yield return new WaitForSeconds(playerSO[playInput.playerIndex].timeBetweenShots);
        canShoot= true;
        firingBullet = false;
        playerSO[playInput.playerIndex].movementSpeed = mainSO.baseMoveSpeed;
    }
}
