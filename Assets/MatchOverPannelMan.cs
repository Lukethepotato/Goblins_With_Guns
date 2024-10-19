using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MatchOverPannelMan : MonoBehaviour
{
    AnimationManager animMan;
    public float startUpAnimTimeIn;
    public float startUpAnimTimeOut;
    public float rematchAnimTime;
    public float quitAnimTime;
    public GameObject quitButton;
    public GameObject rematchButton;
    public AnimationManager quitAnimMan;
    public AnimationManager rematchAnimMan;

    public GameObject canvas;
    public GameOverButtonsScript gameOverButtonsScript;
    public MainSO mainSO;
    private bool gate = true;
    public bool readyToChange = false;
    public Player_SO[] playSO;
    public GameObject names;
    public GameObject Kills;
    private int playersIn;
    // Start is called before the first frame update
    void Start()
    {
        quitAnimMan = quitButton.GetComponent<AnimationManager>();
        rematchAnimMan = rematchButton.GetComponent<AnimationManager>();

        gameOverButtonsScript = canvas.GetComponent<GameOverButtonsScript>();
        animMan = gameObject.GetComponent<AnimationManager>();
        names.SetActive(false);
        quitButton.SetActive(false);
        rematchButton.SetActive(false);
        Kills.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gate)
        {
            gate = false;
            playersIn = mainSO.playersReadiedUp;
            if (playersIn >= 2)
            {
                playersIn = mainSO.playersReadiedUp;
            }
            else
            {
                playersIn = 2;
            }
            StartCoroutine(StartUp());
        }   

        if (readyToChange)
        {
            if (playSO[mainSO.rankings[0]].ActiveMoveInput.x > .01f)
            {
                StartCoroutine(RematchAnim());
            }

            if (playSO[mainSO.rankings[0]].ActiveMoveInput.x < -.01f)
            {
                StartCoroutine(QuitAnim());
            }
        }
    }

    public void Rematch()
    {
        StartCoroutine(RematchAnim());
    }

    public void Quit()
    {
        StartCoroutine(QuitAnim());
    }

    IEnumerator StartUp()
    {
        GameObject.Find("UI").GetComponent<AudioManager>().Play("ResultsStartUp");
        //GameCompleteTheme
        animMan.ChangeAnimationState("MatchOver_Start"+playersIn.ToString());
        // mainSO.setUpOver = false;
        yield return new WaitForSeconds(startUpAnimTimeIn);
        quitButton.SetActive(true);
        rematchButton.SetActive(true);
        names.SetActive(true);
        Kills.SetActive(true);
        GameObject.Find("Music").GetComponent<AudioManager>().Play("GameCompleteTheme");
        GameObject.Find("UI").GetComponent<AudioManager>().Play("ResultsIdle");
        yield return new WaitForSeconds(startUpAnimTimeOut);
        animMan.ChangeAnimationState("MatchOver_idle" + playersIn.ToString());
        print("MAtchOverIdle");
        readyToChange = true;
        names.SetActive(true);
    }

    IEnumerator RematchAnim()
    {
        GameObject.Find("UI").GetComponent<AudioManager>().Play("ResultsRematch");
        GameObject.Find("UI").GetComponent<AudioManager>().StopPlaying("ResultsIdle");
        readyToChange = false;
        rematchAnimMan.ChangeAnimationState("RematchSelected");
        quitAnimMan.ChangeAnimationState("QuitUnselected");
        names.SetActive(false);
        Kills.SetActive(false);
        GameObject.Find("Music").GetComponent<AudioManager>().StopPlaying("GameCompleteTheme");
       // quitButton.SetActive(false);
      //  rematchButton.SetActive(false);
        animMan.ChangeAnimationState("MatchOver_Rematch" + playersIn.ToString());
        quitAnimMan.ChangeAnimationState("GameOverButtonPressed2");
        rematchAnimMan.ChangeAnimationState("GameOverButtonPressed");
        yield return new WaitForSeconds(rematchAnimTime);
        gameOverButtonsScript.Rematch();
    }
    IEnumerator QuitAnim()
    {
        GameObject.Find("UI").GetComponent<AudioManager>().StopPlaying("ResultsIdle");
        readyToChange = false;
        rematchAnimMan.ChangeAnimationState("RematchUnselected");
        quitAnimMan.ChangeAnimationState("QuitSelected");
        names.SetActive(false);
        Kills.SetActive(false);
        GameObject.Find("Music").GetComponent<AudioManager>().StopPlaying("GameCompleteTheme");
       // quitButton.SetActive(false);
        //rematchButton.SetActive(false);
        quitAnimMan.ChangeAnimationState("GameOverButtonPressed2");
        rematchAnimMan.ChangeAnimationState("GameOverButtonPressed");
        animMan.ChangeAnimationState("MatchOver_Quit" + playersIn.ToString());
        yield return new WaitForSeconds(quitAnimTime);
        gameOverButtonsScript.Quit();
    }

}
