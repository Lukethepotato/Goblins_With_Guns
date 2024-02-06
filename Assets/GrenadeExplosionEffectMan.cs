using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosionEffectMan : MonoBehaviour
{
    public GameObject explosionColl;
    public bool ready = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Asignment(int playSO, int perkNum, float magicRockMult)
    {
        if (ready)
        {
            GameObject Range = Instantiate(explosionColl, gameObject.transform.position, Quaternion.identity);
            Range.GetComponent<BulletData>().Asignment(playSO, perkNum, magicRockMult);
        }
    }
}
