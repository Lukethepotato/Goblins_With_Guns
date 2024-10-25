using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LetterButtonScript : MonoBehaviour
{
    public Player_SO[] playSO;
    public PlayerInput playInput;
    public GameObject playInputObject;
    public int MaxLetters = 3;
    // Start is called before the first frame update
    void Start()
    {
        playInput = playInputObject.GetComponent<PlayerInput>();
    }

    public void OnLetterClick(string letter)
    {
        if(playSO[playInput.playerIndex].letterIn != MaxLetters)
        {
            playSO[playInput.playerIndex].playerName += letter;
            playSO[playInput.playerIndex].letterIn++;

            GameObject.Find("UI").GetComponent<AudioManager>().Play("ClickSound2");
        }
    }
}
