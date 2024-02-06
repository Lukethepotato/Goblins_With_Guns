using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class switchingActionMaps : MonoBehaviour
{
    public MainSO MainSO;
    PlayerInput playInput;
    private bool inUIMap = false;
    // Start is called befosre the first frame update
    void Start()
    {
        playInput = gameObject.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainSO.setUpOver == false && inUIMap == false)
        {
            playInput.SwitchCurrentActionMap("UI");
            inUIMap = true;
        }
        else if (MainSO.setUpOver && inUIMap == true)
        {
            playInput.SwitchCurrentActionMap("Player");
            inUIMap = false;
        }
    }
}
