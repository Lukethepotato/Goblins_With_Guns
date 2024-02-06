using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasRankingNumbersMan : MonoBehaviour
{
    public GameObject[] rankingNumber;
    public PlayerInputManager playerManager;
    public GameObject playManObject;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = playManObject.GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I < playerManager.playerCount; I++)
        {
            rankingNumber[I].SetActive(true);
        }
    }
}
