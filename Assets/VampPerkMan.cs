using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VampPerkMan : MonoBehaviour
{
    public Player_SO[] playSO;
    public PlayerInput playInput;
    public MainSO mainSO;
    public float maxHealth;
    public float maxNormHealth;
    public float maxVampHealth = 200;
    
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].perkOwned == 4)
        {
            maxHealth = maxVampHealth;
        }else if (playSO[playInput.playerIndex].perkOwned == 2)
        {
            maxHealth = mainSO.scoutHealth;
        }
        else
        {
            maxHealth = maxNormHealth;
        }

        
        if (mainSO.setUpOver == false && playSO[playInput.playerIndex].perkOwned == 4 || mainSO.rematchSelected && playSO[playInput.playerIndex].perkOwned == 4)
        {
            playSO[playInput.playerIndex].health = mainSO.startingVampireHealth;
        }else if (mainSO.setUpOver == false && playSO[playInput.playerIndex].perkOwned == 2 || mainSO.rematchSelected && playSO[playInput.playerIndex].perkOwned == 2)
        {
            playSO[playInput.playerIndex].health = mainSO.scoutHealth;
        }
        else if (mainSO.setUpOver == false)
        {
            playSO[playInput.playerIndex].health = 100;
        }


        if (playSO[playInput.playerIndex].health > maxHealth)
        {
            playSO[playInput.playerIndex].health = maxHealth;
        }
        
    }
}
