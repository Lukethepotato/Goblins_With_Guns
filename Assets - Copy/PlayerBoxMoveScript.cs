using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class PlayerBoxMoveScript : MonoBehaviour
{
    public PlayerInput playInput;
    public GameObject playInputObject;
    public MainSO mainSO;
    SpriteRenderer SR;
    RectTransform rectTrans;
    // Start is called before the first frame update
    void Start()
    {
        rectTrans = gameObject.GetComponent<RectTransform>();
        playInput = playInputObject.GetComponent<PlayerInput>();
        SR = gameObject.GetComponent<SpriteRenderer>();

        LeanTween.move(rectTrans, mainSO.playerBoxLocations[playInput.playerIndex], 0);
    }
}
