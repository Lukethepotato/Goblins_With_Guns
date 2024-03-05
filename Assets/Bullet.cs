using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    public MainSO mainSO;
    public int timesHitWall;
    public int maxWallHits;
    public Vector3 lastVelocity;
    Rigidbody2D rb2d;
    private bool gracePeriod = true;
    private float ricochetSpeedUp = 1;
    private bool collisionsDectectable = true;
    public float speedUpMultiply;
    public bool noBouce = false;
    SpriteRenderer sp2d;
    private float rotation;
    public bool ghostBullet;
    public float ghostBulletDamage;
    public float deadBulletMin = .1f;
    public Player_SO[] playSO;
    private bool destroyNow = false;
    public bool testDeadBullet = true;
    public bool playerDestroyTouch = true;
    public float bounceDullTime = .05f;
    public bool bounceDull;
    public float knockBackAmount = 5000;
    public float superKnockBackAmount = 25000;
    public float damage;
    BulletData bulletData;
    Collider2D coll2d;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(7,7);
        rb2d= GetComponent<Rigidbody2D>();
        StartCoroutine(deadBulletTest());
        sp2d = gameObject.GetComponent<SpriteRenderer>();
        bulletData = gameObject.GetComponent<BulletData>();
        coll2d = gameObject.GetComponent<Collider2D>();

        if (bulletData.perk == 9)
        {
            maxWallHits += mainSO.bounceyBulletBounceIncrease;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("portal") != true && collisionsDectectable && noBouce == false)
        {
            timesHitWall += 1;
            var speed = lastVelocity.magnitude;
            Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
/*
            if (bounceDull)
            {
                StartCoroutine(Bounce());
            }
*/

            rb2d.velocity = direction * Mathf.Max(speed, 0f);
            gameObject.transform.up = gameObject.transform.up * -1;


            ricochetSpeedUp += speedUpMultiply;
            StartCoroutine(collisionDelay());
            collisionsDectectable = false;
            rb2d.rotation = -rb2d.rotation;
        }
        else if (collision.gameObject.CompareTag("portal") != true && noBouce || collision.gameObject.CompareTag("Barrel"))
        {
            destroyNow = true;
        }

        if (collision.gameObject.CompareTag("Player") && ghostBullet == false)
        {  
            if (playSO[gameObject.GetComponent<BulletData>().owner].perks[4] == false && playerDestroyTouch)
            {
                destroyNow = true;
            }
        }

        if (collision.gameObject.CompareTag("Object"))
        {
            destroyNow = true;
        }
    }

    private void Update()
    {
        rb2d.velocity *= ricochetSpeedUp;

        if(mainSO.freezeAllPlayer)
        {
            Destroy(gameObject);
        }

        if ((timesHitWall == maxWallHits || timesHitWall > maxWallHits) && ghostBullet == false)
        {
            Destroy(gameObject);
        }

        lastVelocity = rb2d.velocity;

        deadBulletTesting();

        if (bulletData.perk == 6)
        {
            knockBackAmount = superKnockBackAmount;
        }
    }

    private void LateUpdate()
    {
        if (destroyNow)
        {
            Destroy(gameObject);
        }
    }

    private void deadBulletTesting()
    {
        if (gracePeriod == false)
        {
            if (lastVelocity.y < deadBulletMin && lastVelocity.y > -deadBulletMin)
            {
                Destroy(gameObject);
            }
            else if (lastVelocity.x < deadBulletMin && lastVelocity.x > -deadBulletMin)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator deadBulletTest()
    {
        yield return new WaitForSeconds(.5f);
        gracePeriod= false;
    }

    IEnumerator collisionDelay()
    {
        yield return new WaitForSeconds(.1f);
        collisionsDectectable = true;
    }

    IEnumerator Bounce()
    {
        coll2d.isTrigger = true;
        yield return new WaitForSeconds(bounceDullTime);
        coll2d.isTrigger = false;
    }
    
}
