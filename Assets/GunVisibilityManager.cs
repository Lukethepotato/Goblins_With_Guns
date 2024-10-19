using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunVisibilityManager : MonoBehaviour
{
    public GameObject gun;
    public Player_SO[] playSO;
    PlayerInput playInput;
    public MainSO mainSO;
    private bool gate = false;
    public SpriteRenderer[] gunSR;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.setUpOver && gate == false)
        {
            gate = true;
            gunSR[playSO[playInput.playerIndex].gunChosen] = gun.GetComponentInChildren<SpriteRenderer>();
        }

        if (playSO[playInput.playerIndex].health < 1)
        {
            gunSR[playSO[playInput.playerIndex].gunChosen].enabled = false;

        }
        else if (playSO[playInput.playerIndex].rolling)
        {
            gunSR[playSO[playInput.playerIndex].gunChosen].enabled = false;
        }
        else
        {
            gunSR[playSO[playInput.playerIndex].gunChosen].enabled = true;
        }

        if (playSO[playInput.playerIndex].isTurret)
        {
            gunSR[playSO[playInput.playerIndex].gunChosen].enabled = false;
        }

    }
}
