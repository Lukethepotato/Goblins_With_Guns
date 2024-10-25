using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public VolumePlaySO VolumeSO;
    public float newPlayerVol = 1;
    public bool activeVolLocked = false;
    public AudioManager[] audioManagers;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i < audioManagers.Length; i++)
        {
            audioManagers[i] = gameObject.GetComponentInChildren<AudioManager>();
        }

        VolumeSO.activeVolLocked = false;

        if (GameObject.Find("SaveManager").GetComponent<SaveDataMan>().loadInt("GamesPlayed") == 0)
        {
            for (int I = 0; I < VolumeSO.setVolumes.Length - 1; I++)
            {
                VolumeSO.setVolumes[I] = newPlayerVol;
            }
        }
        else
        {
            for (int I = 0; I < VolumeSO.setVolumes.Length - 1; I++)
            {
                VolumeSO.setVolumes[I] = GameObject.Find("SaveManager").GetComponent<SaveDataMan>().loadFloat("Volume" + I.ToString());
            }
        }
    }

    public void ChangeVolume(int VolType)
    {
        for (int I = 0; I < audioManagers.Length; I++)
        {
            if (audioManagers[I].volumeTypeNum== VolType)
            {
                for (int eachSound = 0; eachSound < audioManagers[I].sounds.Length; eachSound++) 
                {
                    audioManagers[I].SetVolume(audioManagers[I].sounds[eachSound].name, audioManagers[I].sounds[eachSound].baseVolume * VolumeSO.activeVolumes[VolType]);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I < VolumeSO.activeVolumes.Length; I++)
        {
            ChangeVolume(I);
        }


        for (int I = 0; I < VolumeSO.setVolumes.Length - 1; I++)
        {
            GameObject.Find("SaveManager").GetComponent<SaveDataMan>().SaveFloat("Volume" + I.ToString(), VolumeSO.setVolumes[I]);
        }
        //constantly setting saved volume to the volume the player sets

        if (VolumeSO.activeVolLocked)
        {
            for (int I = 0; I < VolumeSO.activeVolumes.Length - 1; I++)
            {
                VolumeSO.activeVolumes[I] = VolumeSO.setVolumes[I];
            }
        }
        // constantly setting the active vol to the set volume when active vol locked is set to true
    }
}
