using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingVolumeTweaks : MonoBehaviour
{
    public Slider[] volumeSlider;
    public GameObject[] sliders;
    public VolumePlaySO volumeSO;
    // Start is called before the first frame update
    private void Awake()
    {
        for (int I = 0; I < volumeSlider.Length -1; I++)
        {
            volumeSlider[I] = sliders[I].GetComponent<Slider>();
        }

        for (int I = 0; I < volumeSO.setVolumes.Length-1; I++)
        {
            volumeSlider[I].value = volumeSO.setVolumes[I];
        }
    }


    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I < volumeSO.setVolumes.Length - 1; I++)
        {
            volumeSO.setVolumes[I] = volumeSlider[I].value;
        }
    }
}
