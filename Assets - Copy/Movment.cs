using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Movment : MonoBehaviour
{
    public Vector2 moveInput = Vector2.zero;
    Rigidbody2D RB;
    private Vector2 MoveDirection;
    public Player_SO[] playSOs;
    PlayerInput playInput;
    public Vector2 curentInput;

    void Start()
    {
        RB= gameObject.GetComponent<Rigidbody2D>();
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    public void OnMove(InputAction.CallbackContext cxt)
    {
        if (playSOs[playInput.playerIndex].rolling == false && playInput != null)
        {
            moveInput = cxt.ReadValue<Vector2>();
        }

        curentInput = cxt.ReadValue<Vector2>();
    }

    private void Update()
    {
        if (playSOs[playInput.playerIndex].rolling)
        {
            MoveDirection = new Vector2(moveInput.x, moveInput.y).normalized;
        }
        else
        {
            MoveDirection = new Vector2(curentInput.x, curentInput.y).normalized;
        }
        

        playSOs[playInput.playerIndex].moveInput = moveInput;

        if (curentInput == Vector2.zero && playSOs[playInput.playerIndex].rolling == false)
        {
            moveInput = Vector2.zero;
        }

        if (playSOs[playInput.playerIndex].isTurret)
        {
            moveInput = Vector2.zero;
            MoveDirection = Vector2.zero;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (playSOs[playInput.playerIndex].canMove)
        {
            RB.velocity = new Vector2(MoveDirection.x * playSOs[playInput.playerIndex].movementSpeed, MoveDirection.y * playSOs[playInput.playerIndex].movementSpeed);
        }
    }


}
