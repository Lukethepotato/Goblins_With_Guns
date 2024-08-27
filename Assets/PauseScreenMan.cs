using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreenMan : MonoBehaviour
{
    public GameObject parent;
    public MainSO mainSO;
    public int pausePlayer = -1;
    public MapSongNames songNames;
    // Start is called before the first frame update
    void Start()
    {
        parent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void Pause(int player)
    {
        if (mainSO.gamePaused == false)
        {
            player = pausePlayer;
            parent.SetActive(true);
            mainSO.gamePaused = true;
            mainSO.setUpOver = false;
            Time.timeScale = .01f;
            GameObject.Find("Music").GetComponent<AudioManager>().Pause(songNames.names[mainSO.map]);
        }
    }

    public void Quit()
    {
        if (mainSO.gamePaused)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
            GameObject.Find("Music").GetComponent<AudioManager>().StopPlaying(songNames.names[mainSO.map]);
            mainSO.gamePaused = false;
        }
    }

    public void Resume()
    {
        if (mainSO.gamePaused)
        {
            Time.timeScale = 1;
            parent.SetActive(false);
            mainSO.gamePaused = false;
            mainSO.setUpOver = true;
            GameObject.Find("Music").GetComponent<AudioManager>().UnPause(songNames.names[mainSO.map]);
        }
    }
}
