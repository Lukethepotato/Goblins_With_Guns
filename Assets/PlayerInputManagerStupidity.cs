using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManagerStupidity : MonoBehaviour
{
    PlayerInputManager playInputMan;
    // Start is called before the first frame update
    void Start()
    {
        playInputMan = gameObject.GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playInputMan.enabled = true;
    }
}
