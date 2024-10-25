using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BackSpace_ButtonScript : MonoBehaviour
{
    public Player_SO[] playSO;
    public PlayerInput playInput;
    public GameObject playInputObject;

    // Start is called before the first frame update
    void Start()
    {
        playInput = playInputObject.GetComponent<PlayerInput>();
    }

    public void OnBackSpacePressed()
    {
        playSO[playInput.playerIndex].playerName = playSO[playInput.playerIndex].playerName.Remove(playSO[playInput.playerIndex].playerName.Length - 1);
        if (playSO[playInput.playerIndex].letterIn != 0)
        {
            playSO[playInput.playerIndex].letterIn--;
        }
        GameObject.Find("UI").GetComponent<AudioManager>().Play("ClickSound2");
    }
}
