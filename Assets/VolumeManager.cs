using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VolumeManager : MonoBehaviour
{
    public VolumePlaySO VolumeSO;
    public float newPlayerVol = 1;
    public AudioManager[] audioManagers;
    // Start is called before the first frame update
    void Start()
    {
        VolumeSO.activeVolLocked = false;


        for (int i = 0;i < audioManagers.Length; i++)
        {
            audioManagers[i] = gameObject.GetComponentInChildren<AudioManager>();
        }

        VolumeSO.activeVolLocked = false;

        if (GameObject.Find("SaveManager").GetComponent<SaveDataMan>().loadInt("GamesPlayed") == 0)
        {
            for (int I = 0; I < VolumeSO.setVolumes.Length; I++)
            {
                VolumeSO.setVolumes[I] = newPlayerVol;
            }
        }
        else
        {
            for (int I = 0; I < VolumeSO.setVolumes.Length; I++)
            {
                VolumeSO.setVolumes[I] = GameObject.Find("SaveManager").GetComponent<SaveDataMan>().loadFloat("Volume" + I.ToString());
            }
        }

        for (int I = 0; I < VolumeSO.activeVolumes.Length; I++)
        {
            VolumeSO.activeVolumes[I] = VolumeSO.setVolumes[I];
        }


        //VolumeSO.activeVolumes[4] = 0;
        //VolumeSO.activeVolumes[2] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I < VolumeSO.setVolumes.Length; I++)
        {
            GameObject.Find("SaveManager").GetComponent<SaveDataMan>().SaveFloat("Volume" + I.ToString(), VolumeSO.setVolumes[I]);
        }
        //constantly setting saved volume to the volume the player sets

        if (VolumeSO.activeVolLocked)
        {
            for (int I = 0; I < VolumeSO.activeVolumes.Length; I++)
            {
                VolumeSO.activeVolumes[I] = VolumeSO.setVolumes[I];
            }
        }
        // constantly setting the active vol to the set volume when active vol locked is set to true
    }
}
