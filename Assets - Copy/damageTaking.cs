using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    public float flameThrowerBulletDamage;
    public float burnDamage;
    public float explosionPower;
    public float explosionDamage;
    public float hitITime;
    private bool hitImunity = false;
    private bool explosionING;
    public float totalburnTime;
    public float burnIntervals;
    Rigidbody2D RB;
    public GameObject explosionPrephab;
    SpriteRenderer SR;
    public Vector2 explosionDirection;
    public GameObject aimCircle;
    public GameObject effects;
    public AnimationManager effectAnimMan;
    public MainSO mainSO;

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
        if ((aimCircle.transform.position.x - gameObject.transform.position.x) > 0)
        {
            explosionDirection.x = 1;
        }
        else
        {
            explosionDirection.x = -1;
        }

        if ((aimCircle.transform.position.y - gameObject.transform.position.y) > 0)
        {
            explosionDirection.y = 1;
        }
        else
        {
            explosionDirection.y = -1;
        }
        

        if (hitImunity)
        {
            StartCoroutine(InvisibleFlash());
        }
        else
        {
            SR.color = new Color(1, 1, 1, 1);
        }

        if (explosionING == true)
        {
            RB.AddForce(-explosionDirection * explosionPower, ForceMode2D.Force);
            print("PUSH");
        }

        if (playSO[playInput.playerIndex].health < 1 && playSO[playInput.playerIndex].burning && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].burning = false;
            StopCoroutine(Burning());
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].health -= basicBulletDamage;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            print("hit");
            StartCoroutine(HitImunityTime());
        }

        if (other.gameObject.CompareTag("bullet_Shotgun") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].health -= shotgunBulletDamage;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            print("hit");
            //StartCoroutine(HitImunityTime());
        }

        if (other.gameObject.CompareTag("Bullet_Sniper") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].health -= other.gameObject.GetComponent<sniperBulletDamageIncrease>().damage;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            print("hit");
            StartCoroutine(HitImunityTime());
        }

        if (other.gameObject.CompareTag("Bullet_MinGun") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].health -= miniGunDamage;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            print("hit");
            StartCoroutine(HitImunityTime());
        }

        if (other.gameObject.CompareTag("Bullet_RPG") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].health -= rocketDamage;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            print("hit");
            StartCoroutine(HitImunityTime());
        }

        if (other.gameObject.CompareTag("bullet_FlameThrower") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].health -= flameThrowerBulletDamage;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            print("hit");
            StartCoroutine(HitImunityTime());
            if (playSO[playInput.playerIndex].burning == false)
            {
                StartCoroutine(Burning());
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Explosion") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer ==false)
        {
            playSO[playInput.playerIndex].health -= explosionDamage;
            StartCoroutine(HitImunityTime());
            StartCoroutine(Explosion());
            print("TRIGGERED");
        }

        if (other.gameObject.CompareTag("Lightning") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].health -= 100;
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
        explosionING= true;
        yield return new WaitForSeconds(.025f);
        explosionING= false;
    }

    IEnumerator InvisibleFlash()
    {
        SR.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(.1f);
        SR.color = playSO[playInput.playerIndex].oringalColor;
    }

    IEnumerator Burning()
    {
        effectAnimMan.ChangeAnimationState("Effects_Burning");
        playSO[playInput.playerIndex].burning = true;
        yield return new WaitForSeconds(burnIntervals);
        playSO[playInput.playerIndex].health -= burnDamage;
        yield return new WaitForSeconds(burnIntervals);
        playSO[playInput.playerIndex].health -= burnDamage;
        yield return new WaitForSeconds(burnIntervals);
        playSO[playInput.playerIndex].health -= burnDamage;
        yield return new WaitForSeconds(burnIntervals);
        playSO[playInput.playerIndex].health -= burnDamage;
        yield return new WaitForSeconds(burnIntervals);
        playSO[playInput.playerIndex].health -= burnDamage;
        yield return new WaitForSeconds(burnIntervals);
        playSO[playInput.playerIndex].health -= burnDamage;
        yield return new WaitForSeconds(burnIntervals);
        playSO[playInput.playerIndex].health -= burnDamage;
        yield return new WaitForSeconds(burnIntervals);
        playSO[playInput.playerIndex].health -= burnDamage;
        yield return new WaitForSeconds(burnIntervals);
        playSO[playInput.playerIndex].health -= burnDamage;
        yield return new WaitForSeconds(burnIntervals);
        playSO[playInput.playerIndex].health -= burnDamage;
        yield return new WaitForSeconds(burnIntervals);
        playSO[playInput.playerIndex].health -= burnDamage;
        yield return new WaitForSeconds(burnIntervals);
        playSO[playInput.playerIndex].burning = false;
        effectAnimMan.ChangeAnimationState("Effects_Idle");
    }
}
