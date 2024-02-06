using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RenamingScript : MonoBehaviour
{
    PlayerInput playInput;
    public Player_SO[] playSO;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].hasDied == false)
        {
            gameObject.name = "player" + (playInput.playerIndex + 1);
        }
        else
        {
            gameObject.name = "DEAD";
        }
    }
}
