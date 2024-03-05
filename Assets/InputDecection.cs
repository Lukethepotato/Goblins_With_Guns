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

    public string DisplayButton(string inputType)
    {
        if (inputType == "interact")
        {
            return "<sprite=" + "\"" + GetControlType() + "\"" + " name=\"interact\">";
        }
        else if (inputType == "fire")
        {
            return "<sprite=" + "\"" + GetControlType() + "\"" + " name=\"fire\">";
        }
        else if (inputType == "reload")
        {
            return "<sprite=" + "\"" + GetControlType() + "\"" + " name=\"reload\">";
        }
        else
        {
            return "<sprite=" + "\"" + GetControlType() + "\"" + " name=\"roll\">";
        }
        print("Displayed");
    }

}
