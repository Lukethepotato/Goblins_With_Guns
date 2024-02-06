using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDroneManager : MonoBehaviour
{
    public Player_SO[] playSO;
    public MainSO mainSO;
    public PlayerInput playInput;
    public int newHealth = 100;
    private bool gate = false;
    private bool isTouchingLand = false;
    public GameObject effects;
    public AnimationManager effectAnimMan;
    HealingDroneManager healDroneMan;

    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        effectAnimMan = effects.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].health > 1) 
        {
            gate = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HealingBox_LandZone") && isTouchingLand == false)
        {
            healDroneMan = collision.gameObject.GetComponentInParent<HealingDroneManager>();
            collision.gameObject.GetComponentInParent<HealingDroneManager>().playersInLandingZone += 1;
            isTouchingLand= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HealingBox_LandZone") && isTouchingLand == true)
        {
            collision.gameObject.GetComponentInParent<HealingDroneManager>().playersInLandingZone -= 1;
            isTouchingLand= false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeployedHealingDrone"))
        {
            collision.gameObject.GetComponent<HealingDroneManager>().healthReceived = true;
            playSO[playInput.playerIndex].health += newHealth;
            playSO[playInput.playerIndex].livesLeft += mainSO.healingDroneLivesToAdd;
            print("Healed");
            StartCoroutine(HealAnimation());
        }
    }

    IEnumerator HealAnimation()
    {
        effectAnimMan.ChangeAnimationState("Effects_Heal");
        yield return new WaitForSeconds(.59f);
        effectAnimMan.ChangeAnimationState("Effects_Idle");
    }

}
