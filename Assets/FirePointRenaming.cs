using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirePointRenaming : MonoBehaviour
{
    public PlayerInput playInput;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.name = gameObject.name + playInput.playerIndex.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
