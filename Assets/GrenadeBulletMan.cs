using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBulletMan : MonoBehaviour
{
    public float timeBeforeExplode;
    public float massIncrease;
    BulletData bulletData;
    Rigidbody2D rb;
    public GameObject explosion;
    public Player_SO[] playSO;
    private bool inplode = false;
    private GameObject player;
    public GameObject staFirepoint;
    private bool asisgned = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        bulletData = gameObject.GetComponent<BulletData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inplode)
        {
            if (playSO[bulletData.owner].moveInput != Vector2.zero)
            {
                GameObject explosivo = Instantiate(explosion, (Vector2)player.transform.position - playSO[bulletData.owner].moveInput, Quaternion.identity);
                explosivo.GetComponent<GrenadeExplosionEffectMan>().Asignment(bulletData.owner, bulletData.perk, bulletData.rockMult);
                Destroy(gameObject);
                print("Inplode");
            }
            else
            {
                GameObject explosivo = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
                explosivo.GetComponent<GrenadeExplosionEffectMan>().Asignment(bulletData.owner, bulletData.perk, bulletData.rockMult);
                Destroy(gameObject);
            }

        }else if (timeBeforeExplode < 0 && inplode == false)
        {
            GameObject explosivo = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            explosivo.GetComponent<GrenadeExplosionEffectMan>().Asignment(bulletData.owner, bulletData.perk, bulletData.rockMult);

            GameObject firepoint = Instantiate(staFirepoint, gameObject.transform.position, gameObject.transform.rotation);
            firepoint.GetComponent<StationaryFirepoint_Data>().Assigment(bulletData.owner, bulletData.perk, 1);
            Destroy(gameObject);
            print("Outplode");
        }


        timeBeforeExplode -= Time.deltaTime;

        rb.drag += massIncrease * Time.deltaTime;
    }

    public void TimeBeforeExpodeAssigment(float time, GameObject playerSet)
    {
        if (asisgned == false)
        {
            if (time < 0)
            {
                inplode = true;
                print("InplodeTrue");
            }
            else
            {
                timeBeforeExplode = time;
                inplode= false;
                print("InplodeFalse");
            }
            asisgned= true;
            player = playerSet;
            print(time);
        }
    }
}
