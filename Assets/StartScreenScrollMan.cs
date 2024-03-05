using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenScrollMan : MonoBehaviour
{
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
    // Start is called before the first frame update
    void Start()
    {
        scrollAnim = scrollPannel.GetComponent<AnimationManager>();
        animFX = FX.GetComponent<AnimationManager>();
        StartCoroutine(StartUpCoroutine());
        GameObject.Find("AudioManagers").GetComponent<MKwiiMusicLayering>().PlayLayer(2);
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    IEnumerator Close(int modeScene)
    {
        scrollAnim.ChangeAnimationState("StartSceneScroll_Close");
        yield return new WaitForSeconds(timeToMapOff);
        UI.SetActive(false);
        //yield return new WaitForSeconds(timeToClose - timeToMapOff);
        SceneManager.LoadScene(modeScene);
    }

    public void ModeButtonPressed(int chosenMode)
    {
        if (endind == false)
        {
            StartCoroutine(Close(chosenMode));
            endind= true;
        }
    }
}
