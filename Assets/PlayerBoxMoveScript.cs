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
    public bool nextback = false;
    public Vector2 nextBackPos;
    // Start is called before the first frame update
    void Start()
    {
        rectTrans = gameObject.GetComponent<RectTransform>();
        playInput = playInputObject.GetComponent<PlayerInput>();
        SR = gameObject.GetComponent<SpriteRenderer>();

        LeanTween.move(rectTrans, mainSO.playerBoxLocations[playInput.playerIndex], 0);
    }

    private void Update()
    {
        if (nextback)
        {
            LeanTween.move(rectTrans, new Vector2(mainSO.playerBoxLocations[playInput.playerIndex].x + nextBackPos.x, nextBackPos.y), 0);
        }
    }
}
