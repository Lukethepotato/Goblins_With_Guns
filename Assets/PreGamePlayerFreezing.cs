using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreGamePlayerFreezing : MonoBehaviour
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
            mainSO.freezeAllPlayer = true;
        }
        else if (mainSO.setUpOver)
        {
            mainSO.freezeAllPlayer = false;
        }
    }
}
