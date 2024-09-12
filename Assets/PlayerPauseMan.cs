using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class PlayerPauseMan : MonoBehaviour
{
    PlayerInput playInput;
    public Player_SO[] playSO;
    public MainSO mainSO;
    public GameObject eventSystem;
    public InputSystemUIInputModule inputModule;

    public GameObject pauseObject;
    public PauseScreenMan pauseScript;
    private bool gate = false;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        pauseScript = pauseObject.GetComponent<PauseScreenMan>();


        inputModule = eventSystem.GetComponent<InputSystemUIInputModule>();
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
        playInput.uiInputModule = inputModule;
        pauseScript.Pause();
    }
}
