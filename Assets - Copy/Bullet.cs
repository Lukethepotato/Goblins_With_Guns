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
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(7,7);
        rb2d= GetComponent<Rigidbody2D>();
        StartCoroutine(deadBulletTest());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("portal") != true && collisionsDectectable && noBouce == false)
        {
            timesHitWall += 1;
            var speed = lastVelocity.magnitude;
            Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb2d.velocity = direction * Mathf.Max(speed, 0f);

            ricochetSpeedUp += speedUpMultiply;
            StartCoroutine(collisionDelay());
            collisionsDectectable = false;
        }else if (collision.gameObject.CompareTag("portal") != true && noBouce)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        rb2d.velocity *= ricochetSpeedUp;

        if(mainSO.freezeAllPlayer)
        {
            Destroy(gameObject);
        }

        if (timesHitWall == maxWallHits || timesHitWall > maxWallHits)
        {
            Destroy(gameObject);
        }

        lastVelocity = rb2d.velocity;

        deadBulletTesting();
    }

    private void deadBulletTesting()
    {
        if (gracePeriod == false)
        {

            if (lastVelocity.y < .5f && lastVelocity.y > -.5f)
            {
                Destroy(gameObject);
            }
            else if (lastVelocity.x < .5f && lastVelocity.x > -.5f)
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

}
