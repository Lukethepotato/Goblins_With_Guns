using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirePointCopyMan : MonoBehaviour
{
    public Player_SO[] playSO;
    public PlayerInput playInput;
    public float multiplier;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        playInput= player.GetComponent<PlayerInput>();
        gameObject.name = gameObject.name + playInput.playerIndex.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = new Vector2(playSO[playInput.playerIndex].moveInput.x * multiplier + player.transform.position.x, playSO[playInput.playerIndex].moveInput.y * multiplier + player.transform.position.y);
    }
}
