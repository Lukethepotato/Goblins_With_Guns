using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingVolumeTweaks : MonoBehaviour
{
    public Slider[] volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        for (int I = 0; I < volumeSlider.Length; I++)
        {
            volumeSlider[I] = gameObject.GetComponentInChildren<Slider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int I = 0; I < volumeSlider.Length; I++)
        {
            GameObject.Find("AudioManagers").GetComponent<AudioManager>().Play("");
        }
    }
}
