using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class InteractDisplay : MonoBehaviour
{
    public Player_SO[] playSO;
    public GameObject interactDisplay;
    public SetTextToTextBox setText;
    public bool inZone = false;
    private bool inHoldZone = false;
    private bool interacted = false;
    private bool holding = false;
    private InteractionInputDectection interactionDectection;
    public PlayerInput playInput;

    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        setText = gameObject.GetComponentInChildren<SetTextToTextBox>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable") && interacted == false)
        {
            setText.DisplayText();
            interactionDectection = collision.gameObject.GetComponent<InteractionInputDectection>();
            inZone= true;
        }
        else
        {
            interacted = false;
        }

        if (collision.gameObject.CompareTag("HoldInteractable") && holding == false)
        {
            setText.DisplayText();
            interactionDectection = collision.gameObject.GetComponent<InteractionInputDectection>();
            inHoldZone = true;
        }
        else
        {
            holding= false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            setText.UnDisplayText();
            interactionDectection = null;
            inZone = false;
        }

        if (collision.gameObject.CompareTag("HoldInteractable"))
        {
            if (interactionDectection != null)
            {
                interactionDectection.releaseInteraction(playInput.playerIndex);
            }
            setText.UnDisplayText();
            interactionDectection = null;
            playSO[playInput.playerIndex].freeze = false;
            playSO[playInput.playerIndex].state = 0;
            inHoldZone = false;

        }
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (inZone == true && interacted == false)
        {
            setText.UnDisplayText();
            interacted = true;
            interactionDectection.interaction(playInput.playerIndex);
            print("Interacted");
        }

        if (inHoldZone == true && ctx.started)
        {
            interactionDectection.holdInteraction(playInput.playerIndex);
            holding= true;
        }else if (ctx.canceled && holding == true && interactionDectection != null)
        {
            interactionDectection.releaseInteraction(playInput.playerIndex);
            holding= false;
        }
    }

}
