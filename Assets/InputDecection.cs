using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.XInput;

public class InputDecection : MonoBehaviour
{
    public PlayerInput playInput;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    public string GetControlType()
    {
        print(playInput.currentControlScheme);
        if (playInput.currentControlScheme == "Gamepad")
        {
            return "XboxSheet";
        }
        else
        {
            return "KeyBoardSheet";
        }
    }

}
