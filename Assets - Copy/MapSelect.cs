using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelect : MonoBehaviour
{
    public MainSO mainSO;
    public void mapSelected(int mapId)
    {
        mainSO.map = mapId;
        SceneManager.LoadScene(2);
    }
}
