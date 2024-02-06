using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDamageMultiplierMan : MonoBehaviour
{
    public Player_SO[] playSO;
    PlayerInput playInput;
    public float glassCannonMult;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        playSO[playInput.playerIndex].damageDealtMult = 1;
        playSO[playInput.playerIndex].damageTakeMult = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].perkOwned == 7) 
        {
            playSO[playInput.playerIndex].damageDealtMult= glassCannonMult;
            playSO[playInput.playerIndex].damageTakeMult = glassCannonMult;
        }
    }
}
