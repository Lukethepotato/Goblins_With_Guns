using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyUpReset : MonoBehaviour
{
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        mainSO.playersReadiedUp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
