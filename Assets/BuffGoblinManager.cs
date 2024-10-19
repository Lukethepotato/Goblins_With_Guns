using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuffGoblinManager : MonoBehaviour
{
    public Player_SO[] playSO;
    public PlayerInput playInput;
    AnimationManager animMan;
    public float buffTime;
    public float startAnimTime;
    public float attackTime;
    public float endAttackTime;
    public string[] anim;
    public float attackWaitTime;
    public GameObject attackBox;
    private bool xInactive;
    private bool yInactive;
    public Rigidbody2D RB;
    public float firePower;
    public float fireMoveSpeed;
    private bool fireBoost = false;
    public MainSO mainSO;
    public Vector2 pausedInput;
    public bool attacking = false;
    public string prompt = "to attack!!";
    public InputDecection inputDetect;

    // Start is called before the first frame update
    void Start()
    {
        inputDetect = gameObject.GetComponent<InputDecection>();
        playInput = gameObject.GetComponent<PlayerInput>();
        animMan = gameObject.GetComponent<AnimationManager>();
        RB = gameObject.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].moveInput.x < .75 && playSO[playInput.playerIndex].moveInput.x > -.75)
        {
            xInactive = true;
        }
        else
        {
            xInactive = false;
        }

        if (playSO[playInput.playerIndex].moveInput.y < .75 && playSO[playInput.playerIndex].moveInput.y > -.75)
        {
            yInactive = true;
        }
        else
        {
            yInactive = false;
        }

        if (playSO[playInput.playerIndex].moveInput.y > .5 && xInactive)
        {
            playSO[playInput.playerIndex].direction = 1;
        }
        else if (playSO[playInput.playerIndex].moveInput.y < .5 && xInactive)
        {
            playSO[playInput.playerIndex].direction = 2;
        }   
        else if (playSO[playInput.playerIndex].moveInput.x < .5 && yInactive)
        {
            playSO[playInput.playerIndex].direction = 3;
        }
        else
        {
            playSO[playInput.playerIndex].direction = 4;
        }

        if (fireBoost)
        {
            RB.AddForce(pausedInput * firePower * Time.deltaTime, ForceMode2D.Force);
        }
    }

    public void Fire(InputAction.CallbackContext ctx)
    {
        if (attacking == false && playSO[playInput.playerIndex].buff && playSO[playInput.playerIndex].canMove) 
        {
            StartCoroutine(Attack(anim[playSO[playInput.playerIndex].direction]));
        }
    }
    public void buffMode()
    {
        if (playSO[playInput.playerIndex].state == 0 && mainSO.inSuddenDeath == false)
        {
            StartCoroutine(buffCourtine());
        }
    }

    IEnumerator buffCourtine()
    {
        float oringalFLyPower = firePower;
        playSO[playInput.playerIndex].buff = true;
        playSO[playInput.playerIndex].state = 1;
        playSO[playInput.playerIndex].canMove = false;
        playSO[playInput.playerIndex].invincble = true;
        playSO[playInput.playerIndex].movementSpeed = 0;
        playSO[playInput.playerIndex].freeze= true;
        GameObject.Find("PlayerSFX").GetComponent<AudioManager>().Play("BuffModeStart");
        animMan.ChangeAnimationState("Buff_Start");
        yield return new WaitForSeconds(startAnimTime);
        GameObject.Find("MainCanvas").GetComponent<CanvasButtonPrompts>().prompt = prompt;
        GameObject.Find("MainCanvas").GetComponent<CanvasButtonPrompts>().DisplayTheText("fire", inputDetect.GetControlType());
        playSO[playInput.playerIndex].movementSpeed = playSO[playInput.playerIndex].basePlayerSpeed;
        playSO[playInput.playerIndex].canMove = true;
        playSO[playInput.playerIndex].freeze = false;
        yield return new WaitForSeconds(buffTime);
        if (playSO[playInput.playerIndex].buff)
        {
            animMan.ChangeAnimationState("Buff_WareOff");
            GameObject.Find("PlayerSFX").GetComponent<AudioManager>().Play("BuffPop");
            playSO[playInput.playerIndex].canMove = false;
            playSO[playInput.playerIndex].freeze = true;
            firePower = 0;
        }
        yield return new WaitForSeconds(1.6f);
        playSO[playInput.playerIndex].freeze = false;
        playSO[playInput.playerIndex].movementSpeed = playSO[playInput.playerIndex].basePlayerSpeed;
        firePower = oringalFLyPower;
        playSO[playInput.playerIndex].canMove = true;
        playSO[playInput.playerIndex].buff = false;
        playSO[playInput.playerIndex].invincble = false;
    }

    IEnumerator Attack(string anim) 
    {
        GameObject.Find("PlayerSFX").GetComponent<AudioManager>().Play("BuffModeSmash");
        attacking = true;
        animMan.ChangeAnimationState(anim);
        playSO[playInput.playerIndex].movementSpeed = fireMoveSpeed;
        pausedInput = playSO[playInput.playerIndex].moveInput;
        yield return new WaitForSeconds(.3f);
        //playInput.DeactivateInput();
        fireBoost = true;
        yield return new WaitForSeconds(attackTime - .3f);
        attackBox.SetActive(true);
        fireBoost = false;
        yield return new WaitForSeconds(endAttackTime - .3f);
        attackBox.SetActive(false);
        //playInput.ActivateInput();
        yield return new WaitForSeconds(attackWaitTime);
        playSO[playInput.playerIndex].movementSpeed = playSO[playInput.playerIndex].basePlayerSpeed;
        attacking = false;
    }
}
