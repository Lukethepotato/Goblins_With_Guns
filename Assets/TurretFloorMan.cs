using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFloorMan : MonoBehaviour
{
    CircleCollider2D Col2d;
    public GameObject turret;
    public float activationTime;
    public float DeactivationTime;
    AnimationManager animMan;
    // Start is called before the first frame update
    void Start()
    {
        Col2d= gameObject.GetComponent<CircleCollider2D>();
        animMan = gameObject.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator Activation()
    {
        animMan.ChangeAnimationState("TurretFloorActivation");
        yield return new WaitForSeconds(activationTime);
        animMan.ChangeAnimationState("TurretFloorOnIdle");
        turret.SetActive(true);
        Col2d.isTrigger = true;
    }

    public IEnumerator Deactivate()
    {
        turret.SetActive(false);
        Col2d.isTrigger = false;
        animMan.ChangeAnimationState("TurretFloorDeactivation");
        yield return new WaitForSeconds(DeactivationTime);
        animMan.ChangeAnimationState("TurretGroundIdle");
    }

}
