using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class MainScene_Scroll : MonoBehaviour
{
    AnimationManager animMan;
    public MainSO mainSO;
    public float timeToOpen;
    public float timeToParticle;
    public float openParticleTime;
    public float timeToMapOff;
    public float timeToEnd;
    public GameObject maps;
    private bool startedEnd = false;
    public GameObject FX;
    public AnimationManager animFX;
    public float timeToStart;
    public GameObject pressAnyJoin;

    private bool InMapClose = false;

    // Start is called before the first frame update
    void Start()
    {
        FX.SetActive(true);
        animMan = gameObject.GetComponent<AnimationManager>();
        maps.SetActive(false);
        StartCoroutine(Open(maps)) ;
        animFX = FX.GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.inStartUpMov && startedEnd == false)
        {
            startedEnd= true;
            StartCoroutine(End());
        }
    }

    IEnumerator Open(GameObject openedMenu)
    {
        print("open Courtine");
        animMan.ChangeAnimationState("MainScene_Scroll_ClosedIdle");
        yield return new WaitForSeconds(timeToStart);
        animMan.ChangeAnimationState("MainSceneScroll_Open");
        yield return new WaitForSeconds(timeToParticle);
        animFX.ChangeAnimationState("Particle_Open");
        yield return new WaitForSeconds(timeToParticle);
        openedMenu.SetActive(true);
        yield return new WaitForSeconds(openParticleTime - timeToParticle);
        animFX.ChangeAnimationState("Particle_Idle");
        yield return new WaitForSeconds(timeToOpen);
        animMan.ChangeAnimationState("MainScene_Scroll_Idle");
        GameObject.Find("AudioManagers").GetComponent<MKwiiMusicLayering>().PlayLayer(3);
    }

    IEnumerator MapClose()
    {
        print("Close Courtine");
        yield return new WaitForSeconds(timeToMapOff);
        animMan.ChangeAnimationState("MainScene_ScrollClose");
        //yield return new WaitForSeconds(timeToMapOff);
        maps.SetActive(false);
        yield return new WaitForSeconds(timeToMapOff);
        animMan.ChangeAnimationState("MainSceneScroll_Open");
        yield return new WaitForSeconds(timeToParticle);
        animFX.ChangeAnimationState("Particle_Open");
        yield return new WaitForSeconds(openParticleTime);
        animFX.ChangeAnimationState("Particle_Idle");
        animMan.ChangeAnimationState("MainScene_Scroll_Idle");
        GameObject.Find("AudioManagers").GetComponent<MKwiiMusicLayering>().PlayLayer(4);
        mainSO.preGameSetUp = true;
        pressAnyJoin.SetActive(true) ;
    }
    public void MapSelected()
    {
        if (InMapClose == false)
        {
            InMapClose = true;
            StartCoroutine(MapClose());
        }
    }
    IEnumerator End()
    {
        animMan.ChangeAnimationState("MainScene_Scroll_End");
        yield return new WaitForSeconds(timeToEnd);
        GameObject.Find("AudioManagers").GetComponent<MKwiiMusicLayering>().Stop();
        gameObject.SetActive(false);
    }

    public void PublicEnd()
    {
        StartCoroutine(End());
    }

}
