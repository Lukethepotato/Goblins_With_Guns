using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenStartButton : MonoBehaviour
{
    public GameObject pannel;
    public AnimationManager animMan;
    public GameObject gameModeSelect;
    public float animTime;

    // Start is called before the first frame update
    private void Start()
    {
        animMan = pannel.GetComponent<AnimationManager>();
        GameObject.Find("UI").GetComponent<AudioManager>().Play("GunPolish");
        gameModeSelect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void startButtonPress()
    {
        StartCoroutine(TitleEnd());
        GameObject.Find("UI").GetComponent<AudioManager>().Play("ClickSound1");
    }

    IEnumerator TitleEnd()
    {
        GameObject.Find("UI").GetComponent<AudioManager>().StopPlaying("GunPolish");
        animMan.ChangeAnimationState("TitleScreenEnd");
        GameObject.Find("UI").GetComponent<AudioManager>().Play("TitleScreenStartUp");
        yield return new WaitForSeconds(animTime);
        gameModeSelect.SetActive(true);
        gameModeSelect.GetComponent<StartScreenScrollMan>().StartUp();
        gameObject.SetActive(false);

    }
}
