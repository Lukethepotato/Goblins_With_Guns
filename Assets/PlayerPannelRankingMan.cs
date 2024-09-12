using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPannelRankingMan : MonoBehaviour
{
    RectTransform rectTrans;
    public Vector2[] rankingLocations;
    public MainSO mainSO;
    public int player;
    public TextMeshProUGUI nameText;
    public Player_SO[] playSO;
    // Start is called before the first frame update
    void Start()
    {
        rectTrans = gameObject.GetComponent<RectTransform>();
        nameText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        LeanTween.move(rectTrans, rankingLocations[mainSO.rankings.IndexOf(player)], .75f);
        nameText.text = playSO[player].playerName;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.gamePaused == false)
        {
            LeanTween.init(800);
            LeanTween.move(rectTrans, rankingLocations[mainSO.rankings.IndexOf(player)], .75f);
            nameText.text = playSO[player].playerName;
        }
        
    }
}
