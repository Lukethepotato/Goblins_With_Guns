using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class ReadyUpScript : MonoBehaviour
{
    public MainSO mainSO;
    private bool isReadied = false;
    private bool canInput = false;
    public Player_SO[] playSO;
    public PlayerInput playInput;
    public GameObject playerObject;
    public Button button;



    private void Start()
    {
        StartCoroutine(TimeInputsCounted());
        playInput = playInput.GetComponent<PlayerInput>();
        button = gameObject.GetComponent<Button>();
    }

    private void Awake()
    {
        canInput = false;
    }

    public void OnReadyClick()
    {
        if (isReadied == false && canInput == true)
        {
            isReadied = true;
            mainSO.playersReadiedUp++;
        }
    }

    IEnumerator TimeInputsCounted()
    {
        yield return new WaitForSeconds(.02f);
        canInput= true;
    }
}
