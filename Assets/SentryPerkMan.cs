using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SentryPerkMan : MonoBehaviour
{
    public Player_SO[] playSO;
    PlayerInput playInput;
    public bool canMakeTurret = false;
    public float coolDown;
    public float activeCoolDown;
    public GameObject sentry;
    ObjectHealthMan objectHealth;
    public MainSO mainSO;
    public bool liveRegen;
    private int turretsLeft;
    public int turretAmountRegen;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        objectHealth = gameObject.GetComponent<ObjectHealthMan>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeCoolDown <= 0)
        {
            canMakeTurret = true;
        }
        else
        {
            canMakeTurret= false;
        }

        if (playSO[playInput.playerIndex].perkButPressed && canMakeTurret && playSO[playInput.playerIndex].perkOwned == 10 && mainSO.suddenDeathInitiated == false)
        {
            activeCoolDown = coolDown;
            GameObject instanSent = Instantiate(sentry, playSO[playInput.playerIndex].ActiveMoveInput + (Vector2)gameObject.transform.position, Quaternion.identity);
            instanSent.GetComponent<StationaryFirepoint_Data>().owner = playInput.playerIndex;
            //playSO[playInput.playerIndex].freeze = true;
            GameObject.Find("PlayerSFX").GetComponent<AudioManager>().Play("TurretBuild");
        }

        activeCoolDown -= Time.deltaTime;
    }
}
