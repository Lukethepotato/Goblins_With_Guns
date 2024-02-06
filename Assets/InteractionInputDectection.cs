using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionInputDectection : MonoBehaviour
{
    public bool interacted = false;
    public int playerSO;
    public bool holding = false;
    public bool canceled = false;

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
        StartCoroutine(Disable());
    }

    public void holdInteraction(int playSO)
    {
        holding= true;
        playerSO = playSO;
    }

    public void releaseInteraction(int playSO)
    {
        holding = false;
        canceled= true;
        playerSO = playSO;
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(.01f);
        interacted = false;
    }
}
