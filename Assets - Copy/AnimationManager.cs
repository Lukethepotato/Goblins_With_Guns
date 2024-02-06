using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animator;
    private string currentState;
    public string ROLL = "Roll";
    public string ROLL_FORWARD = "Roll_Forward";
    public string IDLE = "Idle";
    public string Run_Forward = "Run_Forward";
    public string Run_Forward_Left = "Run_Forward_Left";
    public string Run_Forward_Right = "Run_Forward_Right";
    public string Run_Backward = "Run_Backward";
    public string Run_Backward_Right = "Run_Backward_Right";
    public string Run_Backward_Left = "Run_Backward_Left";
    public string Roll_Left = "Roll_Left";
    public string Roll_Right = "Roll_Right";

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void ChangeAnimationState(string NewState)
    {
        if (currentState == NewState)
        {
            return;
        }
        //play the animation
        animator.Play(NewState);

        //reassign the current animation
        currentState = NewState;
    }
}
