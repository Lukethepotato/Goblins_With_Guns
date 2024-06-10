using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BehindEffectsMan : MonoBehaviour
{
    AnimationManager animMan;
    public GameObject parent;
    PlayerInput playInput;
    public Player_SO[] playSO;
    // Start is called before the first frame update
    void Start()
    {
        animMan = gameObject.GetComponent<AnimationManager>();
        playInput= parent.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playSO[playInput.playerIndex].bloodRaged == false || playSO[playInput.playerIndex].health < 1)
        {
            animMan.ChangeAnimationState("NoneBehindFX");
        }else if (playSO[playInput.playerIndex].bloodRaged)
        {
            animMan.ChangeAnimationState("BloodRageFX");
        }
    }
}
