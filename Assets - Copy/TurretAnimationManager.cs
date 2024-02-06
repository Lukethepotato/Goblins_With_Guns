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
        if (bulletFiring.firingBullet || bulletFiring.isFiringContinously && playSO[playInput.playerIndex].bulletsInChamber != 0)
        {
            animManag.ChangeAnimationState("TurretShoot");
        }
        else if (playSO[playInput.playerIndex].health != 0)
        {
            animManag.ChangeAnimationState("TurretIdleAnim");
        }
    }
}
