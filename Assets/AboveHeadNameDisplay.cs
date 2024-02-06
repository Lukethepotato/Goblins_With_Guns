using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class AboveHeadNameDisplay : MonoBehaviour
{
    public Player_SO[] playSO;
    public GameObject player;
    public PlayerInput playInput;
    TextMeshPro text;
    // Start is called before the first frame update
    void Start()
    {
        playInput = player.GetComponent<PlayerInput>();
        text = gameObject.GetComponent<TextMeshPro>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].health < 1)
        {
            text.enabled = false;
        }
        else
        {
            text.enabled = true;
        }
        text.text = playSO[playInput.playerIndex].playerName;
    }
}
