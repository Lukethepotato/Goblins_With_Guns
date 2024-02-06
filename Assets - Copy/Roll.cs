using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.U2D.IK;

public class Roll : MonoBehaviour
{
    AnimationManager animManager;
    public Player_SO[] playSOs;
    PlayerInput playInput;
    public MainSO mainSO;
    private bool rollInput;
    private bool isRolling = false;
    private bool roll = false;
    public float invisTime;
    public float vunbilTime;
    public float waitTime;
    public float rollPower;
    public float vulRollPower;
    public float oringalRollPower;
    Rigidbody2D RB;
    public LayerMask bulletIgnore;
    public bool xInactive = false;
    public bool yInactive = false;
    SpriteRenderer SR;
    public float invisAlpha;
    public float regenTime;
    public float fatigueMultiplier;
    public float fatigueMultiplierRoll;
    public float baseRollPower;
    public float zeroProtectionTime;
    private bool canRoll = true;
    
    // Start is called before the first frame update
    void Start()
    {
        animManager = gameObject.GetComponent<AnimationManager>();
        playInput = gameObject.GetComponent<PlayerInput>();
        RB = gameObject.GetComponent<Rigidbody2D>();
        SR= gameObject.GetComponent<SpriteRenderer>();

        zeroProtectionTime = (vunbilTime + invisTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (rollInput && isRolling == false && playSOs[playInput.playerIndex].state == 0)
        {
            StopCoroutine(Rolling());
            if (playSOs[playInput.playerIndex].fatigue != 0)
            {
                Fatigue();
            }
            rollInput = false;
            isRolling = true;
            StartCoroutine(Rolling());
        }



        if (playSOs[playInput.playerIndex].moveInput.x < .75 && playSOs[playInput.playerIndex].moveInput.x > -.75)
        {
            xInactive = true;
        }else
        {
            xInactive = false;
        }

        if (playSOs[playInput.playerIndex].moveInput.y < .75 && playSOs[playInput.playerIndex].moveInput.y > -.75)
        {
            yInactive= true;
        }
        else
        {
            yInactive = false;
        }
         

        if (roll)
        RB.AddForce(playSOs[playInput.playerIndex].moveInput * rollPower * Time.deltaTime, ForceMode2D.Force);

        RollChecking();
    }

    public void OnRoll()
    {
        if(isRolling== false)
        {
            rollInput = true;
        }
        if (playInput != null)
        {
            if (playSOs[playInput.playerIndex].isTurret)
                StartCoroutine(TurretDisabling());
        }
    }

    private void RollChecking()
    {
        if (playSOs[playInput.playerIndex].lightingGoblin || playSOs[playInput.playerIndex].buff)
        {
            canRoll = false;
        }
        else
        {
            canRoll = true;
        }
    }

    public void Fatigue()
    {
        if (rollPower - (playSOs[playInput.playerIndex].fatigue * fatigueMultiplierRoll) > -1f)
        {
            rollPower -= (playSOs[playInput.playerIndex].fatigue * fatigueMultiplierRoll);
        }

        if (playSOs[playInput.playerIndex].movementSpeed - playSOs[playInput.playerIndex].fatigue * fatigueMultiplier > -1f)
        {
            playSOs[playInput.playerIndex].movementSpeed -= (playSOs[playInput.playerIndex].fatigue * fatigueMultiplier);
        }
    }

    public void Reguvenation()
    {
        rollPower = baseRollPower;
        playSOs[playInput.playerIndex].movementSpeed = mainSO.baseMoveSpeed;
        playSOs[playInput.playerIndex].fatigue = 0;
    }

    IEnumerator Rolling()
    {
        float pastFatigue = playSOs[playInput.playerIndex].fatigue;
        yield return new WaitForSeconds(.085f);
        if (pastFatigue != pastFatigue + 1)
        {
            playSOs[playInput.playerIndex].fatigue += 1;
        }
        print("rollAnimation");
        gameObject.layer = LayerMask.NameToLayer("Bullets_Ignore");

        if (playSOs[playInput.playerIndex].moveInput.y > .5 && xInactive)
        {
            animManager.ChangeAnimationState(animManager.ROLL);
        }
        else if (playSOs[playInput.playerIndex].moveInput.y < .5 && xInactive)
        {
            animManager.ChangeAnimationState(animManager.ROLL_FORWARD);
        }else if (playSOs[playInput.playerIndex].moveInput.x < .5 && yInactive)
        {
            animManager.ChangeAnimationState(animManager.Roll_Left);
        }
        else
        {
            animManager.ChangeAnimationState(animManager.Roll_Right);
        }
        if (playSOs[playInput.playerIndex].fatigue < 5)
        {
            playSOs[playInput.playerIndex].invincble = true;
        }
        playSOs[playInput.playerIndex].rolling = true;
        roll = true;
        yield return new WaitForSeconds(invisTime);
        playSOs[playInput.playerIndex].invincble = false;
        rollPower = vulRollPower;
        yield return new WaitForSeconds(vunbilTime);
        roll = false;
        animManager.ChangeAnimationState(animManager.IDLE);
        playSOs[playInput.playerIndex].rolling = false;
        gameObject.layer = default;
        yield return new WaitForSeconds(waitTime);
        isRolling = false;
        rollPower = oringalRollPower;
        yield return new WaitForSeconds((playSOs[playInput.playerIndex].fatigue / 2) + .2f);
        if (isRolling == false)
        {
            Reguvenation();
            
        }
    }

    IEnumerator TurretDisabling() 
    {
        playSOs[playInput.playerIndex].isTurret = false;
        playSOs[playInput.playerIndex].bulletsInChamber = 0;
        playSOs[playInput.playerIndex].turretDisabled= true;
        yield return new WaitForSeconds(1);
        playSOs[playInput.playerIndex].turretDisabled = false;
    }
}
