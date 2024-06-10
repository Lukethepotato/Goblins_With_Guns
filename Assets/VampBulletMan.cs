using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampBulletMan : MonoBehaviour
{
    public BulletData data;
    public Player_SO[] playSO;
    public float healthModifier;
    public float maxHealth;
    public bool destroyAfter = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHealth(float damage)
    {
        if (playSO[data.owner].perks[4] == true)
        {
            playSO[data.owner].health += (damage * healthModifier);
            if (destroyAfter)
            {
                Destroy(gameObject);
            }
            print("VampHealed");
        }
    }
}
