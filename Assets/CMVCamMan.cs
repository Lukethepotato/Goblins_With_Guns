using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMVCamMan : MonoBehaviour
{
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
            //cmvCam.m_HorizontalDamping = 0;
            //cmvCam.m_VerticalDamping= 0;
            
        }
        else
        {
            //cmvCam.m_HorizontalDamping = 1;
            //cmvCam.m_VerticalDamping = 1;
        }
    }
}
