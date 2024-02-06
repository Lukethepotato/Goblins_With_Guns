using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLiveMan : MonoBehaviour
{
    AnimationManager animMan;
    public Player_SO playSO;
    public int lifeNum;
    public float lifeLoseAnim;
    public float lifeGainAnim;
    private bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        animMan = gameObject.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeNum > playSO.livesLeft && alive)
        {
            alive = false;
            StartCoroutine(LoseLife());
        }

        if (alive == false && lifeNum < playSO.livesLeft)
        {
            alive = true;
            StartCoroutine(GainLife());
        }
    }

    IEnumerator LoseLife()
    {
        animMan.ChangeAnimationState("Live_Lose");
        yield return new WaitForSeconds(lifeLoseAnim);
        animMan.ChangeAnimationState("Life_Empty");
        print("uhfhif");
    }

    IEnumerator GainLife()
    {
        animMan.ChangeAnimationState("Live_Gain");
        yield return new WaitForSeconds(lifeGainAnim);
        animMan.ChangeAnimationState("Live_Idle");
        
    }
}
