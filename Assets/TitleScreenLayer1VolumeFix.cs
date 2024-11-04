using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenLayer1VolumeFix : MonoBehaviour
{
    AudioManager audioManager;
    public VolumePlaySO volSO;
    public MainSO mainSO;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = gameObject.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.setUpOver == false)
        {
            audioManager.SetVolume("StartUpLayer1", audioManager.sounds[0].baseVolume * volSO.activeVolumes[1]);
        }
        else
        {
            audioManager.StopPlaying("StartUpLayer1");
        }
    }
}
