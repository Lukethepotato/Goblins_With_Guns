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
    }

    public void UnDisplayText()
    {
        if (mainSO.map == 10 && playerSO[playInput.playerIndex].money < 100 && interactDisplay.inZone)
        {
            StartCoroutine(NotEnoughMoney());
        }
        else
        {
            textBox.text = "";
        }
    }

    IEnumerator NotEnoughMoney()
    {
        if (interactDisplay.inZone)
        {
            textBox.text = "not enough money";
        }
        else
        {
            textBox.text = "";
        }
        yield return new WaitForSeconds(.5f);
        textBox.text = "";
    }
}
