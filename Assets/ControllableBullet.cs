using ExitGames.Client.Photon;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using System.Linq;
using Photon.Realtime;

public class ControllableBullet : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Player_SO[] playSO;
    public float fireSpeed;
    public Vector2 SpeedUpStop;
    public Vector2 firePointPos;
    private Vector2 lastAim;
    public bool superControll;
    public BulletData data;
    public bool wand = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        data= gameObject.GetComponent<BulletData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[data.owner].perks[1] == true && superControll == false)
        {
            firePointPos = GameObject.Find("FirePoint_Copy" + data.owner.ToString()).transform.up;

            if ((firePointPos.x > SpeedUpStop.x + lastAim.x || firePointPos.x < -SpeedUpStop.x + lastAim.x) && (firePointPos.y > SpeedUpStop.y + lastAim.y || firePointPos.y < -SpeedUpStop.y + lastAim.y))
            {
                lastAim = firePointPos;
                rb2d.AddForce((firePointPos * fireSpeed) * Time.deltaTime);
            }
        }else if (superControll && playSO[data.owner].perks[1] == true || wand)
        {
            firePointPos = GameObject.Find("FirePoint_Copy" + data.owner.ToString()).transform.up;
            rb2d.AddForce((firePointPos * fireSpeed) * Time.deltaTime);
        }
    }
}
