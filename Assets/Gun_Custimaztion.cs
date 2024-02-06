using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun_Custimaztion : MonoBehaviour
{
    public Player_SO[] playSO;
    public MainSO mainSO;
    PlayerInput playInput;

    public float pistolReloadTime;
    public float pistolChamber;
    public float pistolDamage;
    public float pistolTimeBetweenShots;
    public float pistolBulletFireForce;


    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
