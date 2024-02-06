using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ExplosiveBarrelScript : MonoBehaviour
{
    public GameObject explosionParticle;
    public float timeBeforeExplosion;
    public GameObject parent;
    // Start is called before the first frame update
    private void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Bullet>() != null)
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
        Destroy(parent);
    }
}
