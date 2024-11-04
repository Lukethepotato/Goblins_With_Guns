using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class StationaryFirepointFiring : MonoBehaviour
{
    enum SpawnerType { Straight, Spin, raduis}

    [Header("Bullet Attributes")]
    public int radousPoints = 2;
    public int pulseSubtract = 0;
    public int radiusPulses = 1;
    public float timeBetweenPulses = .5f;
    public GameObject bullet;
    public float firepointLife = 1f;
    public float bulletSpeed = 1f;
    public float spinSpeed = 0;
    public bool fireForward = true;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    public float firingRate = 1f;
    public GameObject parent; 
    public StationaryFirepoint_Data data;

    private float timer = 0f;
    private bool inPulse;
    private float pulseTimer = 0f;
    private Vector2 startFirePoint;
    public bool DoShootSFX = false;

    private float wandBulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        data = parent.GetComponent<StationaryFirepoint_Data>();
        startFirePoint = gameObject.transform.up;
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.z + spinSpeed * Time.deltaTime);
        if (timer >= firingRate && fireForward)
        {
            Fire();
            timer = 0;
        }

        firepointLife -= Time.deltaTime;
        if (firepointLife < 0f)
        {
            Destroy(gameObject);
        }

        if (radiusPulses <= 0)
        {
            Destroy(gameObject);
        }

        if (spawnerType == SpawnerType.raduis && inPulse == true)
        {
            for (int I = 1; I <= radousPoints; I++)
            {
                transform.localEulerAngles = new Vector3(0, 0, (360 / radousPoints) * I);
                Fire();

                if (I == radousPoints)
                {
                    radiusPulses--;
                    radousPoints -= pulseSubtract;
                    inPulse = false;
                    pulseTimer = timeBetweenPulses;
                }
                else
                {
                    inPulse = false;
                }
            }
        }

        if (inPulse ==false)
        {
            pulseTimer -= Time.deltaTime;
        }

        if (inPulse == false && pulseTimer <= 0)
        {
            inPulse= true;
        }
    }

    public void WandSetting(float speed)
    {
        wandBulletSpeed = speed;
    }
    private void Fire()
    {
        if (DoShootSFX)
        {
            GameObject.Find("PlayerSFX").GetComponent<AudioManager>().PlayOneShot("TurretShoot");
        }
        GameObject spawnedBullet = Instantiate(bullet, transform.position + transform.up, transform.rotation);

        if (spawnedBullet.GetComponent<BulletData>() != null)
        {
            spawnedBullet.GetComponent<BulletData>().Asignment(data.owner, data.perkOwned, data.rockMult);
        }
        spawnedBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed, ForceMode2D.Force);

        if (spawnedBullet.GetComponent<BulletTargetScript>() != null)
        {
            spawnedBullet.GetComponent<BulletTargetScript>().firePointFiredAt = startFirePoint;
            if (wandBulletSpeed > 0)
            {
                spawnedBullet.GetComponent<BulletTargetScript>().travelSpeed = wandBulletSpeed;
            }
        }
    }
}
