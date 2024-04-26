using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BloodRageMan : MonoBehaviour
{
    public float bloodRageDrain;
    public float BlueBallsHealthIncrease;
    public Player_SO[] playSO;
    PlayerInput playInput;
    public GameObject gun;
    public GunPerkValueTeaks perkValueTweaks;
    private bool transistion;
    public float turningMadTime;


    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        perkValueTweaks = gun.GetComponent<GunPerkValueTeaks>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].perkOwned == 11)
        {
            if (playSO[playInput.playerIndex].perkButPressed && transistion == false)
            {
                if (playSO[playInput.playerIndex].bloodRaged == false)
                {
                    StartCoroutine(Zerging());
                }
                else
                {
                    StartCoroutine(LosingBoner());
                }
            }

            if (playSO[playInput.playerIndex].bloodRaged && playSO[playInput.playerIndex].health > 0)
            {
                playSO[playInput.playerIndex].health -= Time.deltaTime * bloodRageDrain;
            }
            else if (playSO[playInput.playerIndex].health > 0)
            {
                playSO[playInput.playerIndex].health += Time.deltaTime * BlueBallsHealthIncrease;
            }
        }
    }

    IEnumerator Zerging()
    {
        transistion = true;
        playSO[playInput.playerIndex].freeze = true;
        yield return new WaitForSeconds(turningMadTime);
        playSO[playInput.playerIndex].freeze = false;
        transistion = false;
        playSO[playInput.playerIndex].bloodRaged = true;
        perkValueTweaks.ApplyPerkGunStats(true);
    }

    IEnumerator LosingBoner()
    {
        transistion = true;
        playSO[playInput.playerIndex].freeze = true;
        yield return new WaitForSeconds(turningMadTime);
        playSO[playInput.playerIndex].freeze = false;
        transistion = false;
        playSO[playInput.playerIndex].bloodRaged = false;
        perkValueTweaks.ApplyPerkGunStats(true);
    }
}
