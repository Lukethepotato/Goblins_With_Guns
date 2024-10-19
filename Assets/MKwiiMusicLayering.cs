using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MKwiiMusicLayering : MonoBehaviour
{
    public float distGuitarVol;
    public float fadeInTime = .25f;
    public float leenTweenVolume;
    public int Layer;
    public float fadeOutTime;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }
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
        /*
        if (layer == 4)
        {
            GameObject.Find("Music").GetComponent<AudioManager>().RaiseVolume("StartUpLayer" + layer.ToString(), distGuitarVol);
        }
        else
        */
        Layer= layer;

        LeanTween.value(gameObject, 0, .05f, fadeInTime).setEaseInBack().setOnUpdate(LengthSetting);
        
    }

    public void FadeOutLayer(int layer)
    {
        Layer = layer;
        LeanTween.value(gameObject, .5f, 0, fadeOutTime).setEaseInBack().setOnUpdate(LengthSetting);

    }

    private void LengthSetting(float value)
    {
        leenTweenVolume = value;
        GameObject.Find("Music").GetComponent<AudioManager>().RaiseVolume("StartUpLayer" + Layer.ToString(), leenTweenVolume);
    }

    private void LengthSettingAll(float value)
    {
        leenTweenVolume = value;
        GameObject.Find("Music").GetComponent<AudioManager>().SetVolume("StartUpLayer1", leenTweenVolume);
        GameObject.Find("Music").GetComponent<AudioManager>().SetVolume("StartUpLayer2", leenTweenVolume);
        GameObject.Find("Music").GetComponent<AudioManager>().SetVolume("StartUpLayer3", leenTweenVolume);
        GameObject.Find("Music").GetComponent<AudioManager>().SetVolume("StartUpLayer4", leenTweenVolume);
    }


    public void Stop()
    {
        /*
        GameObject.Find("Music").GetComponent<AudioManager>().LowerVolume(("StartUpLayer1"), 1);
        GameObject.Find("Music").GetComponent<AudioManager>().LowerVolume(("StartUpLayer2"), 1);
        GameObject.Find("Music").GetComponent<AudioManager>().LowerVolume(("StartUpLayer3"), 1);
        GameObject.Find("Music").GetComponent<AudioManager>().LowerVolume(("StartUpLayer4"), 1);
        */
        LeanTween.value(gameObject, .25f, 0, fadeOutTime).setEaseLinear().setOnUpdate(LengthSettingAll);
        print("StopMuisc");
    }
}
