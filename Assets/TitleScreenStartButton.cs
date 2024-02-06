using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenStartButton : MonoBehaviour
{
    public GameObject pannel;
    public AnimationManager animMan;
    public float animTime;

    // Start is called before the first frame update
    void Start()
    {
        animMan = pannel.GetComponent<AnimationManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void startButtonPress()
    {
        StartCoroutine(TitleEnd());
    }

    IEnumerator TitleEnd()
    {
        animMan.ChangeAnimationState("TitleScreenEnd");
        yield return new WaitForSeconds(animTime);
        SceneManager.LoadScene(2);
    }
}
