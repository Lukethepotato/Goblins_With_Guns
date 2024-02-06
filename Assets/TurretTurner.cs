using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class TurretTurner : MonoBehaviour
{
    public Slider slider;
    public float timeLeft;
    public float maxTime;
    public float shutOffDelay;
    public bool done = false;
    public InteractionInputDectection input;
    public Player_SO[] playSO;
    public GameObject turret;
    public bool idleShutOff;
    public AnimationManager animMan;
    public GameObject well;
    
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponentInChildren<Slider>();
        input = gameObject.GetComponent<InteractionInputDectection>();
        animMan = well.GetComponent<AnimationManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (input.holding && done == false)
        {
            timeLeft += Time.deltaTime;
            playSO[input.playerSO].freeze = true;
            if (input.holding && timeLeft > 0)
            {
                animMan.ChangeAnimationState("TurretTurnerTurn");
            }
            else
            {
                animMan.ChangeAnimationState("TurretTurnerIdle");
            }
        } else if (input.canceled)
        {
            input.canceled = false;
            playSO[input.playerSO].freeze = false;
            animMan.ChangeAnimationState("TurretTurnerIdle");
        } else if (input.holding == false && timeLeft > 0 && done == false && idleShutOff)
        {
            timeLeft -= Time.deltaTime * shutOffDelay;
            animMan.ChangeAnimationState("TurretTurnerIdle");
        }

        if (timeLeft > maxTime && done == false)
        {
            done = true;
            playSO[input.playerSO].freeze = false;
            animMan.ChangeAnimationState("TurretTurnerIdle");
        }

        slider.value = timeLeft;
        slider.maxValue = maxTime;

        if (turret.activeSelf && done)
        {
            timeLeft -= (Time.deltaTime * shutOffDelay);
            animMan.ChangeAnimationState("TurretTurnerFall");
        }

        if (turret.activeSelf && (timeLeft < 0 || timeLeft == 0) && done)
        {
            done = false;
            animMan.ChangeAnimationState("TurretTurnerIdle");
        }
    }
}
