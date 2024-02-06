using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniperBulletDamageIncrease : MonoBehaviour
{
    public float damage;
    public float damageIncreaseSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject != null)
        damage += damageIncreaseSpeed * Time.deltaTime;
    }
}
