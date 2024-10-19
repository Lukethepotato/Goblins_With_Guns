using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultsPlayerNamesDisplay : MonoBehaviour
{
    public Player_SO[] playSO;
    public GameObject[] playerNameTexts;
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I < mainSO.playersReadiedUp; I++)
        {
            playerNameTexts[I].GetComponent<TextMeshProUGUI>().text = playSO[mainSO.rankings[I]].playerName;
        }
    }
}
