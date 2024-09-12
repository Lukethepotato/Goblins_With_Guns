using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenScrollMan : MonoBehaviour
{
    public Animator scrollAnitor;
    public AnimationManager scrollAnim;
    public GameObject scrollPannel;
    public GameObject FX;
    public AnimationManager animFX;
    public float startUpAnim;
    public float timeToParticle;
    public float openParticleTime;
    public float timeToOpen;
    public GameObject UI;
    public float timeToMapOff;
    public float timeToClose;
    private bool endind = false;
    private bool loadScene = false;
    private int sceneLoadTo = 0;
    public float unactiveTime;
    public bool disabled = true;
    private bool coyotePress = false;
    // Start is called before the first frame update
    void Start()
    {
        scrollAnitor = scrollPannel.GetComponent<Animator>();
        scrollAnim = scrollPannel.GetComponent<AnimationManager>();
        animFX = FX.GetComponent<AnimationManager>();
    }

    public void StartUp()
    {
        StartCoroutine(StartUpCoroutine());
        GameObject.Find("AudioManagers").GetComponent<MKwiiMusicLayering>().PlayLayer(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (loadScene == true) 
        {
            loadScene = false;
            SceneManager.LoadScene(sceneLoadTo);
        }
    }

    IEnumerator StartUpCoroutine()
    {
        yield return new WaitForSeconds(startUpAnim);
        scrollAnim.ChangeAnimationState("StartSceneScroll_Open");
        yield return new WaitForSeconds(timeToParticle);
        animFX.ChangeAnimationState("StartScrene_FX_Play");
        yield return new WaitForSeconds(timeToParticle);
        UI.SetActive(true);
        yield return new WaitForSeconds(openParticleTime - timeToParticle);
        animFX.ChangeAnimationState("StartScrene_FX_Idle");
        yield return new WaitForSeconds(timeToOpen - (openParticleTime + timeToParticle));
        scrollAnim.ChangeAnimationState("StartSceneScroll_Idle");
        yield return new WaitForSeconds(unactiveTime);
        disabled = false;
        if (coyotePress) 
        {
            StartCoroutine(Close(1));
        }
    }

    IEnumerator Close(int modeScene)
    {
        if (disabled == false)
        {
            scrollAnim.ChangeAnimationState("StartSceneScroll_Close");
            yield return new WaitForSeconds(timeToMapOff);
            UI.SetActive(false);
            yield return new WaitForSeconds(timeToClose);
            scrollAnim.ChangeAnimationState("StartSceneScroll_Closed");
            sceneLoadTo = modeScene;
            loadScene = true;
        }
        else
        {
            coyotePress = true;
        }
    }

    public void ModeButtonPressed(int chosenMode)
    {
        if (endind == false)
        {
            endind = true;
            StartCoroutine(Close(chosenMode));
        }

        GameObject.Find("SFX").GetComponent<AudioManager>().Play("ClickSound1");
    }
}
