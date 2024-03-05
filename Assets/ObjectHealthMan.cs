using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectHealthMan : MonoBehaviour
{
    public float health;
    public GameObject explosionPrephab;
    public MainSO mainSO;
    public float localDamageMult;
    public Player_SO[] playSO;
    public bool exploDestruct;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        localDamageMult = playSO[other.gameObject.GetComponent<BulletData>().owner].damageDealtMult;

        if (other.gameObject.GetComponent<Bullet>().damage > 0 && mainSO.freezeAllPlayer == false)
        { 
            health -= other.gameObject.GetComponent<Bullet>().damage * localDamageMult;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
        }
    }

    public void Destroy()
    {
        if (exploDestruct)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
