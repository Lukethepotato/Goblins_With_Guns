using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelect : MonoBehaviour
{
    public MainSO mainSO;
    public GameObject scroll;
    public MainScene_Scroll scrollScript;
    private bool gate = false;
    private void Start()
    {
        scrollScript = scroll.GetComponent<MainScene_Scroll>();
    }
    public void mapSelected(int mapId)
    {
        if (gate == false)
        {
            mainSO.map = mapId;
            scrollScript.MapSelected();
            GameObject.Find("UI").GetComponent<AudioManager>().Play("ClickSound1");
        }
    }
}
