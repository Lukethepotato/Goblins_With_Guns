using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnouncerMan : MonoBehaviour
{
    public AnouncerSO anouncerSO;
    public MainSO mainSO;
    public string lastSoundPlayed;
    public float chitChatInterval;
    private bool restartChitChatCourtine = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (restartChitChatCourtine && mainSO.gameIsOver == false && mainSO.setUpOver == true)
        {
            StartCoroutine(ChitChatCourtine());
        }
        else
        {
            GameObject.Find("Announcers").GetComponent<AudioManager>().StopPlaying(lastSoundPlayed);
            StopCoroutine(ChitChatCourtine());
            restartChitChatCourtine = true;
        }
    }

    public void playKillLine()
    {
        int maxVoiceLineNum = anouncerSO.killVoiceLineNames.Length;
        string linePlay = anouncerSO.killVoiceLineNames[Random.Range(0, maxVoiceLineNum)];


        if (lastSoundPlayed == "" || GameObject.Find("Announcers").GetComponent<AudioManager>().StillPlaying(lastSoundPlayed) == false)
        {
            lastSoundPlayed = linePlay;
            GameObject.Find("Announcers").GetComponent<AudioManager>().Play(linePlay);
        }
    }

    public void RandChitChatLine()
    {
        int maxVoiceLineNum = anouncerSO.randChitChat.Length;
        string linePlay = anouncerSO.randChitChat[Random.Range(0, maxVoiceLineNum)];

        if (lastSoundPlayed == "" || GameObject.Find("Announcers").GetComponent<AudioManager>().StillPlaying(lastSoundPlayed) == false)
        {
            lastSoundPlayed = linePlay;
            GameObject.Find("Announcers").GetComponent<AudioManager>().Play(linePlay);
        }
    }

    IEnumerator ChitChatCourtine()
    {
        restartChitChatCourtine = false;
        yield return new WaitForSeconds(chitChatInterval);
        if (mainSO.gameIsOver == false && mainSO.setUpOver == true)
        {
            RandChitChatLine();
        }
        restartChitChatCourtine = true;
    }
}
