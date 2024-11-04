using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TitleScreenMan : MonoBehaviour
{
    AnimationManager animMan;
    public float startUpAnimTime;
    public GameObject button;
    public VolumePlaySO VolumeSO;
    // Start is called before the first frame update
    void Start()
    {
        animMan = gameObject.GetComponent<AnimationManager>();
        StartCoroutine(StartUpAnim());
        GameObject.Find("AudioManagers").GetComponent<MKwiiMusicLayering>().PlayLayer(1);

        VolumeSO.activeVolumes[4] = 0;
        VolumeSO.activeVolumes[2] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartUpAnim()
    {
        GameObject.Find("UI").GetComponent<AudioManager>().Play("TitleIdle");
        yield return new WaitForSeconds(startUpAnimTime);
        animMan.ChangeAnimationState("TitleScreen");
        button.SetActive(true);
    }
}
