using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PerkMenuManager : MonoBehaviour
{
    public Player_SO[] playSO;
    public GameObject player;
    public PlayerInput playInput;
    public MainSO mainSO;
    private int I = 0;
    public List<int> perksSelected = new List<int>();
    private int lastPerk;
    // Start is called before the first frame update
    void Start()
    {
        playInput = player.GetComponent<PlayerInput>();
        lastPerk = 0;
        //playSO[playInput.playerIndex].perks.Length = mainSO.perksAllowed;
    }

    // Update is called once per frame
    void Update()
    {
        if (perksSelected.Count > mainSO.perksAllowed)
        {
            for (int I = mainSO.perksAllowed; I <= perksSelected.Count - 1; I++)
            {

                playSO[playInput.playerIndex].perks[perksSelected[I]] = false;
                print(perksSelected[I].ToString());
                perksSelected.RemoveAt(I);
            }
        }

        print(perksSelected[0].ToString());

    }

    public void PerkSelection(int perk)
    {
        if (perksSelected.Contains(perk) == false)
        {
            if (mainSO.perksAllowed > 1)
            {
                for (int perksBehind = 0; perksBehind <= mainSO.perksAllowed; perksBehind++)
                {

                    //perksSelected[perksBehind] = perksBehind - 1;
                    perksSelected.Insert(perksBehind + 1, perksSelected[perksBehind + 1]);
                }
            }

            perksSelected.Insert(0, perk);
            //playSO[playInput.playerIndex].perks[perk] = true;


            if (mainSO.perksAllowed == 1)
            {
                playSO[playInput.playerIndex].perks[lastPerk] = false;
                lastPerk = perk;
            }
        }

        playSO[playInput.playerIndex].perks[perk] = true;
        //playSO[playInput.playerIndex].perks[perk] = true;

    }
}
