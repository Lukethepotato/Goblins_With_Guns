using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeRangeScript : MonoBehaviour
{
    public float explosionTime;
    void Start()
    {
        StartCoroutine(Explosion());
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(explosionTime);
        Destroy(gameObject);
    }
}