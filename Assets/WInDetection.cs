using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WInDetection : MonoBehaviour
{
    public MainSO mainSO;
    public TextMeshProUGUI winText;
    public GameObject winUI;
    public Player_SO[] players;
    public GameObject gameOverUI;

    private void Start()
    {
        winText = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        if (mainSO.winner > 0 && mainSO.gameIsOver)
        {
            winText.text = (players[mainSO.winner - 1].playerName) + " has won!!!";
            winUI.SetActive(true);
            mainSO.gamesPlayed++;
        }
        else
        {
            gameOverUI.SetActive(false);
            winText.text = null;
        }
    }
}
