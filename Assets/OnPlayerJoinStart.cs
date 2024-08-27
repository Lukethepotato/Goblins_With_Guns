using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerJoinStart : MonoBehaviour
{
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
