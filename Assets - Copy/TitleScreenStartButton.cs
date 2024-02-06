using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenStartButton : MonoBehaviour
{
    public GameObject titleScreenEmpty;
    public GameObject GameModeSelectEmpty;
    public GameObject eventSytem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void startButtonPress()
    {
        titleScreenEmpty.SetActive(false);
        GameModeSelectEmpty.SetActive(true);
        eventSytem.SetActive(false);
    }
}
