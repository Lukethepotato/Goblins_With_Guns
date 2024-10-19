using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceSoundMan : MonoBehaviour
{
    public string[] mapSound;
    public MainSO mainSO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.setUpOver && mapSound[mainSO.map] != "" && mainSO.gameIsOver == false)
        {
            if (GameObject.Find("SFX").GetComponent<AudioManager>().StillPlaying(mapSound[mainSO.map]) == false)
            {
                GameObject.Find("SFX").GetComponent<AudioManager>().Play(mapSound[mainSO.map]);
            }
        }
        else
        {
            GameObject.Find("SFX").GetComponent<AudioManager>().StopPlaying(mapSound[mainSO.map]);
        }
    }
}
