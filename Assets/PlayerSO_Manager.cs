using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerSO_Manager : MonoBehaviour
{
    public Player_SO[] playSO;
    PlayerInput playInput;
    public float basicBulletDamage;
    public float startingHealth;
    public MainSO mainSO;
    public bool gate = true;
    public float respawnTime = 0.5f;
    public InputActionMap inputAction;
    BoxCollider2D BoxCollider2D;
    public BoxCollider2D floorColl;
    public GameObject floorObject;
    public GameObject effects;
    public AnimationManager effectAnimMan;
    private bool touchingDrone = false;
    HealingDroneManager healDrone;
    VampPerkMan vampPerkMan;
    public GameObject gun;
    public GunPerkValueTeaks gunTweaks;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        BoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        effectAnimMan = effects.GetComponent<AnimationManager>();
        vampPerkMan = gameObject.GetComponent<VampPerkMan>();
        floorColl = floorObject.GetComponent<BoxCollider2D>();
        gunTweaks = gun.GetComponent<GunPerkValueTeaks>();
        playSO[playInput.playerIndex].inGame= true;
        print("heyp fatty");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].health <= .1f && playSO[playInput.playerIndex].hasDied == false && mainSO.setUpOver && gate) 
        {
            StartCoroutine(Respawn());
            effectAnimMan.ChangeAnimationState("Effects_Idle");
            gate = false;
        }

        if (playSO[playInput.playerIndex].livesLeft == 0 && playSO[playInput.playerIndex].hasDied == false)
        {
            playSO[playInput.playerIndex].hasDied= true;
            mainSO.playersDead += 1;
        }

        if (mainSO.gameIsOver && playSO[playInput.playerIndex].health > 0 && mainSO.rematchSelected == false && playSO[playInput.playerIndex].livesLeft > 0)
        {
            mainSO.winner = playInput.playerIndex + 1;
        }
    }


    IEnumerator Respawn()
    {
        GameObject.Find("PlayerSFX").GetComponent<AudioManager>().Play("KillSound");

        playInput.DeactivateInput();
        BoxCollider2D.enabled = false;
        floorColl.enabled = false;
        playSO[playInput.playerIndex].inGame = false;
        playSO[playInput.playerIndex].livesLeft -= 1;
        if (playSO[playInput.playerIndex].livesLeft > 0)
        {
            playSO[playInput.playerIndex].respawning = true;
        }
        yield return new WaitForSeconds(respawnTime);
        print("Life-1");
        if (playSO[playInput.playerIndex].livesLeft > 0)
        {

            playSO[playInput.playerIndex].inGame = true;
            playInput.ActivateInput();
            if (mainSO.inSuddenDeath == false && playSO[playInput.playerIndex].health <= 0)
            {
                gameObject.transform.position = mainSO.playersSpawnLocations[Random.Range(0, mainSO.playersSpawnLocations.Length)];
            }

            if (playSO[playInput.playerIndex].perkOwned == 4)
            {
                playSO[playInput.playerIndex].health = mainSO.startingVampireHealth;
            }else if (playSO[playInput.playerIndex].perkOwned == 2)
            {
                playSO[playInput.playerIndex].health = mainSO.scoutHealth;
            }
            else
            {
                playSO[playInput.playerIndex].health = 200;
            }
            BoxCollider2D.enabled = true;
            floorColl.enabled = true;
            playSO[playInput.playerIndex].isReloading = false;
            playSO[playInput.playerIndex].respawning = false;
            playSO[playInput.playerIndex].bloodRaged = false;
            gunTweaks.ApplyPerkGunStats(true);
            gunTweaks.SetGunsBackToNormal();
            playSO[playInput.playerIndex].gunChosen = playSO[playInput.playerIndex].oringalGunChosen;
            gunTweaks.ApplyPerkGunStats(false);
        }
        gate = true;
    }
}
