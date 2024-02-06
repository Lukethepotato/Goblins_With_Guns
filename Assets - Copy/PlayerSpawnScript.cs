using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpawnScript : MonoBehaviour
{
    public MainSO mainSO;
    public PlayerInput input;
    // Start is called before the first frame update
    void Start()
    {
        input = gameObject.GetComponent<PlayerInput>();
        gameObject.transform.position = mainSO.playersSpawnLocations[input.playerIndex];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
