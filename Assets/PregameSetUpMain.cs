using MultiplayerBasicExample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PregameSetUpMain : MonoBehaviour
{
    public PlayerInputManager playMan;
    public GameObject playManObject;
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        playMan = playManObject.GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.preGameSetUp)
        {
            playMan.EnableJoining();
        }
    }
}
