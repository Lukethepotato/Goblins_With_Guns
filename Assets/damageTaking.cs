using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class damageTaking : MonoBehaviour
{
    public Player_SO[] playSO;
    PlayerInput playInput;
    public float basicBulletDamage;
    public float sniperBulletDamage;
    public float shotgunBulletDamage;
    public float miniGunDamage;
    public float rocketDamage;
    public float smgDamage;
    public float flameThrowerBulletDamage;
    public float burnDamage;
    public float explosionPower;
    public float explosionDamage;
    public float hitITime;
    private bool hitImunity = false;
    private bool explosionING;
    public float totalburnTime;
    public float burnIntervals;
    public float turretDamageInterval;
    Rigidbody2D RB;
    public GameObject explosionPrephab;
    SpriteRenderer SR;
    public Vector2 explosionDirection;
    public GameObject aimCircle;
    public GameObject effects;
    public AnimationManager effectAnimMan;
    public MainSO mainSO;
    private bool gate = false;
    public float explosionTime;
    private bool exploRoll = false;
    public float timeBeforeExplosionPush;
    private Vector3 explosionLoca;
    private int explosionID;
    public float knockbackAmount;
    public float knockbackTime;
    private bool knockBack = false;
    private Vector2 knockbackPosition;
    public float moveInputDamp = 1;
    private float localDamageMult = 1;


    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        SR = gameObject.GetComponent<SpriteRenderer>();
        RB = gameObject.GetComponent<Rigidbody2D>();
        effectAnimMan = effects.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (hitImunity)
        {
            StartCoroutine(InvisibleFlash());
        }
        else
        {
            SR.color = new Color(1, 1, 1, 1);
        }

        if (knockBack)
        {
            RB.AddForce(-knockbackPosition * knockbackAmount * Time.deltaTime);
        }

        if (playSO[playInput.playerIndex].health < 1 && playSO[playInput.playerIndex].burning && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].burning = false;
            StopCoroutine(Burning());
        }

        if (knockBack)
        {
            Vector2 direction = knockbackPosition;
            Vector2 moveBias = playSO[playInput.playerIndex].ActiveMoveInput;

            RB.AddForce((direction + (moveBias * moveInputDamp)) * knockbackAmount * Time.deltaTime, ForceMode2D.Force);
        }
    }

    private void FixedUpdate()
    {
        if (explosionING == true)
        {
            Vector2 heading = explosionLoca - gameObject.transform.position;
            float distance = Vector3.Distance(gameObject.transform.position, explosionLoca);

            explosionDirection = heading / distance;

            Vector2 moveInput;
            Vector2 moveBias;

            if (playSO[playInput.playerIndex].moveInput != Vector2.zero)
            {
                moveInput = playSO[playInput.playerIndex].moveInput;
            }
            else
            {
                moveInput = Vector2.one;
            }

            if (playSO[playInput.playerIndex].inRollState)
            {
                exploRoll = true;
            }

            if (playSO[playInput.playerIndex].ActiveMoveInput != Vector2.zero)
            {
                moveBias = playSO[playInput.playerIndex].ActiveMoveInput;
            }
            else
            {
                moveBias = Vector2.one;
            }

            RB.AddForce((-explosionDirection + (moveBias * moveInputDamp)) * (explosionPower - distance), ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Bullet>() != null)
        {
            if (knockBack == false)
            {
                knockbackAmount = other.gameObject.GetComponent<Bullet>().knockBackAmount;
                knockbackPosition = other.gameObject.transform.up;
                StartCoroutine(KnockBack());
            }

            localDamageMult = playSO[other.gameObject.GetComponent<BulletData>().owner].damageDealtMult;

            if (playSO[other.gameObject.GetComponent<BulletData>().owner].perkOwned == 9)
            {
                localDamageMult = (other.gameObject.GetComponent<Bullet>().timesHitWall) * mainSO.bounceyBulletsDamMult;
                print("ooglyBoogly");
            }

            if (playSO[other.gameObject.GetComponent<BulletData>().owner].perkOwned == 3 && playSO[other.gameObject.GetComponent<BulletData>().owner].magazineSize / playSO[other.gameObject.GetComponent<BulletData>().owner].orinagalChamberSize <= mainSO.maxWidowMult)
            {
                playSO[other.gameObject.GetComponent<BulletData>().owner].magazineSize += playSO[other.gameObject.GetComponent<BulletData>().owner].orinagalChamberSize;
                print("Add Chamber");
            }
        }

        if (other.gameObject.CompareTag("bullet") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            if (playSO[playInput.playerIndex].isTurret == true)
            {
                mainSO.turretHealth -= basicBulletDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
                Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            }else if (playSO[playInput.playerIndex].isTurret == false)
            {
                playSO[playInput.playerIndex].health -= basicBulletDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
                Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            }

            if (playSO[playInput.playerIndex].inGame && playSO[other.gameObject.GetComponent<BulletData>().owner].perkOwned == 4)
            other.gameObject.GetComponent<VampBulletMan>().AddHealth(basicBulletDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult);
        }

        if (other.gameObject.CompareTag("bullet_Shotgun") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            if (playSO[playInput.playerIndex].isTurret == true)
            {
                mainSO.turretHealth -= shotgunBulletDamage * playSO[playInput.playerIndex].damageTakeMult * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
                Instantiate(explosionPrephab, transform.position, Quaternion.identity);
                StartCoroutine(InvisibleFlash());

            }
            else if (playSO[playInput.playerIndex].isTurret == false)
            {
                playSO[playInput.playerIndex].health -= shotgunBulletDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
                Instantiate(explosionPrephab, transform.position, Quaternion.identity);
                StartCoroutine(InvisibleFlash());
            }
            if (playSO[playInput.playerIndex].inGame && playSO[other.gameObject.GetComponent<BulletData>().owner].perkOwned == 4)
                other.gameObject.GetComponent<VampBulletMan>().AddHealth(shotgunBulletDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult);
        }

        if (other.gameObject.CompareTag("Bullet_Sniper") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            if (playSO[playInput.playerIndex].isTurret == true)
            {
                mainSO.turretHealth -= other.gameObject.GetComponent<sniperBulletDamageIncrease>().damage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
                Instantiate(explosionPrephab, transform.position, Quaternion.identity);
                StartCoroutine(InvisibleFlash());
            }
            else if (playSO[playInput.playerIndex].isTurret == false)
            {
                playSO[playInput.playerIndex].health -= other.gameObject.GetComponent<sniperBulletDamageIncrease>().damage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
                Instantiate(explosionPrephab, transform.position, Quaternion.identity);
                print("fuckin' Ballz (:<");
                StartCoroutine(InvisibleFlash());
                StartCoroutine(HitImunityTime());
            }
            if (playSO[playInput.playerIndex].inGame && playSO[other.gameObject.GetComponent<BulletData>().owner].perkOwned == 4)
                other.gameObject.GetComponent<VampBulletMan>().AddHealth(other.gameObject.GetComponent<sniperBulletDamageIncrease>().damage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult);
        }

        if (other.gameObject.CompareTag("bullet_SMG") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            if (playSO[playInput.playerIndex].isTurret == true)
            {
                mainSO.turretHealth -= smgDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
                Instantiate(explosionPrephab, transform.position, Quaternion.identity);
                StartCoroutine(InvisibleFlash());
            }
            else if (playSO[playInput.playerIndex].isTurret == false)
            {
                playSO[playInput.playerIndex].health -= smgDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
                Instantiate(explosionPrephab, transform.position, Quaternion.identity);
                print("hit");
                StartCoroutine(InvisibleFlash());
            }
            if (playSO[playInput.playerIndex].inGame && playSO[other.gameObject.GetComponent<BulletData>().owner].perkOwned == 4)
                other.gameObject.GetComponent<VampBulletMan>().AddHealth(smgDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult);
        }

        if (other.gameObject.CompareTag("Bullet_MinGun") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].health -= miniGunDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;

            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            print("hit");


            if (playSO[playInput.playerIndex].inGame && playSO[other.gameObject.GetComponent<BulletData>().owner].perkOwned == 4)
                other.gameObject.GetComponent<VampBulletMan>().AddHealth(miniGunDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult);
        }

        if (other.gameObject.CompareTag("Bullet_RPG") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].health -= rocketDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            print("hit");
            StartCoroutine(HitImunityTime());

            if (playSO[playInput.playerIndex].inGame && playSO[other.gameObject.GetComponent<BulletData>().owner].perkOwned == 4    )
                other.gameObject.GetComponent<VampBulletMan>().AddHealth(rocketDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult);
        }

        if (other.gameObject.CompareTag("bullet_FlameThrower") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].health -= flameThrowerBulletDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            print("hit");
            StartCoroutine(HitImunityTime());
            if (playSO[playInput.playerIndex].burning == false)
            {
                StartCoroutine(Burning());
            }

            if (playSO[playInput.playerIndex].inGame && playSO[other.gameObject.GetComponent<BulletData>().owner].perkOwned == 4)
                other.gameObject.GetComponent<VampBulletMan>().AddHealth(flameThrowerBulletDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Explosion") && mainSO.freezeAllPlayer ==false)
        {
            explosionLoca = other.gameObject.transform.position;
            explosionID = other.gameObject.GetComponent<BulletData>().owner;
            StartCoroutine(Explosion());
        }

        if (other.gameObject.CompareTag("Lightning") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].health -= 100 * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
        }

        if (other.gameObject.CompareTag("WandExplosion") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].health -= other.gameObject.GetComponent<WandExplosionDamage>().damage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            StartCoroutine(InvisibleFlash());

            if (playSO[playInput.playerIndex].inGame && playSO[other.gameObject.GetComponent<BulletData>().owner].perkOwned == 4)
                other.gameObject.GetComponent<VampBulletMan>().AddHealth(other.gameObject.GetComponent<WandExplosionDamage>().damage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult);

            StartCoroutine(HitImunityTime());
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet_Turret") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false && gate == false)
        {
            if (other.gameObject.GetComponent<TurretBulletScript>().owner != playInput.playerIndex)
            {
                StartCoroutine(InTurretBullet());
                StartCoroutine(InvisibleFlash());
                turretDamageInterval = other.gameObject.GetComponent<sniperBulletDamageIncrease>().damage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;

                if (playSO[playInput.playerIndex].inGame && playSO[other.gameObject.GetComponent<BulletData>().owner].perkOwned == 4)
                    other.gameObject.GetComponent<VampBulletMan>().AddHealth(other.gameObject.GetComponent<sniperBulletDamageIncrease>().damage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult);
            }
        }

        if (other.gameObject.GetComponent<Bullet>() != null)
        {
            if (other.gameObject.GetComponent<Bullet>().ghostBullet)
            {
                playSO[playInput.playerIndex].health -= other.gameObject.GetComponent<Bullet>().ghostBulletDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
                Instantiate(explosionPrephab, transform.position, Quaternion.identity);
                StartCoroutine(InvisibleFlash());

                if (playSO[playInput.playerIndex].inGame && playSO[other.gameObject.GetComponent<BulletData>().owner].perkOwned == 4)
                {
                    other.gameObject.GetComponent<VampBulletMan>().AddHealth(other.gameObject.GetComponent<Bullet>().ghostBulletDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult);
                }

                Destroy(other.gameObject);
            }
        }
    }


    IEnumerator HitImunityTime()
    {
        hitImunity= true;
        playSO[playInput.playerIndex].invincble= true;
        yield return new WaitForSeconds(hitITime);

        playSO[playInput.playerIndex].invincble = false;
        hitImunity = false;
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(timeBeforeExplosionPush);
        explosionING = true;

        yield return new WaitForSeconds(explosionTime);
        float distance = Vector3.Distance(gameObject.transform.position, explosionLoca);
        if (exploRoll == false && playSO[playInput.playerIndex].invincble == false && explosionING == true)
        {
            playSO[playInput.playerIndex].health -= (explosionDamage - distance) * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            if (playSO[playInput.playerIndex].inGame && playSO[explosionID].perkOwned == 4)
            {
                playSO[explosionID].health += (explosionDamage - distance) / 2;
            }
            StartCoroutine(HitImunityTime());
        }
        explosionING = false;
        yield return new WaitForSeconds(.001f);
        exploRoll = false;
    }

    IEnumerator InvisibleFlash()
    {
        SR.color = Color.red;
        yield return new WaitForSeconds(.1f);
        SR.color = playSO[playInput.playerIndex].oringalColor;

    }

    IEnumerator InTurretBullet()
    {
        gate = true;
        playSO[playInput.playerIndex].health -= turretDamageInterval * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
        Instantiate(explosionPrephab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.1f);
        gate = false;
    }

    IEnumerator KnockBack()
    {
        knockBack= true;
        yield return new WaitForSeconds(knockbackTime);
        knockBack = false;
    }

    IEnumerator Burning()
    {
        effectAnimMan.ChangeAnimationState("Effects_Burning");
        playSO[playInput.playerIndex].burning = true;
        if (playSO[playInput.playerIndex].burning== true )
        {
            yield return new WaitForSeconds(burnIntervals);
            playSO[playInput.playerIndex].health -= burnDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            yield return new WaitForSeconds(burnIntervals);
            playSO[playInput.playerIndex].health -= burnDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            yield return new WaitForSeconds(burnIntervals);
            playSO[playInput.playerIndex].health -= burnDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            yield return new WaitForSeconds(burnIntervals);
            playSO[playInput.playerIndex].health -= burnDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            yield return new WaitForSeconds(burnIntervals);
            playSO[playInput.playerIndex].health -= burnDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            yield return new WaitForSeconds(burnIntervals);
            playSO[playInput.playerIndex].health -= burnDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            yield return new WaitForSeconds(burnIntervals);
            playSO[playInput.playerIndex].health -= burnDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            yield return new WaitForSeconds(burnIntervals);
            playSO[playInput.playerIndex].health -= burnDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            yield return new WaitForSeconds(burnIntervals);
            playSO[playInput.playerIndex].health -= burnDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            yield return new WaitForSeconds(burnIntervals);
            playSO[playInput.playerIndex].health -= burnDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            yield return new WaitForSeconds(burnIntervals);
            playSO[playInput.playerIndex].health -= burnDamage * playSO[playInput.playerIndex].damageTakeMult * localDamageMult;
            yield return new WaitForSeconds(burnIntervals);
        }
        playSO[playInput.playerIndex].burning = false;
        effectAnimMan.ChangeAnimationState("Effects_Idle");
    }
}
