using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletFirepointInstan : MonoBehaviour
{
    public GameObject stationaryFirepoint;
    public float timeUntillExplode;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(timeUntillExplode);
        Instantiate(stationaryFirepoint, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
