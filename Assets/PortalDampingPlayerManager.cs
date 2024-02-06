using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PortalDampingPlayerManager : MonoBehaviour
{
    public int playIndex;
    private PlayerInput playInput;
    public Player_SO[] playSO;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        playIndex = playInput.playerIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void telaport()
    {
        playSO[playIndex].telaporting = true;
    }
}
