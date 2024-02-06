using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Aiming : MonoBehaviour
{
    public float controllerDeadzone = 0.5f;
    public float gamepadRotaionSmoothing = 1000f;

    public bool isGamepad;

    public Vector2 aim;

    private PlayerInput PlayerInput;

    public Player_SO[] playSO;

    Rigidbody2D RB;

    private Transform trams;

    public GameObject aimCircle;

    public float bulletDistance;

    private bool aimCourtineComplete = true;

    public Vector2 move;

    public int rocketMult;


    private void Start()
    {
        //playerControls = new InputActions();
        PlayerInput = gameObject.GetComponent<PlayerInput>();
        trams= gameObject.GetComponent<Transform>();
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playSO[PlayerInput.playerIndex].Aim = aim;
        playSO[PlayerInput.playerIndex].isGamePad = isGamepad;

        if (aim.x > 20 || aim.y > 20)
        {
            isGamepad = false;
        }

        if (isGamepad)
        {
            if (playSO[PlayerInput.playerIndex].joyStickDown == false && playSO[PlayerInput.playerIndex].rolling == false && playSO[PlayerInput.playerIndex].gunChosen != 11)
            {
                aimCircle.transform.position = new Vector2(aim.x * bulletDistance + gameObject.transform.position.x, aim.y * bulletDistance + gameObject.transform.position.y);
            }else if (playSO[PlayerInput.playerIndex].joyStickDown && playSO[PlayerInput.playerIndex].rolling == false && playSO[PlayerInput.playerIndex].gunChosen != 11 || playSO[PlayerInput.playerIndex].rolling && playSO[PlayerInput.playerIndex].perks[5])
            {
                aimCircle.transform.position = new Vector2(move.x * bulletDistance + gameObject.transform.position.x, move.y * bulletDistance + gameObject.transform.position.y);
            }
            else if (playSO[PlayerInput.playerIndex].rolling || playSO[PlayerInput.playerIndex].gunChosen == 11)
            {
                aimCircle.transform.position = new Vector2(-move.x * bulletDistance + gameObject.transform.position.x, -move.y * bulletDistance + gameObject.transform.position.y);
            }

            if (aim.x > -.7 && aim.x < .1 && aim.y > -.7 && aim.y < .1)
            {
                playSO[PlayerInput.playerIndex].joyStickDown = true;
            }else
            {
                playSO[PlayerInput.playerIndex].joyStickDown =false;
            }

        }
        else
        {
            if (playSO[PlayerInput.playerIndex].rolling == false)
            {
                aimCircle.transform.position = Camera.main.ScreenToWorldPoint(aim);
            }
            else 
            {
                aimCircle.transform.position = new Vector2(move.x * bulletDistance + gameObject.transform.position.x, move.y * bulletDistance + gameObject.transform.position.y);
            }
        }
    }

    public void HandleInput(InputAction.CallbackContext context)
    {
        aim = context.ReadValue<Vector2>();
    }

    public void Movement(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }
}
