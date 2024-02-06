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
       }

        if (playSO[playInput.playerIndex].gunChosen == 0)
        {
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            guns[4].SetActive(false);
            guns[5].SetActive(false);
            guns[6].SetActive(false);
            guns[7].SetActive(false);

        }

        if (playSO[playInput.playerIndex].gunChosen == 1)
        {
            guns[0].SetActive(false);
            guns[2].SetActive(false);
            guns[4].SetActive(false);
            guns[5].SetActive(false);
            guns[6].SetActive(false);
            guns[7].SetActive(false);
        }

        if (playSO[playInput.playerIndex].gunChosen == 2)
        {
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[4].SetActive(false);
            guns[5].SetActive(false);
            guns[6].SetActive(false);
            guns[7].SetActive(false);
        }

        if (playSO[playInput.playerIndex].gunChosen == 4)
        {
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            guns[5].SetActive(false);
            guns[6].SetActive(false);
            guns[7].SetActive(false);
        }

        if (playSO[playInput.playerIndex].gunChosen == 5)
        {
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            guns[4].SetActive(false);
            guns[6].SetActive(false);
            guns[7].SetActive(false);
        }

        if (playSO[playInput.playerIndex].gunChosen == 6)
        {
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            guns[4].SetActive(false);
            guns[5].SetActive(false);
            guns[7].SetActive(false);
        }

        if (playSO[playInput.playerIndex].gunChosen == 7)
        {
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            guns[4].SetActive(false);
            guns[5].SetActive(false);
            guns[6].SetActive(false);
        }
    }
}
