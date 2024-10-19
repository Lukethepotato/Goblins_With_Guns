using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using XInputDotNetPure;

public class PLaySO_Reset : MonoBehaviour
{
    public Player_SO[] playSO;
    public GameObject playInputObject;
    public PlayerInput playInput;
    public MainSO mainSO;
    public float startingHealth = 100;
    public float baseSpeed;
    // Start is called before the first frame update
    private void Start()
    {

        playInput = playInputObject.GetComponent<PlayerInput>();
        playSO[playInput.playerIndex].health = startingHealth;
        playSO[playInput.playerIndex].hasDied = false;
        playSO[playInput.playerIndex].rolling = false;
        playSO[playInput.playerIndex].invincble = false;
        playSO[playInput.playerIndex].isReloading = false;
        playSO[playInput.playerIndex].isGamePad = false;
        playSO[playInput.playerIndex].playerName = null;
        playSO[playInput.playerIndex].rematchSetUpComplete = true;
        playSO[playInput.playerIndex].letterIn = 0;
        playSO[playInput.playerIndex].livesLeft = 3;
        playSO[playInput.playerIndex].gunChosen = 0;
        playSO[playInput.playerIndex].bulletsInChamber = 6;
        playSO[playInput.playerIndex].isTurret = false;
        playSO[playInput.playerIndex].turretDisabled = false;
        playSO[playInput.playerIndex].touchingSewage = false;
        playSO[playInput.playerIndex].burning = false;
        playSO[playInput.playerIndex].oringalGunChosen = 0;
        playSO[playInput.playerIndex].magicBooksHeld = 0;
        playSO[playInput.playerIndex].lightingGoblin = false;
        playSO[playInput.playerIndex].canMove = true;
        playSO[playInput.playerIndex].buff = false;
        playSO[playInput.playerIndex].state = 0;
        playSO[playInput.playerIndex].bulletSpread = false;
        playSO[playInput.playerIndex].firing = false;
        playSO[playInput.playerIndex].money = mainSO.startingCash;
        playSO[playInput.playerIndex].wheelActivate = false;
        playSO[playInput.playerIndex].perkOwned = 0;
        playSO[playInput.playerIndex].magicRockMult = 1;
        playSO[playInput.playerIndex].magicRockMult = 1;
        playSO[playInput.playerIndex].inRollState = false;
        playSO[playInput.playerIndex].recoilGun = false;
        playSO[playInput.playerIndex].recoilPower = 0;
        playSO[playInput.playerIndex].freeze = false;
        playSO[playInput.playerIndex].respawning= false;
        playSO[playInput.playerIndex].resetGunStats = false;
        playSO[playInput.playerIndex].perkButPressed= false;
        playSO[playInput.playerIndex].bloodRaged = false;
        playSO[playInput.playerIndex].moveAnimsPlayable = true;
        playSO[playInput.playerIndex].grappling= false;
        playSO[playInput.playerIndex].kills=0;

        StartCoroutine(LateStart());

    }


    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(.01f);
        playSO[playInput.playerIndex].livesLeft = mainSO.stock;
    }
}
