using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Photon;
using Photon.Pun;

public class aimingAnimationDisplay : MonoBehaviour
{
    public Player_SO[] playSO;
    AnimationManager animManager;
    PlayerInput playInput;
    PlayerMagicBookManager magicBookManager;
    public float stickThreshold = .5f;
    private bool horizontalInactive = true;
    public GameObject aimBall;
    public Vector2 aim;
    private bool aimYInactive;
    private bool aimXInactive;
    public int playIndex;
    public BuffGoblinManager buffMan;

    // Start is called before the first frame update
    void Start()
    {
        magicBookManager = gameObject.GetComponent<PlayerMagicBookManager>();
        animManager = gameObject.GetComponent<AnimationManager>();
        playInput = gameObject.GetComponent<PlayerInput>();
        buffMan = gameObject.GetComponent<BuffGoblinManager>();
        
        playIndex = playInput.playerIndex;
        
    }

    void Update()
    {

        aim = new Vector2(aimBall.transform.position.x - gameObject.transform.position.x, aimBall.transform.position.y - gameObject.transform.position.y);

        if (aim.y < stickThreshold && aim.y > -stickThreshold) 
        {
            aimYInactive = true;
        }else
        {
            aimYInactive = false;
        }

        if (aim.x < stickThreshold && aim.x > -stickThreshold)
        {
            aimXInactive = true;
        }
        else
        {
            aimXInactive = false;
        }

        if (playSO[playInput.playerIndex].rolling == false && playSO[playInput.playerIndex].lightingGoblin ==false && playSO[playInput.playerIndex].buff == false && playSO[playInput.playerIndex].touchingSewage == false)
        {
            if (aim.y > stickThreshold && aimXInactive && playSO[playIndex].moveInput != Vector2.zero)
            {
                animManager.ChangeAnimationState(animManager.Run_Backward);
            }
            else if (aim.y > stickThreshold && aim.x > stickThreshold && playSO[playIndex].moveInput != Vector2.zero)
            {
                animManager.ChangeAnimationState(animManager.Run_Backward_Right);
            }
            else if (aim.y > stickThreshold && aim.x < -stickThreshold && playSO[playIndex].moveInput != Vector2.zero)
            {
                animManager.ChangeAnimationState(animManager.Run_Backward_Left);
            }
            else if (aim.y < stickThreshold && aimXInactive && playSO[playIndex].moveInput != Vector2.zero)
            {
                animManager.ChangeAnimationState(animManager.Run_Forward);
            }
            else if (aim.y < stickThreshold && aim.x > stickThreshold && playSO[playIndex].moveInput != Vector2.zero)
            {
                animManager.ChangeAnimationState(animManager.Run_Forward_Right);
            }
            else if (aim.y < stickThreshold && aim.x < -stickThreshold && playSO[playIndex].moveInput != Vector2.zero)
            {
                animManager.ChangeAnimationState(animManager.Run_Forward_Left);
            }
            else if (playSO[playIndex].moveInput == Vector2.zero && playSO[playIndex].health > 0 && playSO[playIndex])
            {
                animManager.ChangeAnimationState(animManager.IDLE);
            }
        }else if (playSO[playInput.playerIndex].buff && playSO[playInput.playerIndex].canMove && buffMan.attacking == false)
        {
            if (playSO[playIndex].moveInput.y > stickThreshold && playSO[playIndex].moveInput.x < stickThreshold && playSO[playIndex].moveInput.x > -stickThreshold)
            {
                animManager.ChangeAnimationState("Buff_Up");
            }else if (playSO[playIndex].moveInput.y < -stickThreshold && playSO[playIndex].moveInput.x < stickThreshold && playSO[playIndex].moveInput.x > -stickThreshold)
            {
                animManager.ChangeAnimationState("Buff_Down");
            }
            else if (playSO[playIndex].moveInput.x < -stickThreshold && playSO[playIndex].moveInput.y < stickThreshold && playSO[playIndex].moveInput.y > -stickThreshold)
            {
                animManager.ChangeAnimationState("Buff_Left");
            }
            else if (playSO[playIndex].moveInput.x > stickThreshold && playSO[playIndex].moveInput.y < stickThreshold && playSO[playIndex].moveInput.y > -stickThreshold)
            {
                animManager.ChangeAnimationState("Buff_Right");
            }
            else if (playSO[playIndex].health > 0 && playSO[playIndex].moveInput == Vector2.zero)
            {
                animManager.ChangeAnimationState("Buff_Idle");
            }
        }
    }
}

