using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMusicPlayer : MonoBehaviour
{
    public MapSongNames songNamesSO;
    public MainSO mainSO;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMapSong()
    {
        GameObject.Find("Music").GetComponent<AudioManager>().Play(songNamesSO.names[mainSO.map]);
    }

    public void StopPlaying()
    {
        GameObject.Find("Music").GetComponent<AudioManager>().StopPlaying(songNamesSO.names[mainSO.map]);
    }
}
