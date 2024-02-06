using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationDisplayScript : MonoBehaviour
{
    public Player_SO[] playSO;
    AnimationManager animManager;
    PlayerInput playInput;
    public float stickThreshold = .5f;
    private bool horizontalInactive = true;
    // Start is called before the first frame update
    void Start()
    {
        animManager= gameObject.GetComponent<AnimationManager>();
        playInput= gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].moveInput != Vector2.zero && playSO[playInput.playerIndex].rolling == false)
        {

            if (playSO[playInput.playerIndex].moveInput.y > 0 && horizontalInactive)//checks if run backwards
            {
                animManager.ChangeAnimationState(animManager.Run_Backward);
            }

            else if (playSO[playInput.playerIndex].moveInput.y > stickThreshold && playSO[playInput.playerIndex].moveInput.x > 0)// checls if runing back right
            {
                animManager.ChangeAnimationState(animManager.Run_Backward_Right);
            }

            else if (playSO[playInput.playerIndex].moveInput.y > stickThreshold && playSO[playInput.playerIndex].moveInput.x < 0)// checks if running back left
            {
                animManager.ChangeAnimationState(animManager.Run_Backward_Left);
            }



            if (playSO[playInput.playerIndex].moveInput.y < stickThreshold && horizontalInactive)//checks if run forward
            {
                animManager.ChangeAnimationState(animManager.Run_Forward);
            }

            else if(playSO[playInput.playerIndex].moveInput.y < stickThreshold && playSO[playInput.playerIndex].moveInput.x > 0)
            {
                animManager.ChangeAnimationState(animManager.Run_Forward_Right);
            }

            else if (playSO[playInput.playerIndex].moveInput.y < stickThreshold && playSO[playInput.playerIndex].moveInput.x < 0)
            {
                animManager.ChangeAnimationState(animManager.Run_Forward_Left);
            }
        }
        else if (playSO[playInput.playerIndex].moveInput == Vector2.zero && playSO[playInput.playerIndex].health > 0)
        {
            animManager.ChangeAnimationState(animManager.IDLE);
        }



        if (playSO[playInput.playerIndex].moveInput.x < stickThreshold && playSO[playInput.playerIndex].moveInput.x > -stickThreshold)
        {
            horizontalInactive = true;
        }
        else
        {
            horizontalInactive= false;
        }
    }
}

