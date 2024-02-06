using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PerkMan : MonoBehaviour
{
    public Player_SO[] playerSO;
    PlayerInput playInput;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I < playerSO[playInput.playerIndex].perks.Length; I++) 
        { 
            if (playerSO[playInput.playerIndex].perks[I] == true)
            {
                playerSO[playInput.playerIndex].perkOwned = I;
            }
        }
    }
}
