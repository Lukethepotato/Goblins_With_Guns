using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponMenuManager : MonoBehaviour
{
    public Player_SO[] playSO;
    public GameObject player;
    public PlayerInput playInput;
    // Start is called before the first frame update
    void Start()
    {
        playInput= player.GetComponent<PlayerInput>();
    }

    public void GunSelection(int gunSelected)
    {
        playSO[playInput.playerIndex].gunChosen= gunSelected;
    }
}
