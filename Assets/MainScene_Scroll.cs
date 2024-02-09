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
    public float timeToClose;
    public float timeToEnd;
    public GameObject maps;
    private bool startedEnd = false;
    public GameObject FX;
    public AnimationManager animFX;
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
        if (mainSO.setUpOver && startedEnd == false)
        {
            startedEnd= true;
            StartCoroutine(End());
        }
    }

    IEnumerator Open(GameObject openedMenu)
    {
        animMan.ChangeAnimationState("MainSceneScroll_Open");
        yield return new WaitForSeconds(timeToParticle);
        animFX.ChangeAnimationState("Particle_Open");
        yield return new WaitForSeconds(timeToParticle);
        openedMenu.SetActive(true);
        yield return new WaitForSeconds(openParticleTime - timeToParticle);
        animFX.ChangeAnimationState("Particle_Idle");
        yield return new WaitForSeconds(timeToOpen - (openParticleTime + timeToParticle));
        animMan.ChangeAnimationState("MainScene_Scroll_Idle");
    }

    IEnumerator MapClose()
    {
        animMan.ChangeAnimationState("MainScene_Scroll_Close");
        yield return new WaitForSeconds(timeToMapOff);
        maps.SetActive(false);
        yield return new WaitForSeconds(timeToClose - timeToClose);
        mainSO.preGameSetUp = true;
        animMan.ChangeAnimationState("MainSceneScroll_Open");
        yield return new WaitForSeconds(timeToParticle);
        animFX.ChangeAnimationState("Particle_Open");
        yield return new WaitForSeconds(openParticleTime);
        animFX.ChangeAnimationState("Particle_Idle");
        yield return new WaitForSeconds(timeToOpen - (openParticleTime + timeToParticle));
        animMan.ChangeAnimationState("MainScene_Scroll_Idle");
    }

    IEnumerator End()
    {
        animMan.ChangeAnimationState("MainScene_Scroll_End");
        yield return new WaitForSeconds(timeToEnd);
        gameObject.SetActive(false);
    }

    public void MapSelected()
    {
        StartCoroutine(MapClose());
    }
}
