using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class deathAnimationManager : MonoBehaviour
{
    public AnimationManager animationManager;
    public bool dead =false;
    public Player_SO[] playSO;
    PlayerInput playInput;
    public string deathAnimation;
    public bool acidDeath = true;
    // Start is called before the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
        animationManager = gameObject.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dead)
        animationManager.ChangeAnimationState(deathAnimation);

        if (playSO[playInput.playerIndex].health < 1)
        {
            dead = true;
        }
        else
        {
            dead= false;
        }

        if (dead)
        {
            if (playSO[playInput.playerIndex].touchingSewage && dead)
            {
                deathAnimation = "Acid_Death";
            }else
            {
                deathAnimation = "Angel_Death";
            }
        }
        else
        {
            deathAnimation = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
