using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PerkMovmentTweaks : MonoBehaviour
{
    public Player_SO[] playSO;
    PlayerInput playInput;
    public PerkMovmentSO[] speedSO;
    public MainSO mainSO;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpeed()
    {
        if (playSO[playInput.playerIndex].state == 0)
        {
            int perkNum = playSO[playInput.playerIndex].perkOwned;
            
            if (playSO[playInput.playerIndex].bloodRaged)
            {
                playSO[playInput.playerIndex].movementSpeed = mainSO.bloodRagedSpeed;
            }
            else if (speedSO[perkNum] != null)
            {
                playSO[playInput.playerIndex].movementSpeed = speedSO[perkNum].runSpeed;

            }
            else
            {
                playSO[playInput.playerIndex].movementSpeed = mainSO.baseMoveSpeed;
            }

            if (count == 0 && mainSO.setUpOver)
            {
                playSO[playInput.playerIndex].basePlayerSpeed = playSO[playInput.playerIndex].movementSpeed;
                count++;
            }

        }
    }
}
