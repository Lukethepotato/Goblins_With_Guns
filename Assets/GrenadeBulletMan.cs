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
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        bulletData = gameObject.GetComponent<BulletData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inplode && playSO[bulletData.owner].moveInput != Vector2.zero)
        {
            GameObject explosivo = Instantiate(explosion, (Vector2)player.transform.position - playSO[bulletData.owner].moveInput, Quaternion.identity);
            explosivo.GetComponent<GrenadeExplosionEffectMan>().Asignment(bulletData.owner, bulletData.perk, bulletData.rockMult);
            Destroy(gameObject);

        }

        if (timeBeforeExplode < 0)
        {
            GameObject explosivo = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            explosivo.GetComponent<GrenadeExplosionEffectMan>().Asignment(bulletData.owner, bulletData.perk, bulletData.rockMult);

            GameObject firepoint = Instantiate(staFirepoint, gameObject.transform.position, gameObject.transform.rotation);
            firepoint.GetComponent<StationaryFirepoint_Data>().Assigment(bulletData.owner, bulletData.perk, 1);
            Destroy(gameObject);
        }


        timeBeforeExplode -= Time.deltaTime;

        rb.drag += massIncrease * Time.deltaTime;
    }

    public void TimeBeforeExpodeAssigment(float time, GameObject playerSet)
    {
        if (time < 0)
        {
            inplode = true;
        }
        else
        {
            timeBeforeExplode = time;
        }

        player = playerSet;
    }
}
