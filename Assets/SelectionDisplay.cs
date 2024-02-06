using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

public class SelectionDisplay : MonoBehaviour
{
    public MultiplayerEventSystem multEventSys;
    public GameObject eventSysObject;
    public GameObject[] buttons;
    public GameObject[] display;
    private int lastDisplay;
    public bool displayLast = false;
    private bool noneShown = false;
    //public int total
    // Start is called before the first frame update
    void Start()
    {
        multEventSys = eventSysObject.GetComponent<MultiplayerEventSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        for (int I = 0; I < buttons.Length; I++)
        {
            if (multEventSys.currentSelectedGameObject == buttons[I])
            {
                display[I].SetActive(true);
            }
            else
            {
                if (displayLast)
                {
                    for (int i = 0; i < buttons.Length; i++)
                    {
                        if (display[i].activeSelf == true && display[i] != display[I])
                        {
                            display[I].SetActive(false);
                        }
                    }

                    //noneShown = true;
                }
                else
                {
                    display[I].SetActive(false);
                }

            }
        }

    }
}
