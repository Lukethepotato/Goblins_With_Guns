using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetUpPannelDestruction : MonoBehaviour
{
    public MainSO mainSO;
    public PlayerInput playerInput;
    public GameObject player;
    public Player_SO[] playSO;

    private void Start()
    {
        playerInput = player.GetComponent<PlayerInput>();
    }
    // Start is called before the first frame update
    void Update()
    {
        if (mainSO.setUpOver)
        {
            playSO[playerInput.playerIndex].oringalGunChosen = playSO[playerInput.playerIndex].gunChosen;
            Destroy(gameObject);
        }
    }
}
