using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public MainSO MainSO;
    public GameObject playerPrephab;
    // Start is called before the first frame update
    void Start()
    {
        for (int I = 0; I < MainSO.playersReadiedUp; I++)
        {
            Instantiate(playerPrephab, new Vector2(0,0), Quaternion.identity);
        }
    }
}
