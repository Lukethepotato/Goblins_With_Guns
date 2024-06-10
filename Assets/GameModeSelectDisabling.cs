using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeSelectDisabling : MonoBehaviour
{
    public GameObject gameModeSelect;
    // Start is called before the first frame update
    void Start()
    {
        gameModeSelect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
