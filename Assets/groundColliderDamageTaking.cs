using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class groundColliderDamageTaking : MonoBehaviour
{
    public Player_SO[] playSO;
    public GameObject mainObject;
    public PlayerInput playInput;
    BoxCollider2D boxCollider;
    private bool gate = false;
    public float coytoteJumpTime = .2f;
    public bool checkIfTouchingSewage = true;
    public MainSO mainSO;
    public float sewageDamage;
    public AnimationManager animMan;
    public float acidEmergeTime;
    public bool raycast = false;
    public float closestPointMult;
    private bool inCourtine = false;
    private Collider2D collsion;
    public Vector2 curPos;
    public BoxCollider2D mainObjectColl;
    public Vector2 oldPos;
    private bool inCoyoteJump = false;
    // Start is called before the first frame update
    void Start()
    {
        playInput= mainObject.GetComponent<PlayerInput>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        animMan = mainObject.GetComponent<AnimationManager>();
        mainObjectColl = mainObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].health > 0 && inCourtine == false && raycast == false)
        {
            playSO[playInput.playerIndex].touchingSewage = false;
            gate = true;
        }

        if (playSO[playInput.playerIndex].health < 1)
        {
            gate = false;
        }

        if (raycast)
        {
            mainObject.transform.position = oldPos * closestPointMult;
            raycast = false;
            playSO[playInput.playerIndex].touchingSewage = false;
            inCourtine = false;
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ToxicSewage") && playSO[playInput.playerIndex].inRollState == false && playSO[playInput.playerIndex].health > 0 && checkIfTouchingSewage && mainSO.freezeAllPlayer == false && raycast == false && playSO[playInput.playerIndex].touchingSewage == false && playSO[playInput.playerIndex].health > 0)
        {
            playSO[playInput.playerIndex].health -= sewageDamage;
            playSO[playInput.playerIndex].touchingSewage = true;
            print("shouldDie");
            if (inCourtine == false)
            {
                StartCoroutine(sewageNonKill());
                inCourtine = true;
                collsion = other;
            }
        }
        else if (other.gameObject.CompareTag("ToxicSewage") && playSO[playInput.playerIndex].inRollState == false && playSO[playInput.playerIndex].health > 0 && checkIfTouchingSewage == false && inCoyoteJump == false)
        {
            StartCoroutine(CoytoeJump());
            inCoyoteJump = true;
        }
        else if (checkIfTouchingSewage == false && raycast == false && inCourtine == false && playSO[playInput.playerIndex].touchingSewage)
        {
            playSO[playInput.playerIndex].touchingSewage = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ToxicSewage"))
        {
            oldPos = gameObject.transform.position;
        }
    }

    IEnumerator CoytoeJump()
    {
        print("bhfbhf");
        boxCollider.enabled = false;
        checkIfTouchingSewage = false;
        yield return new WaitForSeconds(coytoteJumpTime);
        checkIfTouchingSewage = true;
        boxCollider.enabled = true;
        yield return new WaitForSeconds(1);
        if (playSO[playInput.playerIndex].touchingSewage == false)
        {
            checkIfTouchingSewage = false;
            
        }
        inCoyoteJump = false;
    }

    IEnumerator sewageNonKill()
    {
        mainObjectColl.isTrigger= true;
        playSO[playInput.playerIndex].freeze = true;
        playSO[playInput.playerIndex].invincble= true;
        print("acid");
        animMan.ChangeAnimationState("Acid_Death");
        //hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 20f);
        yield return new WaitForSeconds(.5f + acidEmergeTime);
        playSO[playInput.playerIndex].freeze = false;
        playSO[playInput.playerIndex].invincble = false;
        raycast = true;
        mainObjectColl.isTrigger= false;

    }
}
