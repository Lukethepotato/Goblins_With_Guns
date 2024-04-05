using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MKwiiMusicLayering : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Music").GetComponent<AudioManager>().Play("StartUpLayer1");
        GameObject.Find("Music").GetComponent<AudioManager>().Play("StartUpLayer2");
        GameObject.Find("Music").GetComponent<AudioManager>().Play("StartUpLayer3");
        GameObject.Find("Music").GetComponent<AudioManager>().Play("StartUpLayer4");
        PlayLayer(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayLayer(int layer)
    {
        GameObject.Find("Music").GetComponent<AudioManager>().RaiseVolume("StartUpLayer" + layer.ToString(),1);
    }


    public void Stop()
    {
        GameObject.Find("Music").GetComponent<AudioManager>().LowerVolume(("StartUpLayer1"), 1);
        GameObject.Find("Music").GetComponent<AudioManager>().LowerVolume(("StartUpLayer2"), 1);
        GameObject.Find("Music").GetComponent<AudioManager>().LowerVolume(("StartUpLayer3"), 1);
        GameObject.Find("Music").GetComponent<AudioManager>().LowerVolume(("StartUpLayer4"), 1);
        print("StopMuisc");
    }
}
