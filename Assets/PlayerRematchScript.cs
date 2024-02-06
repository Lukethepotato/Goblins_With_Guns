using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;

public class PlayerRematchScript : MonoBehaviour
{
    public MainSO MainSO;
    public Player_SO[] playSO;
    PlayerInput playInput;
    public BoxCollider2D boxCollider;
    PlayerMagicBookManager magicBooksMan;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        magicBooksMan = gameObject.GetComponent<PlayerMagicBookManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainSO.rematchSelected && playSO[playInput.playerIndex].rematchSetUpComplete == false)
        {
            gameObject.transform.position = MainSO.playersSpawnLocations[playInput.playerIndex];
            playSO[playInput.playerIndex].health = 100;
            playSO[playInput.playerIndex].hasDied = false;
            playSO[playInput.playerIndex].bulletsInChamber = 0;
            playSO[playInput.playerIndex].livesLeft = MainSO.stock;
            playSO[playInput.playerIndex].isTurret = false;
            playSO[playInput.playerIndex].magicBooksHeld = 0;
            playSO[playInput.playerIndex].burning = false;
            playSO[playInput.playerIndex].lightingGoblin= false;
            playSO[playInput.playerIndex].money = MainSO.startingCash;
            playSO[playInput.playerIndex].gunChosen = playSO[playInput.playerIndex].oringalGunChosen;
            boxCollider.enabled = true;
            magicBooksMan.DisableLightning2();
            playInput.ActivateInput();
            playSO[playInput.playerIndex].rematchSetUpComplete = true;
        }
    }
}
