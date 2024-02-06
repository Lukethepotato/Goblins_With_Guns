using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretActivation : MonoBehaviour
{
    public TurretTurner turner1;
    public TurretTurner turner2;
    public GameObject turret;
    public MainSO mainSO;
    public GameObject[] turners;
    private bool turretOut = false;
    public Player_SO[] playSO;
    public GameObject turretFloor;
    TurretFloorMan TurFloorScript;

    // Start is called before the first frame update
    void Start()
    {
        turner1 = turners[0].GetComponent<TurretTurner>();
        turner2 = turners[1].GetComponent<TurretTurner>();
        TurFloorScript = turretFloor.GetComponent<TurretFloorMan>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turner1.done && turner2.done && turretOut == false)
        {
            StartCoroutine(TurFloorScript.Activation());
            turretOut= true;
        }else if (turner1.done ==false && turner2.done == false && turretOut)
        {
            ResetTurners();
            turretOut= false;
            playSO[0].isTurret = false;
            playSO[1].isTurret = false;
            playSO[2].isTurret = false;
            playSO[3].isTurret = false;
        }

        if (mainSO.rematchSelected || mainSO.suddenDeathInitiated)
        {
            ResetTurners();
            turretOut = false;
            playSO[0].isTurret = false;
            playSO[1].isTurret = false;
            playSO[2].isTurret = false;
            playSO[3].isTurret = false;
        }
    }

    public void ResetTurners()
    {
        turner1.timeLeft = 0;
        turner2.timeLeft = 0;
        turner1.done = false;
        turner2.done = false;
        StartCoroutine(TurFloorScript.Deactivate());
        mainSO.turretHealth = mainSO.startingTurretHealth;
    }
}
