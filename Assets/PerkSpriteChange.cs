using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PerkSpriteChange : MonoBehaviour
{
    public Image image;
    public int perkNum;
    public Player_SO[] playSO;
    public PlayerInput input;
    public GameObject player;
    public Color activeColor;
    public Color inactiveColor;
    // Start is called before the first frame update
    void Start()
    {
       image = gameObject.GetComponent<Image>();
       input = player.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[input.playerIndex].perks[perkNum] == true)
        {
            image.color = activeColor;
        }
        else
        {
            image.color = inactiveColor;
        }
    }
}
