using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowMakerBulletMan : MonoBehaviour
{
    public Player_SO[] playSO;
    BulletData bullData;
    // Start is called before the first frame update
    void Start()
    {
        bullData = gameObject.GetComponent<BulletData>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && playSO[bullData.owner].perks[3])
        {
            playSO[bullData.owner].bulletsInChamber += 1;
        }
    }
}
