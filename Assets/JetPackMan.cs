using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JetPackMan : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public Transform firePoint;
    public float recoilPower;
    public float recoilAdd;
    public float recoilIncrease;
    public float recoilDecrease;
    public float recoilMax;
    private float baseRP;
    public Player_SO[] playSO;
    public PlayerInput playInput;
    private float recoilTimeLeft;
    // Start is called before the first frame update
    void Start()
    {
        baseRP = recoilPower;
        playInput = GetComponentInParent<PlayerInput>();
        playerRb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (recoilTimeLeft > 0)
        {
            recoilTimeLeft -= recoilIncrease * Time.deltaTime;
            recoilPower -= (recoilAdd / 2) * Time.deltaTime;
        }

        if (recoilPower > 0) 
        {
            playerRb.AddForce(-firePoint.up * recoilPower * Time.deltaTime, ForceMode2D.Force);
        }
    }

    private void Fire()
    {
        recoilTimeLeft += recoilAdd;
        if (recoilPower < recoilMax)
        {
            recoilPower += recoilIncrease;
        }
    }
}
