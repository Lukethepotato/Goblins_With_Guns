using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMagicGunBulletMan : MonoBehaviour
{
    public float timeUntillEmit;
    public GameObject firePoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timeUntillEmit);
        Instantiate(firePoint, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
