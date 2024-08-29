using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionCanvasMan : MonoBehaviour
{
    public int currentPannel;
    public GameObject[] pannels;
    public MainSO mainSO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (mainSO.setUpOver == false)
        {
            for (int I = 0; I < pannels.Length; I++)
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

            if (currentPannel < 0)
            {
                currentPannel = 0;
            }

            if (currentPannel > pannels.Length - 1)
            {
                currentPannel = pannels.Length - 1;
            }
        }

    }
}
