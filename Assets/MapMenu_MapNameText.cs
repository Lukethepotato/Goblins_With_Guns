using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.UI;
using UnityEngine.EventSystems;
using System;

public class MapMenu_MapNameText : MonoBehaviour
{
    public string[] mapNames;
    public GameObject[] maps;
    public MultiplayerEventSystem multEventSys;
    public GameObject eventSysObject;
    TextMeshProUGUI menuText;
    private GameObject lastGameObject = null;
    // Start is called before the first frame update
    void Start()
    {
        multEventSys = eventSysObject.GetComponent<MultiplayerEventSystem>();
        menuText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I < maps.Length; I++) 
        { 
            if (multEventSys.currentSelectedGameObject == maps[I])
            {
                menuText.text = mapNames[I];
            }
        }
            
        if (lastGameObject == null)
        {
            lastGameObject = multEventSys.currentSelectedGameObject;
        }

        if (multEventSys.currentSelectedGameObject != lastGameObject)
        {
            GameObject.Find("UI").GetComponent<AudioManager>().Play("SelectChange1");
            lastGameObject = multEventSys.currentSelectedGameObject;
        }
    }
}
