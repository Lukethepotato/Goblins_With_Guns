using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using XInputDotNetPure;

public class SentryGunDisabling : MonoBehaviour
{
    public GameObject gunsEmpty;
    PlayerInput playInput;
    public Player_SO[] playSO; 
    
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].perkOwned == 10 && playSO[playInput.playerIndex].isTurret == false) 
        {
            gunsEmpty.SetActive(false);
        }else
        {
            gunsEmpty.SetActive(true);
        }
    }
}
