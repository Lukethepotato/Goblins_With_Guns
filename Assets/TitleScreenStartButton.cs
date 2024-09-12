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
    void Start()
    {
        animMan = pannel.GetComponent<AnimationManager>();
        gameModeSelect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void startButtonPress()
    {
        StartCoroutine(TitleEnd());
        GameObject.Find("SFX").GetComponent<AudioManager>().Play("ClickSound1");
    }

    IEnumerator TitleEnd()
    {
        animMan.ChangeAnimationState("TitleScreenEnd");
        yield return new WaitForSeconds(animTime);
        gameModeSelect.SetActive(true);
        gameModeSelect.GetComponent<StartScreenScrollMan>().StartUp();
        gameObject.SetActive(false);

    }
}
