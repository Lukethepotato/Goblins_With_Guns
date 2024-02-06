using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StatesManager : MonoBehaviour
{
    public Player_SO[] playSO;
    PlayerInput playInput;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].lightingGoblin || playSO[playInput.playerIndex].buff)
        {
            playSO[playInput.playerIndex].state = 1;

        }
        else
        {
            playSO[playInput.playerIndex].state = 0;
            // zero is for normal
        }
    }
}
