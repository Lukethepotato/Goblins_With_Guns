using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPauseMan : MonoBehaviour
{
    PlayerInput playInput;
    public Player_SO[] playSO;
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.gamePaused)
        {
            playSO[playInput.playerIndex].rolling = false;
            playSO[playInput.playerIndex].inRollState = false;
        }
    }

    public void PauseButton(InputAction.CallbackContext cxt)
    {
        GameObject.Find("Pause Screen").GetComponent<PauseScreenMan>().Pause(playInput.playerIndex);
    }
}
