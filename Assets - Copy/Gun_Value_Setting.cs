using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun_Value_Setting : MonoBehaviour
{
    public Player_SO[] playSO;
    public PlayerInput playInput;

    public float bulletSpeed;
    public float ReloadTime;
    public int ChamberSize;
    public float timeInBetweenShots;
    public MainSO mainSO;
    private bool turretGate = false;
    public Gun_Stats gunStats;
    public bool baseGun = false;

    private bool StatsSet = false;
    // Start is called before the first frame update
    void Start()
    {
        playInput = GetComponentInParent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.setUpOver)
        {
            //StatsSet= true;
            playSO[playInput.playerIndex].fireForece = bulletSpeed;
            playSO[playInput.playerIndex].bulletReloadTime = ReloadTime;
            playSO[playInput.playerIndex].magazineSize = ChamberSize;
            playSO[playInput.playerIndex].timeBetweenShots = timeInBetweenShots;
        }
        else if ((mainSO.setUpOver == false || mainSO.rematchSelected) && baseGun)
        {
            playSO[playInput.playerIndex].bulletsInChamber = gunStats.chamberSize[playSO[playInput.playerIndex].oringalGunChosen];
        }
        else
        {
            playSO[playInput.playerIndex].bulletsInChamber = ChamberSize;
        }
    }
}
