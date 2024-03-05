using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PerkButtonMan : MonoBehaviour
{
    public Player_SO[] playSO;
    public PlayerInput playInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Perk(InputAction.CallbackContext ctx)
    {
        if (ctx.started && playSO[playInput.playerIndex].perkButPressed == false)
        {
            playSO[playInput.playerIndex].perkButPressed = true;
        }
        if (ctx.canceled && playSO[playInput.playerIndex].perkButPressed)
        {
            playSO[playInput.playerIndex].perkButPressed = false;
        }
    }
}
