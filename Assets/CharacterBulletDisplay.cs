using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterBulletDisplay : MonoBehaviour
{
    public TextMeshPro bulletText;
    public Player_SO[] playSO;
    public GameObject player;
    public PlayerInput playInput;
    public GameObject textObject;
    public GameObject animObject;
    public AnimationManager animManager;
    private int pastLifes;



    // Start is called before the first frame update
    void Start()
    {
        playInput = player.GetComponent<PlayerInput>();
        bulletText = textObject.GetComponent<TextMeshPro>();
        animManager = animObject.GetComponent<AnimationManager>();
        animManager.ChangeAnimationState("ReloadIdle");
        pastLifes = playSO[playInput.playerIndex].livesLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].isReloading == false)
        {
            bulletText.text = playSO[playInput.playerIndex].bulletsInChamber.ToString();
            animManager.ChangeAnimationState("ReloadIdle");
        }
        else
        {
            bulletText.text = "";
            animManager.ChangeAnimationState("ReloadAnim");
        }
    }
}
