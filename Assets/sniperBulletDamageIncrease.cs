using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sniperBulletDamageIncrease : MonoBehaviour
{
    public float damage;
    public float damageIncreaseSpeed;
    public bool damageFalloff;
    Bullet bulletScript;
    // Start is called before the first frame update
    void Start()
    {
        bulletScript = gameObject.GetComponent<Bullet>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject != null)
        {
            if (damageFalloff == false)
            {
                damage += damageIncreaseSpeed * Time.deltaTime;
            }
            else if (damageFalloff == true && damage > 1.5f)
            {
                damage -= damageIncreaseSpeed * Time.deltaTime;
            }
            else
            {
                damage = 1;
            }

            bulletScript.damage = damage;
        }
    }
}
