using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BorrowRoll : MonoBehaviour
{
    public Player_SO[] playSO;
    Roll rollScript;
    PlayerInput playerInput;
    public bool rolling = false;
    public float startUpTime;
    public float rollTime; 
    public float settleTime;
    public float digPower;
    public float rechargeTime;
    public Rigidbody2D RB;
    public bool canRoll = true;
    public BoxCollider2D coll;
    public BoxCollider2D coll2;
    private float startingDigPower;
    public float digPowerSpeedIncrease;
    public GameObject aimBall;
    private Vector2 setMove;
    public float inputReducer;
    private bool setMoveDectecable = false;
    public GameObject moveInputBall;
    public float fDamping;
    public GameObject groundColl;
    public GameObject travserableWallColl;

    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.IgnoreLayerCollision(11, 11);
        rollScript = gameObject.GetComponent<Roll>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        RB = gameObject.GetComponent<Rigidbody2D>();
        coll = gameObject.GetComponent<BoxCollider2D>();
        coll2 = groundColl.GetComponent<BoxCollider2D>();
        startingDigPower = digPower;
    }

    // Update is called once per frame
    void Update()
    {

        if (rolling)
        {
            digPower += Time.deltaTime * digPowerSpeedIncrease;

            //RB.velocity = fVelocity;
            print("Smoothing");
            RB.AddForce((moveInputBall.transform.up * digPower * Time.deltaTime));
        }

        if (setMoveDectecable)
        {
            setMove = playSO[playerInput.playerIndex].moveInput;
        }
        
    }

    public void OnRoll()
    {
        if (canRoll && playSO[playerInput.playerIndex].perkOwned == 5)
        {
            digPower = startingDigPower;
            StartCoroutine(Brorrow());
            canRoll = false;
        }
    }

    IEnumerator Brorrow()
    {
        travserableWallColl.SetActive(true);
        playSO[playerInput.playerIndex].freeze= true;
        playSO[playerInput.playerIndex].rolling = true;
        //playSO[playerInput.playerIndex].canMove = false;
        setMoveDectecable = true;
        yield return new WaitForSeconds(startUpTime);
        playSO[playerInput.playerIndex].invincble= true;
        setMoveDectecable = false;
        playSO[playerInput.playerIndex].freeze = false;
        rolling = true;
        coll.isTrigger = true;
        coll2.isTrigger= true;
        yield return new WaitForSeconds(rollTime);
        rolling = false;
        coll.isTrigger = false;
        coll.isTrigger= false;
        playSO[playerInput.playerIndex].invincble = false;
        playSO[playerInput.playerIndex].freeze = true;
        yield return new WaitForSeconds(settleTime);
        playSO[playerInput.playerIndex].freeze = false;
        //playSO[playerInput.playerIndex].canMove = true;
        playSO[playerInput.playerIndex].rolling = false;
        travserableWallColl.SetActive(false);
        yield return new WaitForSeconds(rechargeTime);
        canRoll = true;
    }
}
