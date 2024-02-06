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
            magicBooksMan.DisableLightning2();
            gate= true;
        }

        if (mainSO.currentTimer > 0)
        {
            gate = false;
        }
    }
}
