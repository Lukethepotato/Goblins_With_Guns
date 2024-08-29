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
    public float explosionDamage = 25;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 || mainSO.suddenDeathInitiated)
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
            GameObject.Find("PlayerSFX").GetComponent<AudioManager>().Play("HitSound");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Explosion") && mainSO.freezeAllPlayer == false)
        {
            health -= explosionDamage * localDamageMult;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            GameObject.Find("PlayerSFX").GetComponent<AudioManager>().Play("HitSound");
        }

        if (other.gameObject.CompareTag("Lightning") && mainSO.freezeAllPlayer == false)
        {
            health -= 200 * localDamageMult;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            GameObject.Find("PlayerSFX").GetComponent<AudioManager>().Play("HitSound");
        }

        if (other.gameObject.GetComponent<Bullet>().damage > 0)
        {
            health = 0;
            Instantiate(explosionPrephab, transform.position, Quaternion.identity);
            GameObject.Find("PlayerSFX").GetComponent<AudioManager>().Play("HitSound");
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
