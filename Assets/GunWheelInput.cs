using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunWheelInput : MonoBehaviour
{
    InteractionInputDectection interactionInput;
    public Player_SO[] playSO;
    public float waitTime = .5f;
    private bool disabled = false;
    // Start is called before the first frame update
    void Start()
    {
        interactionInput = gameObject.GetComponent<InteractionInputDectection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionInput.interacted && playSO[interactionInput.playerSO].money >= 100 && disabled == false)
        {
            playSO[interactionInput.playerSO].wheelActivate = true;
            StartCoroutine(GambleDownTime());
        }
    }

    IEnumerator GambleDownTime()
    {
        disabled= true;
        yield return new WaitForSeconds(waitTime);
        disabled = false;
    }
}
