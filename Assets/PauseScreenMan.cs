using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenMan : MonoBehaviour
{
    public GameObject parent;
    public GameObject underTransition;
    public GameObject tranisitionObject;
    public MainSO mainSO;
    public int pausePlayer = -1;
    public MapSongNames songNames;

    public float pauseTransitionTimeIn;
    public float pauseTransitionTimeOut;

    public GameObject[] slides;
    public int slideOn = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        parent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.gamePaused) 
        {
            for (int I = 0; I < slides.Length; I++)
            {
                if (I != slideOn)
                {
                    slides[I].SetActive(false);
                }
                else
                {
                    slides[I].SetActive(true);
                }
            }
        }
    }
    
    public void Pause()
    {
        if (mainSO.gamePaused == false && mainSO.setUpOver && mainSO.gameIsOver == false)
        {
            StartCoroutine(PauseIn());
        }
    }

    public void Quit()
    {
        if (mainSO.gamePaused)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
            GameObject.Find("Music").GetComponent<AudioManager>().StopPlaying(songNames.names[mainSO.map]);
            GameObject.Find("Music").GetComponent<AudioManager>().StopPlaying("FOOTBALL_Loop");
            mainSO.gamePaused = false;
        }
    }

    public void Resume()
    {
        if (mainSO.gamePaused)
        {
            StartCoroutine(PauseOut());
        }
    }

    public void ChangeSlide(int slideToChangeTo)
    {
        if (mainSO.gamePaused)
        {
            slideOn = slideToChangeTo;
        }
    }


    IEnumerator PauseIn()
    {
        parent.SetActive(true);
        GameObject.Find("Music").GetComponent<AudioManager>().Pause(songNames.names[mainSO.map]);
        mainSO.gamePaused = true;
        mainSO.setUpOver = false;
        yield return new WaitForSeconds(pauseTransitionTimeIn);
        underTransition.SetActive(true);
        yield return new WaitForSeconds(pauseTransitionTimeOut);
        GameObject.Find("Music").GetComponent<AudioManager>().Play("FOOTBALL_Loop");
        tranisitionObject.SetActive(false);
        Time.timeScale = .01f;
        print("JFEI");
    }

    IEnumerator PauseOut()
    {
        Time.timeScale = 1;
        tranisitionObject.SetActive(true);
        yield return new WaitForSeconds(pauseTransitionTimeIn);
        underTransition.SetActive(false);
        yield return new WaitForSeconds(pauseTransitionTimeOut);
        parent.SetActive(false);
        mainSO.gamePaused = false;
        mainSO.setUpOver = true;
        GameObject.Find("Music").GetComponent<AudioManager>().UnPause(songNames.names[mainSO.map]);
        GameObject.Find("Music").GetComponent<AudioManager>().StopPlaying("FOOTBALL_Loop");
    }
}


