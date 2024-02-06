using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class ReadyUpScript : MonoBehaviour
{
    public MainSO mainSO;
    private bool isReadied = false;
    private bool canInput = false;


    private void Start()
    {
        StartCoroutine(TimeInputsCounted());
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
        yield return new WaitForSeconds(1f);
        canInput= true;
    }
}
