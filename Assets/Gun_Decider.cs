using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun_Decider : MonoBehaviour
{
    public GameObject[] guns;
    public PlayerInput playInput;
    public Player_SO[] playSO;
    public GameObject player;
    public MainSO mainSO;
    private bool gate = false;
    // Start is called before the first frame update
    void Start()
    {
        playInput = player.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    { 
       if (playSO[playInput.playerIndex].state == 0) 
       {
           guns[playSO[playInput.playerIndex].gunChosen].SetActive(true);
       }
       else
       {
           guns[playSO[playInput.playerIndex].gunChosen].SetActive(false);
       }

       if (gate == false)
       {
           playSO[playInput.playerIndex].oringalGunChosen = playSO[playInput.playerIndex].gunChosen;
           gate = true;
            print("gyfei");
       }

       if (playSO[playInput.playerIndex].isTurret)
       {
            guns[3].SetActive(true);
            guns[playSO[playInput.playerIndex].oringalGunChosen].SetActive(false);
       }
       else
       {
            for (int I = 0; I < playSO[playInput.playerIndex].gunChosen; I++)
            {
                guns[I].SetActive(false);
            }

            for (int b = playSO[playInput.playerIndex].gunChosen + 1; b > playSO[playInput.playerIndex].gunChosen && b < guns.Length; b++)
            {
                guns[b].SetActive(false);
            }
       }

    }
}
