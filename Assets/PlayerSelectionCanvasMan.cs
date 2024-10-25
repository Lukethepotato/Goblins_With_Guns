using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.UI;

public class PlayerSelectionCanvasMan : MonoBehaviour
{
    public int currentPannel;
    public GameObject[] pannels;
    public MainSO mainSO;
    public MultiplayerEventSystem multEventSys;
    public GameObject eventSysObject;
    private GameObject lastGameObject = null;

    // Start is called before the first frame update
    void Start()
    {
        multEventSys = eventSysObject.GetComponent<MultiplayerEventSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        if (mainSO.setUpOver == false && mainSO.gamePaused == false)
        {
            for (int I = 0; I < pannels.Length; I++)
            {
                if (pannels[I]!= null)
                {
                    if (I == currentPannel)
                    {
                        pannels[I].SetActive(true);
                    }
                    else
                    {
                        pannels[I].SetActive(false);
                    }
                }
            }

            if (currentPannel < 0)
            {
                currentPannel = 0;
            }

            if (currentPannel > pannels.Length - 1)
            {
                currentPannel = pannels.Length - 1;
            }
        }

        if (lastGameObject == null)
        {
            lastGameObject = multEventSys.currentSelectedGameObject;
        }

        if (multEventSys.currentSelectedGameObject != lastGameObject)
        {
            GameObject.Find("UI").GetComponent<AudioManager>().Play("SelectChange2");
            lastGameObject = multEventSys.currentSelectedGameObject;
        }

    }
}
