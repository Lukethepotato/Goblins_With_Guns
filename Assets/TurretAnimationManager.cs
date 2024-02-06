using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretAnimationManager : MonoBehaviour
{
    AnimationManager animManag;
    public BulletFiring bulletFiring;
    public Player_SO[] playSO;
    public PlayerInput playInput;
    private bool idle = true;
    public float shootTime;
    public float sparkUpTime;
    public bool firing = false;
    public bool startingUp = false;
    // Start is called before the first frame update
    void Start()
    {
        animManag = gameObject.GetComponent<AnimationManager>();
        bulletFiring= gameObject.GetComponentInParent<BulletFiring>();
        playInput = gameObject.GetComponentInParent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].health != 0 && idle && startingUp == false)
        {
            animManag.ChangeAnimationState("TurretIdleAnim");
        }
    }

    public void startUp()
    {
        startingUp = true;
        StartCoroutine(StartUp());
        idle = false;
        print("startUp");
    }


    public void fire()
    {
        if (idle == false)
        {
            StartCoroutine(ShootEnum());
        }
    }

    public void Idle()
    {
        if (firing == false)
        idle= true;
    }

    IEnumerator ShootEnum()
    {
        firing = true;
        animManag.ChangeAnimationState("TurretShoot");
        yield return new WaitForSeconds(shootTime);
        firing = false;
        animManag.ChangeAnimationState("TurretIdleAnim");
    }

    IEnumerator StartUp()
    {
         animManag.ChangeAnimationState("TurretSparkUp");
         yield return new WaitForSeconds(sparkUpTime);
         animManag.ChangeAnimationState("TurretCharge");
         startingUp = false;
    }
}
