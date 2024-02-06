using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFreezeManager : MonoBehaviour
{
    public MainSO mainSO;
    Rigidbody2D RB;

    public Player_SO[] playSO;
    PlayerInput playInput;
    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.freezeAllPlayer)
        {
            RB.drag = 100000000000;
        }
        else if (playSO[playInput.playerIndex].freeze == false)
        {
            RB.drag = 0;
        }

        if (playSO[playInput.playerIndex].freeze)
        {
            RB.drag = 100000000000;
        }
    }
}
