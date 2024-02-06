using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFollowerManager : MonoBehaviour
{
    public PlayerInputManager inputManager;
    public GameObject inputGameObject;
    public GameObject[] playerFollowers;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = inputGameObject.GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I < inputManager.playerCount; I++)
        {
            playerFollowers[I].SetActive(true);
        }
    }
}
