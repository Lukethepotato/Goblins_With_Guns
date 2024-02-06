using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFollower : MonoBehaviour
{
    public string playerUnityName;
    public string currentTarget;
    public GameObject player1;
    public Player_SO[] playSO;
    private int currentPlayer;
    Rigidbody2D RB;
    public float speed;
    public PlayerInputManager playInputMan;
    public GameObject playInObject;
    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
        playInputMan = playInObject.GetComponent<PlayerInputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find(playerUnityName) != null)
        {
            currentTarget = playerUnityName;
        }
        else
        {
            for (currentPlayer = 0; currentPlayer + 1 <= playInputMan.playerCount; currentPlayer++)
            {
                if (playSO[currentPlayer].hasDied == false && GameObject.Find("player" + (currentPlayer + 1).ToString()) != null)
                {
                    currentTarget = "player" + (currentPlayer + 1).ToString();
                }
            }
        }

        if (GameObject.Find(currentTarget) != null)
        {
            RB.position = Vector2.MoveTowards(transform.position, GameObject.Find(currentTarget).transform.position, speed * Time.deltaTime);
        }
    }

}
