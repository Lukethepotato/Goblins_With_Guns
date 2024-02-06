using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPeiceRespawner : MonoBehaviour
{
    public GameObject[] setPeices;
    public GameObject[] locations;
    public MainSO mainSO;
    public string objectName;
    public bool gate = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainSO.rematchSelected)
        {
            for (int i = 0; i < setPeices.Length; i++)
            {
                if (locations[i] != null)
                {
                    Destroy(locations[i]);
                }
                else
                {
                    Destroy(GameObject.Find(objectName + "(Clone)"));
                }

                Instantiate(setPeices[i], locations[i].transform.position, Quaternion.identity);

                if (i == setPeices.Length-1)
                {
                    gate= false;
                }
            }
            gate = true;
        }
    }
}
