using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.InputSystem;
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
    public GameObject MatchLoadCover;
    public float matchLoadCoverTimeIn;
    public float matchLoadCoverTimeOut;
    public GameObject canvas;
    public MapMusicPlayer mapSong;
    public bool inFootballStartUp = false;
    public VolumePlaySO volSO;

    private bool InMapClose = false;

    // Start is called before the first frame update
    void Start()
    {
        FX.SetActive(true);
        animMan = gameObject.GetComponent<AnimationManager>();
        maps.SetActive(false);
        StartCoroutine(Open(maps)) ;
        animFX = FX.GetComponent<AnimationManager>();

        mapSong = canvas.GetComponent<MapMusicPlayer>();
        mainSO.freezeAllPlayer= true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (mainSO.inStartUpMov && startedEnd == false)
        {
            startedEnd= true;
            StartCoroutine(End());
        }

        if (GameObject.Find("player1").GetComponent<CompleteInputDectection>().input && inFootballStartUp)
        {
            SkipCutScene();
            print("AHHHHHHHH");
        }
    }

    IEnumerator Open(GameObject openedMenu)
    {
        print("open Courtine");
        animMan.ChangeAnimationState("MainScene_Scroll_ClosedIdle");
        yield return new WaitForSeconds(timeToStart);
        GameObject.Find("UI").GetComponent<AudioManager>().Play("ScrollOpen");
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
        GameObject.Find("UI").GetComponent<AudioManager>().Play("ScrollClose");
        //yield return new WaitForSeconds(timeToMapOff);
        maps.SetActive(false);
        yield return new WaitForSeconds(timeToMapOff);
        animMan.ChangeAnimationState("MainSceneScroll_Open");
        GameObject.Find("UI").GetComponent<AudioManager>().Play("ScrollOpen");
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
        animMan.ChangeAnimationState("MainScene_ScrollClose");
        GameObject.Find("UI").GetComponent<AudioManager>().Play("ScrollClose");
        mainSO.preMapLoadAnim = false;
        pressAnyJoin.SetActive(false) ;
        yield return new WaitForSeconds(timeToMapOff);

        animMan.ChangeAnimationState("MainScene_Scroll_End");
        GameObject.Find("AudioManagers").GetComponent<MKwiiMusicLayering>().Stop();
        MatchLoadCover.SetActive(true);
        yield return new WaitForSeconds(matchLoadCoverTimeIn);

        mainSO.setUpOver = true;
        inFootballStartUp = true;
        GameObject.Find("Music").GetComponent<AudioManager>().Play("FOOTBALL_NonLooop");
        animMan.ChangeAnimationState("MainScene_Scroll_End");
        yield return new WaitForSeconds(matchLoadCoverTimeOut);

        inFootballStartUp = false;
        mapSong.PlayMapSong();
        MatchLoadCover.SetActive(false);
        gameObject.SetActive(false);
        mainSO.setUpOver = true;
        mainSO.freezeAllPlayer = false;
        volSO.activeVolLocked = true;
    }

    public void SkipCutScene()
    {
        GameObject.Find("Music").GetComponent<AudioManager>().StopPlaying("FOOTBALL_NonLooop");
        mapSong.PlayMapSong();
        MatchLoadCover.SetActive(false);
        gameObject.SetActive(false);
        mainSO.setUpOver = true;
        mainSO.freezeAllPlayer = false;
        inFootballStartUp = false;
        volSO.activeVolLocked = true;
    }

    public void PublicEnd()
    {
        StartCoroutine(End());
    }

}
