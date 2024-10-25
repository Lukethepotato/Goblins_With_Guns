using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionNextBack : MonoBehaviour
{
    public GameObject parent;
    public PlayerSelectionCanvasMan selectionMain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextOrBack(int change)
    {
        selectionMain.currentPannel += change;
        GameObject.Find("UI").GetComponent<AudioManager>().Play("ClickSound2");
    }
}
