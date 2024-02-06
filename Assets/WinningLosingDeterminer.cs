using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WinningLosingDeterminer : MonoBehaviour
{
    public Player_SO[] playSO;
    public MainSO mainSO;
    public PlayerInputManager playInputMan;
    public GameObject playInObject;
    public int[] PlayersUnsorted;
    // Start is called before the first frame update
    void Start()
    {
        playInputMan= playInObject.GetComponent<PlayerInputManager>();
        mainSO.rankings.Clear();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
