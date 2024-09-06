using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSetter : MonoBehaviour
{
    public int setGamesPlayedTo;
    SaveDataMan saveDataMan;
    // Start is called before the first frame update
    void Start()
    {
        saveDataMan = gameObject.GetComponent<SaveDataMan>();

        if (setGamesPlayedTo > -1)
        {
            saveDataMan.SaveInt("GamesPlayed", setGamesPlayedTo);
            print("gamesPlayed set to" + saveDataMan.loadInt("GamesPlayed"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
