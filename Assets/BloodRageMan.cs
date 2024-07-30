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
    public float turningSadTimeP1;
    public float turningSadTimeP2;
    public GameObject behindFX;
    AnimationManager goblinAnim;
    public AnimationManager behindFXanim;


    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        perkValueTweaks = gun.GetComponent<GunPerkValueTeaks>(); 
        goblinAnim = gameObject.GetComponent<AnimationManager>();
        behindFXanim = behindFX.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].perkOwned == 11)
        {
            if (playSO[playInput.playerIndex].state != 1 && playSO[playInput.playerIndex].touchingSewage == false)
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

                if (playSO[playInput.playerIndex].bloodRaged && playSO[playInput.playerIndex].health > .1f)
                {
                    playSO[playInput.playerIndex].health -= Time.deltaTime * bloodRageDrain;
                }
                else if (playSO[playInput.playerIndex].health > .1f)
                {
                    playSO[playInput.playerIndex].health += Time.deltaTime * BlueBallsHealthIncrease;
                }
            }
            else
            {
                playSO[playInput.playerIndex].bloodRaged = false;
                perkValueTweaks.ApplyPerkGunStats(true);
            }
        }
    }

    IEnumerator Zerging()
    {
        playSO[playInput.playerIndex].moveAnimsPlayable = false;
        transistion = true;
        goblinAnim.ChangeAnimationState("GoingBloodRage");
        playSO[playInput.playerIndex].freeze = true;
        yield return new WaitForSeconds(turningMadTime);
        playSO[playInput.playerIndex].freeze = false;
        transistion = false;
        playSO[playInput.playerIndex].bloodRaged = true;
        perkValueTweaks.ApplyPerkGunStats(true);
        playSO[playInput.playerIndex].moveAnimsPlayable = true;
        behindFXanim.ChangeAnimationState("BloodRageFX");
    }

    IEnumerator LosingBoner()
    {
        transistion = true;
        playSO[playInput.playerIndex].freeze = true;
        playSO[playInput.playerIndex].moveAnimsPlayable = false;
        goblinAnim.ChangeAnimationState("BonerOff");
        yield return new WaitForSeconds(turningSadTimeP1);
        playSO[playInput.playerIndex].bloodRaged = false;
        behindFXanim.ChangeAnimationState("NoneBehindFX");
        yield return new WaitForSeconds(turningSadTimeP2);
        playSO[playInput.playerIndex].freeze = false;
        transistion = false;
        playSO[playInput.playerIndex].moveAnimsPlayable = true;
        perkValueTweaks.ApplyPerkGunStats(true);
    }
}
