using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunWheelManager : MonoBehaviour
{
    public GameObject gunWheel;
    public AnimationManager gunWheelAnimMan;
    public PlayerInput playInput;
    public Player_SO[] playSO;
    public string[] gunWheelAnims;
    public int[] possibleGuns;
    private bool gunRolling = false;
    public int moneyNeeded;
    // Start is called before the first frame update
    void Start()
    {
        gunWheelAnimMan = gunWheel.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].health < 1)
        {
            playSO[playInput.playerIndex].gunChosen = playSO[playInput.playerIndex].oringalGunChosen;
        }

        if (playSO[playInput.playerIndex].wheelActivate)
        {
            playSO[playInput.playerIndex].wheelActivate = false;
            StartCoroutine(GunWheel());
            playSO[playInput.playerIndex].money -= moneyNeeded;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("GunGranter") && gunRolling == false && playSO[playInput.playerIndex].money >= moneyNeeded)
        {
            StartCoroutine(GunWheel());
            print("GunWheelActivated");
            gunRolling = true;
            playSO[playInput.playerIndex].money -= moneyNeeded;
            //collision.gameObject.GetComponent<GunGranter>().disabled = true;
        }
        */
    }

    IEnumerator GunWheel()
    {
        print("GunWheelProcessed");
        //int newGun = Random.Range(0, 4);
        var newGun = Random.Range(0, 4);
        if (newGun == playSO[playInput.playerIndex].gunChosen)
        {
            newGun= Random.Range(0, 4);
        }
        gunWheelAnimMan.ChangeAnimationState(gunWheelAnims[newGun]);
        yield return new WaitForSeconds(1.2f);
        playSO[playInput.playerIndex].bulletsInChamber = 0;
        playSO[playInput.playerIndex].gunChosen = possibleGuns[newGun];
        gunRolling= false;
        gunWheelAnimMan.ChangeAnimationState("GunWheel.Idle");
    }
}
