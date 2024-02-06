using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class NameDisplay : MonoBehaviour
{
    public Player_SO[] playSO;
    public PlayerInput playInput;
    public GameObject playInputGameObject;
    TextMeshProUGUI nameDisplayText;
    // Start is called before the first frame update
    void Start()
    {
        playInput = playInputGameObject.GetComponent<PlayerInput>();
        nameDisplayText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        nameDisplayText.text = playSO[playInput.playerIndex].playerName;
    }
}
