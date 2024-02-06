using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSuddenDeathManager : MonoBehaviour
{
    public Player_SO[] playSO;
    PlayerInput playInput;
    public MainSO mainSO;
    PlayerMagicBookManager magicBooksMan;
    private bool gate = false;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        magicBooksMan = gameObject.GetComponent<PlayerMagicBookManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.suddenDeathInitiated && playSO[playInput.playerIndex].hasDied == false && gate == false)
        {
            gameObject.transform.position = mainSO.playerSuddenDeathSpawnLocations[playInput.playerIndex];
            playSO[playInput.playerIndex].health = mainSO.suddenDeathHealth;
            playSO[playInput.playerIndex].livesLeft = mainSO.suddenDeathLives;
            playSO[playInput.playerIndex].gunChosen = playSO[playInput.playerIndex].oringalGunChosen;
            playSO[playInput.playerIndex].magicBooksHeld = 0;
            playSO[playInput.playerIndex].isTurret = false;
            playSO[playInput.playerIndex].buff = false;
            magicBooksMan.DisableLightning2();
            gate= true;

            if (playSO[playInput.playerIndex].perkOwned == 4)
            {
                playSO[playInput.playerIndex].health = mainSO.startingVampireHealth;
            }
            else
            {
                playSO[playInput.playerIndex].health = mainSO.suddenDeathHealth;
            }
        }

        if (mainSO.currentTimer > 0)
        {
            gate = false;
        }
    }
}
