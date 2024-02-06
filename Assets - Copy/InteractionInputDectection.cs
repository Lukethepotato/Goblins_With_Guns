using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionInputDectection : MonoBehaviour
{
    public bool interacted = false;
    public int playerSO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interaction(int playSO)
    {
        interacted = true;
        playerSO = playSO;
    }
}
