using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosionScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Explosion());
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(.05f);
        Destroy(gameObject);
    }
}
