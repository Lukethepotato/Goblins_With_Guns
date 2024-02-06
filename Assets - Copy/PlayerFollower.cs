using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFollower : MonoBehaviour
{
    public string playerUnityName;
    public GameObject player1;
    public Player_SO[] playSO;
    private int currentPlayer;
    Rigidbody2D RB;
    public float dragTime;
    public float drag;
    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find(playerUnityName) != null)
        {
            RB.position = GameObject.Find(playerUnityName).transform.position;

        } else if (playSO[0].hasDied == false)
        {
            RB.position = player1.transform.position;
        }
        else
        {
            for (currentPlayer = 0; playSO[currentPlayer].hasDied == false; currentPlayer++)
            {
               RB.position = GameObject.Find("player" + playSO[currentPlayer].playerIndex.ToString()).transform.position;
            }
        }

        if (playSO[currentPlayer].telaporting) 
        {
            portalTime();
            playSO[currentPlayer].telaporting = false;
        }

        
    }

    IEnumerator portalTime()
    {
        RB.drag = drag;
        yield return new WaitForSeconds(dragTime);
        RB.drag = 0;
    }

}
