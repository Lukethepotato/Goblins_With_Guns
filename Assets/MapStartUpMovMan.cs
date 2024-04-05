using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStartUpMovMan : MonoBehaviour
{
    public float length;
    public MainSO mainSO;
    MapMusicPlayer mapSong;
    public GameObject scroll;
    // Start is called before the first frame update
    void Start()
    {
        mapSong = gameObject.GetComponent<MapMusicPlayer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start()
    {
        if (mainSO.playStartUpMov)
        {
            StartCoroutine(StartUpMov());
        }
        else
        {
            EndStartUpMov();
        }
    }

    public IEnumerator StartUpMov()
    {
        mainSO.inStartUpMov= true;
        yield return new WaitForSeconds(length);
        EndStartUpMov();
    }

    public void EndStartUpMov()
    {
        mapSong.PlayMapSong();
        mainSO.inStartUpMov = true;
        mainSO.inStartUpMov = false;
        mainSO.setUpOver = true;
        scroll.GetComponent<MainScene_Scroll>().PublicEnd();
    }
}
