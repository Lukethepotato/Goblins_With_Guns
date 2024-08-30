using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PerkMenuSingle : MonoBehaviour
{
    public Player_SO[] playSO;
    public GameObject player;
    public PlayerInput playInput;
    public MainSO mainSO;
    private int lastPerk = 0;
    LockedPercMain lockedPerkMain;
    public GameObject[] perks;


    // Start is called before the first frame update
    void Start()
    {
        playInput = player.GetComponent<PlayerInput>();
        lockedPerkMain = gameObject.GetComponent<LockedPercMain>();

        playSO[playInput.playerIndex].perks[0] = true;
        
        for (int I = 0; I < playSO[playInput.playerIndex].perks.Length; I++)
        {
            playSO[playInput.playerIndex].perks[I] = false;
        }

        playSO[playInput.playerIndex].perks[0] = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PerkSelection(int perk)
    {
        if (lockedPerkMain.lockedPerks[perk] == false)
        {
            playSO[playInput.playerIndex].perks[lastPerk] = false;
            playSO[playInput.playerIndex].perks[perk] = true;
            lastPerk = perk;
        }
    }
}
