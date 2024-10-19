using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEngine.SceneManagement;

public class SetTextToTextBox : MonoBehaviour
{
    [SerializeField] private int deviceType;

    public PlayerInput playInput;
    public TextMeshPro textBox;
    public string Text = "to interact";
    private string deviceText;
    public MainSO mainSO;
    public string casinoText;
    public Player_SO[] playerSO;
    public InteractDisplay interactDisplay;
    public GameObject parent;

    public bool pressDisabled =false;

    private string lastInputType;
    // Start is called before the first frame update

    private void Start()
    {
        playInput = gameObject.GetComponentInParent<PlayerInput>();
        textBox = gameObject.GetComponent<TextMeshPro>();
        interactDisplay = parent.GetComponent<InteractDisplay>();
    }

    private void Update()
    {
        
    }

    public void DisplayText(string inputType)
    {
        textBox.text = inputType;
        lastInputType = inputType;
    }

    public void UnDisplayText(bool ExitTriggerDisable)
    {
        if (ExitTriggerDisable)
        {
            textBox.text = "";
        }
        else
        {
            StartCoroutine(PressDisableCourtine());
        }
    }

    IEnumerator PressDisableCourtine()
    {
        textBox.text = "";
        pressDisabled = true;
        if (mainSO.map == 10 && interactDisplay.inZone && playerSO[playInput.playerIndex].money < 100)
        {
            if (textBox.text != "not enough money")
            {
                GameObject.Find("SFX").GetComponent<AudioManager>().Play("CantInteract");
            }
            textBox.text = "not enough money";
        }
        yield return new WaitForSeconds(.5f);
        pressDisabled = false;
        if (interactDisplay.inZone)
        {
            textBox.text = lastInputType;
        }
        else
        {
            textBox.text = "";
        }
    }
}
