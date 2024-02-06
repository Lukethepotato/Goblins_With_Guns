using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactableCover : MonoBehaviour
{
    InteractionInputDectection interactionInput;
    public float time;
    private bool up = true;
    public GameObject cover;
    public Player_SO[] playSO;
    // Start is called before the first frame update
    void Start()
    {
        interactionInput = gameObject.GetComponent<InteractionInputDectection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionInput.interacted)
        {
            StartCoroutine(coverChnage());
            interactionInput.interacted = false;
        }
    }

    IEnumerator coverChnage()
    {
        playSO[interactionInput.playerSO].canMove= false;
        yield return new WaitForSeconds(time);
        playSO[interactionInput.playerSO].canMove = true;
        if (up)
        {
            cover.SetActive(false);
        }
        else
        {
            cover.SetActive(true);
        }
    }
}
