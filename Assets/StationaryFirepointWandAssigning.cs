using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryFirepointWandAssigning : MonoBehaviour
{
    StationaryFirepointFiring firingScript;
    public StationaryFirepointWandSetting wandData;
    public GameObject parent;

    [Header("Multipliers")]
    public float bulletSpeed;
    public float firePointLife;
    public float bulletAmount;

    public bool isTrackingBullet = true;
    // Start is called before the first frame update
    void Start()
    {
        firingScript = gameObject.GetComponent<StationaryFirepointFiring>();
        wandData = parent.GetComponent<StationaryFirepointWandSetting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTrackingBullet == false)
        {
            firingScript.bulletSpeed = wandData.wandAmount * bulletSpeed;
        }
        else
        {
            firingScript.WandSetting(wandData.wandAmount * bulletSpeed);
        }
        firingScript.radousPoints = (int)(wandData.wandAmount * bulletAmount);
    }
}
