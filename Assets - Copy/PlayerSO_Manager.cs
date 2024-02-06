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
    private bool gate = true;
    public float respawnTime = 0.5f;
    public InputActionMap inputAction;
    BoxCollider2D BoxCollider2D;
    public GameObject effects;
    public AnimationManager effectAnimMan;
    private bool touchingDrone = false;
    HealingDroneManager healDrone;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        BoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        effectAnimMan = effects.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].health < 1 && playSO[playInput.playerIndex].hasDied == false && mainSO.setUpOver && gate) 
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bullet") && playSO[playInput.playerIndex].invincble == false && mainSO.freezeAllPlayer == false)
        {
            playSO[playInput.playerIndex].health -= basicBulletDamage;
            print("Taken Damage");
        }
    }


    IEnumerator Respawn()
    {
        playInput.DeactivateInput();
        BoxCollider2D.enabled = false;
        yield return new WaitForSeconds(respawnTime);
        playSO[playInput.playerIndex].livesLeft -= 1;
        print("Life-1");
        if (playSO[playInput.playerIndex].livesLeft > 0)
        {
            playInput.ActivateInput();
            gameObject.transform.position = mainSO.playersSpawnLocations[playInput.playerIndex];
            playSO[playInput.playerIndex].health = 100;
            BoxCollider2D.enabled = true;
        }
        gate = true;
    }
}
