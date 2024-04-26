using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryGunModulation : MonoBehaviour
{
    public GameObject parent;
    public StationaryFirepoint_Data data;
    StationaryFirepointFiring firing;
    public GameObject[] bullets;
    public Player_SO[] playSO;
    private int gunChosen;
    public SentryGunCopyValues[] gunVals;
    public GameObject shotgunFirePoints;
    // Start is called before the first frame update
    void Start()
    {
        data = parent.GetComponent<StationaryFirepoint_Data>();
        firing = gameObject.GetComponent<StationaryFirepointFiring>();
        firing.bullet = bullets[playSO[data.owner].gunChosen];
        gunChosen = playSO[data.owner].gunChosen;
        firing.bullet = bullets[playSO[data.owner].gunChosen];

        firing.bulletSpeed = gunVals[gunChosen].fireForce;
        firing.firingRate = gunVals[gunChosen].fireRate;

        if (gunChosen == 1)
        {
            shotgunFirePoints.SetActive(true);
        }
        else
        {
            shotgunFirePoints.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
