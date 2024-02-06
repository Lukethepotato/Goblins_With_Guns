using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class InteractDisplay : MonoBehaviour
{
    public Player_SO[] playSO;
    public AnimationManager interAnimMan;
    public GameObject interactDisplay;
    private bool inZone = false;
    private bool interacted = false;
    private InteractionInputDectection interactionDectection;
    public PlayerInput playInput;
    // Start is called before the first frame update
    void Start()
    {
        interAnimMan = interactDisplay.GetComponent<AnimationManager>();
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interacted)
        {
            interactDisplay.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable") && interacted == false)
        {
            interactDisplay.SetActive(true);
            interactionDectection = collision.gameObject.GetComponent<InteractionInputDectection>();
            inZone= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Interactable"))
        {
            interactDisplay.SetActive(false);
            interactionDectection = null;
            inZone = false;
        }
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (inZone = true && interacted == false)
        {
            interacted= true;
            interactionDectection.interaction(playInput.playerIndex);
            print("Interacted");
        }
    }
}
