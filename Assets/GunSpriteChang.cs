using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GunSpriteChang : MonoBehaviour
{
    public Player_SO[] playSO;
    public int gunNum;
    public GameObject playerObject;
    public PlayerInput playerInput;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = playerObject.GetComponent<PlayerInput>();
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playerInput.playerIndex].gunChosen == gunNum)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
    }
}
