using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RankingManager : MonoBehaviour
{
    public MainSO mainSO;
    public PlayerInput playerInput;
    public Player_SO[] playSO;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = gameObject.GetComponent<PlayerInput>();
        mainSO.rankings.Add(playerInput.playerIndex); 
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I <= mainSO.playersReadiedUp - 1; I++)
        {
            if (playSO[I].livesLeft < playSO[playerInput.playerIndex].livesLeft && mainSO.rankings.IndexOf(I) < mainSO.rankings.IndexOf(playerInput.playerIndex) && I != playerInput.playerIndex)
            {
                int replacedPlaySO = mainSO.rankings.IndexOf(I); 

                mainSO.rankings.RemoveAt(replacedPlaySO);
                mainSO.rankings.Insert(mainSO.rankings.IndexOf(playerInput.playerIndex), I);
                mainSO.rankings.Remove(playerInput.playerIndex);
                mainSO.rankings.Insert(replacedPlaySO, playerInput.playerIndex);

            }else if (playSO[I].livesLeft == playSO[playerInput.playerIndex].livesLeft && playSO[I].health < playSO[playerInput.playerIndex].health && mainSO.rankings.IndexOf(I) < mainSO.rankings.IndexOf(playerInput.playerIndex) && I != playerInput.playerIndex)
            {
                int replacedPlaySO = mainSO.rankings.IndexOf(I);

                mainSO.rankings.RemoveAt(replacedPlaySO);
                mainSO.rankings.Insert(mainSO.rankings.IndexOf(playerInput.playerIndex), I);
                mainSO.rankings.Remove(playerInput.playerIndex);
                mainSO.rankings.Insert(replacedPlaySO, playerInput.playerIndex);

            }
        }
    }
}
