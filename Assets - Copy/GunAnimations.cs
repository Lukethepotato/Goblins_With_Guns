using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunAnimations : MonoBehaviour
{
    BulletFiring bulletFiring;
    public AnimationManager[] animManager;
    public Player_SO[] playSO;
    public PlayerInput playInput; 
    // Start is called before the first frame update
    void Start()
    {
        bulletFiring = gameObject.GetComponent<BulletFiring>();
        animManager = gameObject.GetComponentsInChildren<AnimationManager>();
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
