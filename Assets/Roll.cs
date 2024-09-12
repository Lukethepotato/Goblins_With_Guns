using MultiplayerBasicExample;
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
    Rigidbody2D RB;
    public LayerMask bulletIgnore;
    public bool xInactive = false;
    public bool yInactive = false;
    SpriteRenderer SR;
    public float invisAlpha;
    public float regenTime;
    public float fatigueMultiplier;
    public float fatigueMultiplierRoll;
    public float zeroProtectionTime;
    private bool canRoll = true;
    public float SDMultiplerAmount;
    public float SDMultiplierRunTime;
    public float speedDashWait;
    private float startingRollPower;
    public float endingRollPower;
    public float rollMoveInputDamp;
    public bool fatgiueOff = false;
    public float borrowRollSettleTime;
    public float borrowRollRechargeTime;
    public float borrowRollTime;
    public float BorrowRollStartingPower;
    public float BorrowRollEndingPower;
    public float BorrowRollControl;
    public GameObject travserableWallColl;
    public BoxCollider2D coll;
    public BoxCollider2D coll2;
    public GameObject groundColl;

    // Start is called before the first frame update
    void Start()
    {
        animManager = gameObject.GetComponent<AnimationManager>();
        playInput = gameObject.GetComponent<PlayerInput>();
        RB = gameObject.GetComponent<Rigidbody2D>();
        SR= gameObject.GetComponent<SpriteRenderer>();
        coll = gameObject.GetComponent<BoxCollider2D>();
        coll2 = groundColl.GetComponent<BoxCollider2D>();

        zeroProtectionTime = (vunbilTime + invisTime);
        startingRollPower = rollPower;
    }

    // Update is called once per frame
    void Update()
    {
        


        if (playSOs[playInput.playerIndex].perks[2])
        {
            SDMultiplierRunTime = SDMultiplerAmount;
        }
        else
        {
            SDMultiplierRunTime = 1;
        }
        
        if (rollInput && isRolling == false && playSOs[playInput.playerIndex].state == 0 && playSOs[playInput.playerIndex].perks[5] == false)
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

        if (playSOs[playInput.playerIndex].state != 0)
        {
            fatigueMultiplier = 1;
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
        {
            //RB.AddForce((playSOs[playInput.playerIndex].moveInput * rollPower * SDMultiplierRunTime * playSOs[playInput.playerIndex].magicRockMult) / playSOs[playInput.playerIndex].fatigue * Time.deltaTime, ForceMode2D.Force);
        }

        /*
        if (playSOs[playInput.playerIndex].perks[5] && mainSO.setUpOver)
        {
            vunbilTime = 0;
            invisTime = borrowRollTime;
            rollMoveInputDamp = BorrowRollControl;
            startingRollPower = BorrowRollStartingPower;
            endingRollPower= BorrowRollEndingPower;
        }
        */
        
        RollChecking();
    }

    public void OnRoll()
    {
        if (playSOs[playInput.playerIndex].isReloading == false && mainSO.gamePaused == false && playSOs[playInput.playerIndex].perks[5] == false)
        {
            if (isRolling == false)
            {
                rollInput = true;
            }
            if (playInput != null)
            {
                if (playSOs[playInput.playerIndex].isTurret)
                    StartCoroutine(TurretDisabling());
            }
        }
    }

    private void LengthSetting(float value)
    {
        rollPower = value;
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
        if (rollPower - (playSOs[playInput.playerIndex].fatigue * (fatigueMultiplierRoll * SDMultiplierRunTime)) > -1f)
        {
            rollPower -= (playSOs[playInput.playerIndex].fatigue * (fatigueMultiplierRoll * SDMultiplierRunTime * SDMultiplierRunTime * SDMultiplierRunTime * SDMultiplierRunTime * SDMultiplierRunTime));
        }

        if (playSOs[playInput.playerIndex].movementSpeed - playSOs[playInput.playerIndex].fatigue * (fatigueMultiplierRoll * SDMultiplierRunTime) > -1f)
        {
            playSOs[playInput.playerIndex].movementSpeed -= (playSOs[playInput.playerIndex].fatigue * (fatigueMultiplierRoll * SDMultiplierRunTime * SDMultiplierRunTime * SDMultiplierRunTime * SDMultiplierRunTime * SDMultiplierRunTime));
        }
    }


    public void Reguvenation()
    {
        rollPower = startingRollPower;
        playSOs[playInput.playerIndex].movementSpeed = playSOs[playInput.playerIndex].basePlayerSpeed;
        playSOs[playInput.playerIndex].fatigue = 0;
    }

    private void FixedUpdate()
    {
        if (roll)
        {
            RB.AddForce(((playSOs[playInput.playerIndex].moveInput + (playSOs[playInput.playerIndex].ActiveMoveInput * rollMoveInputDamp) ) * rollPower * SDMultiplierRunTime * playSOs[playInput.playerIndex].magicRockMult) / playSOs[playInput.playerIndex].fatigue, ForceMode2D.Force);
        }
    }

    IEnumerator Rolling()
    {
        print("RollMaxing");
        coll2.isTrigger = true;
        /*
        if (playSOs[playInput.playerIndex].perkOwned == 5)
        {
            travserableWallColl.SetActive(true);
            coll.isTrigger= true;
        }
        */
        playSOs[playInput.playerIndex].inRollState= true;
        float pastFatigue = playSOs[playInput.playerIndex].fatigue;
        yield return new WaitForSeconds(0);
        if (pastFatigue != pastFatigue + 1 && playSOs[playInput.playerIndex].fatigue < 7 && playSOs[playInput.playerIndex].perkOwned != 2 && fatgiueOff == false)
        {
            playSOs[playInput.playerIndex].fatigue += 1;
        }
        else if (playSOs[playInput.playerIndex].perkOwned == 2 || fatgiueOff)
        {
            playSOs[playInput.playerIndex].fatigue = 1;
        }
        print("rollAnimation");

        if (playSOs[playInput.playerIndex].perkOwned != 2)
        {
            gameObject.layer = LayerMask.NameToLayer("Bullets_Ignore");
            groundColl.layer = LayerMask.NameToLayer("Bullets_Ignore"); 
        }

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
        LeanTween.value(gameObject, startingRollPower, endingRollPower, invisTime).setEaseInExpo().setOnUpdate(LengthSetting);
        //RB.AddForce((playSOs[playInput.playerIndex].moveInput * rollPower * SDMultiplierRunTime * playSOs[playInput.playerIndex].magicRockMult) / playSOs[playInput.playerIndex].fatigue * Time.deltaTime, ForceMode2D.Impulse);
        yield return new WaitForSeconds(invisTime * SDMultiplierRunTime);
        groundColl.layer = 3;
        gameObject.layer = 9;
        playSOs[playInput.playerIndex].invincble = false;
        roll = false;
        yield return new WaitForSeconds(vunbilTime / SDMultiplierRunTime);
        travserableWallColl.SetActive(false);
        coll2.isTrigger = false;
        coll.isTrigger = false;
        animManager.ChangeAnimationState(animManager.IDLE);
        playSOs[playInput.playerIndex].rolling = false;
        float timeToWait;
        float borrowRollWait;

        if (playSOs[playInput.playerIndex].perkOwned == 5)
        {
            borrowRollWait = borrowRollSettleTime;
        }
        else
        {
            borrowRollWait = 0;
        }
        yield return new WaitForSeconds(borrowRollWait);
        if (playSOs[playInput.playerIndex].perkOwned == 2)
        {
            timeToWait = speedDashWait;
        }else if (playSOs[playInput.playerIndex].perkOwned == 5)
        {
            timeToWait = borrowRollRechargeTime;
        } 
        else
        {
            timeToWait = waitTime;
        }
        playSOs[playInput.playerIndex].inRollState = false;

        yield return new WaitForSeconds(timeToWait);
        isRolling = false;
        yield return new WaitForSeconds(((playSOs[playInput.playerIndex].fatigue) + .2f) / SDMultiplierRunTime);
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
