using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ExplosiveBarrelScript : MonoBehaviour
{
    public GameObject explosionParticle;
    public GameObject explostionRange;
    public float timeBeforeExplosion;
    public GameObject parent;
    // Start is called before the first frame update
    private void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            StartCoroutine(BarrelExplosion());
        }else if (other.gameObject.CompareTag("bullet_Shotgun"))
        {
            StartCoroutine(BarrelExplosion());
        }
        else if (other.gameObject.CompareTag("Bullet_Sniper"))
        {
            StartCoroutine(BarrelExplosion());
        }else if (other.gameObject.CompareTag("Bullet_MiniGun"))
        {
            StartCoroutine(BarrelExplosion());
        }else if (other.gameObject.CompareTag("bullet_Turret"))
        {
            StartCoroutine(BarrelExplosion());
        }
        else if (other.gameObject.CompareTag("Bullet_RPG"))
        {
            StartCoroutine(BarrelExplosion());
        }
        else if (other.gameObject.CompareTag("bullet_FlameThrower"))
        {
            StartCoroutine(BarrelExplosion());
        }
        else if (other.gameObject.CompareTag("Explosion"))
        {
            StartCoroutine(BarrelExplosion());
        }
    }

    IEnumerator BarrelExplosion()
    {
        yield return new WaitForSeconds(timeBeforeExplosion);
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Instantiate(explostionRange, transform.position, Quaternion.identity);
        Destroy(parent);
    }
}
